using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public enum CustomFormulaMethodType
    {
        /// <summary>
        /// 自定义无效
        /// </summary>
        CustomError = 0,
        /// <summary>
        /// 方法参数无效(无法计算)
        /// </summary>
        FunctionParamInvalid = 1,
        /// <summary>
        /// 移除当前参数，不进入计算
        /// </summary>
        RemoveCurrentParam = 2,
        /// <summary>
        /// 默认值为0
        /// </summary>
        DefaultIsZero = 3,
        /// <summary>
        /// 默认值为1
        /// </summary>
        DefaultIsOne = 4
    }
}
