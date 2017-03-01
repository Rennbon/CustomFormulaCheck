using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ControlOptions
    {
        /// <summary>
        /// 选项key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 选项value
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 筛选项排序
        /// </summary>
        public int Index { set; get; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { set; get; }

    }
}
