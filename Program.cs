using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NCalc;
using System.Data;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //.net 自带类库 但是不支持max等函数操作
            //MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControlClass();
            //sc.Language = "JavaScript";
            //Console.WriteLine(sc.Eval(""));//1+12+3
            DateTime d1 = DateTime.Now;
           for(int i = 0; i < 1000; i++) { 
            string str = "cproduct($1$)+csum($2$,1,3)*cavg(2,$1$)";
            Dictionary<string, string> controlIdValueDic = new Dictionary<string, string>();
            //把有值的替换进str;
            controlIdValueDic.Add("1", "2.12312");
            foreach (var item in controlIdValueDic)
            {
                str = str.Replace($"${item.Key}$", item.Value);
            }
            object value = CustomFormula.GetCustomFormulaValue(str);
                //Console.WriteLine(str);
                //Console.WriteLine(value);
                Console.WriteLine(i);
            };
            Console.WriteLine(DateTime.Now.Subtract(d1));
            //NCalc
            //var expr = new Expression("Avg()");
            //expr.EvaluateFunction += NCalcExtensionFunctions;
            //try
            //{
            //    var result = expr.Evaluate();
            //    Console.WriteLine(result);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}






            #region 


            //List<ReceiveFormsControl> list = new List<ReceiveFormsControl>();
            //list.Add(new ReceiveFormsControl
            //{
            //    TempId=1,
            //    Controls = new List<ReceiveControl> {
            //        new ReceiveControl() {
            //            ControlName= "单行文本框",
            //            IsFilter = false,
            //            Type = 1,
            //            Hint = "引导文字",
            //            Validate = false,
            //            Dot=0,
            //            Unit="",
            //            EnumDefault = 0,
            //            PrintHide = false,
            //            Required = false,
            //            NeedSum = false,
            //            Row =0,
            //            Col =0,
            //            InnerRow = 1
            //        },
            //        new ReceiveControl
            //        {
            //            ControlName= "数值",
            //            IsFilter = false,
            //            Type = 6,
            //            Hint = "填写数值",
            //            Validate = false,
            //            Dot=2,
            //            Unit="个",
            //            EnumDefault = 0,
            //            PrintHide = false,
            //            Required = false,
            //            NeedSum = false,
            //            Row =0,
            //            Col =0,
            //            InnerRow = 2


            //        }

            //    }
            //});

            //string a = JsonConvert.SerializeObject(list);
            //Console.ReadKey();


            //Task t1 =  Task.Run(()=>{
            //    throw new Exception("hahah");
            //    System.Threading.Thread.Sleep(5000);
            //    Console.WriteLine("123");
            //});
            //Task t2 = Task.Run(() => {
            //    throw new Exception("lalala");
            //    System.Threading.Thread.Sleep(8000);
            //    Console.WriteLine("223");
            //});
            //try
            //{
            //    Task.WaitAll(t1, t2);
            //}
            //catch (Exception ex)
            //{
            //    t1.Dispose();
            //    t2.Dispose();
            //    Console.WriteLine(ex);
            //}

            #endregion
            Console.ReadKey();
        }



    }

}
