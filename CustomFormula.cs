using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class CustomFormula
    {
        public static object GetCustomFormulaValue(string str)
        {
            string vb = @"[$](.*?)[$]";
            foreach (Match item in Regex.Matches(str, vb, RegexOptions.IgnoreCase))
            {
                string bbb = item.ToString();
                int index = str.IndexOf(bbb);
                if (index > 0)
                {
                    char frontChar = str[index - 1];
                    char behindChar = str.Length > index + bbb.Length ? str[index + bbb.Length] : new char();
                    if (frontChar.Equals(',') || frontChar.Equals('('))
                    {
                        string str2 = str.Substring(0, index);
                        string str2Reverse = new string(str2.ToCharArray().Reverse().ToArray());
                        CustomFormulaMethodType cfmt = GetFormulaIndex(str2Reverse, frontChar, behindChar);
                        switch (cfmt)
                        {
                            case CustomFormulaMethodType.CustomError:
                                return "无法计算";
                            case CustomFormulaMethodType.FunctionParamInvalid:
                                return "无法计算";
                            case CustomFormulaMethodType.RemoveCurrentParam:
                                str = str.Remove(index - 1, bbb.Length + 1);
                                ; break;
                            case CustomFormulaMethodType.DefaultIsZero:
                                str = str.Remove(index, bbb.Length).Insert(index, "0");
                                ; break;
                            case CustomFormulaMethodType.DefaultIsOne:
                                str = str.Remove(index, bbb.Length).Insert(index, "1");
                                ; break;
                        }
                    }
                    else
                    {
                        //该出为符号
                        return "无法计算";
                    }
                }
            }
            return CustomFormula.GetTheValueOfCustomFormula(str);
        }
        public static string GetRealCustomFormula(string str, string item)
        {
            int index = str.IndexOf(item);
            char frontChar = new char();
            if (index > 1)
            {
                frontChar = str[index - 1];
            }
            string str2 = str.Substring(0, index - 1);
            return null;
        }

        public static CustomFormulaMethodType GetFormulaIndex(string str, char frontChar, char behindChar)
        {
            //str首个为公式的时候进行
            string strCheck = @"[(](xamc|musc|tcudorpc|gvac)";
            string strCheck5L = @"[(](xamc|gvac|musc)";
            string strCheck9L = @"[(](tcudorP)";
            //str只是个普通的括号的话
            if (frontChar.Equals('('))
            {
                if (str.Length < 4)
                {
                    return CustomFormulaMethodType.CustomError;
                }
                else if (str.Length >= 5 && str.Length < 9)
                {
                    if (!Regex.IsMatch(str.Substring(0, 5), strCheck5L))
                    {
                        return CustomFormulaMethodType.CustomError;
                    }
                }
                else
                {
                    if (!Regex.IsMatch(str.Substring(0, 5), strCheck) && !Regex.IsMatch(str.Substring(0, 9), strCheck9L))
                    {
                        return CustomFormulaMethodType.CustomError;
                    }
                }
            }
            foreach (Match item in Regex.Matches(str, strCheck, RegexOptions.IgnoreCase))
            {
                string bbb = item.ToString();
                int index = str.IndexOf(bbb);
                string str2 = str.Substring(0, index + bbb.Length);
                int paramCount = Regex.Matches(str2, @",").Count;
                if (paramCount == 0 && !behindChar.Equals(','))
                {
                    //抛异常
                    return CustomFormulaMethodType.FunctionParamInvalid;
                }
                else if (str2.Contains("xamc") || str2.Contains("gvac"))
                {
                    //移除一个  ",$代数$"
                    return CustomFormulaMethodType.RemoveCurrentParam;
                }
                else if (str2.Contains("musc"))
                {
                    //用0
                    return CustomFormulaMethodType.DefaultIsZero;
                }
                else if (str2.Contains("tcudorpc"))
                {
                    //用1
                    return CustomFormulaMethodType.DefaultIsOne;
                }
            }
            return CustomFormulaMethodType.CustomError;
        }

        /// <summary>
        /// 验证公式合法性
        /// </summary>
        /// <returns></returns>
        public static bool VerifyFormulaLegitimacy(string customFormulaStr)
        {
            try
            {
                GetTheValueOfCustomFormula(customFormulaStr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 计算公式的值
        /// </summary>
        /// <param name="customFormulaStr"></param>
        /// <returns></returns>
        public static object GetTheValueOfCustomFormula(string customFormulaStr)
        {
            try
            {
                var expr = new Expression(customFormulaStr,EvaluateOptions.IgnoreCase);
                expr.EvaluateFunction += NCalcExtensionFunctions;
                return expr.Evaluate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 自定义公式
        /// 以下链接为已有公式
        /// http://ncalc.codeplex.com/wikipage?title=functions&referringTitle=Home
        /// </summary>
        /// <param name="name"></param>
        /// <param name="functionArgs"></param>
        private static void NCalcExtensionFunctions(string name, FunctionArgs functionArgs)
        {
            if (name.Equals("cavg", StringComparison.OrdinalIgnoreCase))
            {
                decimal result = 0;
                for (int i = 0; i < functionArgs.Parameters.Count(); i++)
                {
                    result = result + Convert.ToDecimal(functionArgs.Parameters[i].Evaluate());
                }
                functionArgs.Result = result / (functionArgs.Parameters.Count() + 1);
            }
            else if (name.Equals("cmax", StringComparison.OrdinalIgnoreCase))
            {
                decimal[] paramArr = new decimal[functionArgs.Parameters.Count()];
                for (int i = 0; i < functionArgs.Parameters.Count(); i++)
                {
                    paramArr[i] = Convert.ToDecimal(functionArgs.Parameters[i].Evaluate());
                }
                functionArgs.Result = paramArr.Max();
            }
            else if (name.Equals("cmin", StringComparison.OrdinalIgnoreCase))
            {
                decimal[] paramArr = new decimal[functionArgs.Parameters.Count()];
                for (int i = 0; i < functionArgs.Parameters.Count(); i++)
                {
                    paramArr[i] = Convert.ToDecimal(functionArgs.Parameters[i].Evaluate());
                }
                functionArgs.Result = paramArr.Min();
            }
            else if (name.Equals("cproduct", StringComparison.OrdinalIgnoreCase))
            {
                decimal result = 1;
                for (int i = 0; i < functionArgs.Parameters.Count(); i++)
                {
                    result = result * Convert.ToDecimal(functionArgs.Parameters[i].Evaluate());
                }
                functionArgs.Result = result;

            } else if (name.Equals("csum", StringComparison.OrdinalIgnoreCase))
            {
                decimal result = 0;
                for (int i = 0; i < functionArgs.Parameters.Count(); i++)
                {
                    result = result + Convert.ToDecimal(functionArgs.Parameters[i].Evaluate());
                }
                functionArgs.Result = result;
            }
        }
    }
}
