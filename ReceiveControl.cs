using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ReceiveControl
    {
        /// <summary>
        /// 模板ID
        /// </summary>
        public string ControlId { get; set; }
        /// <summary>
        /// 模板名
        /// </summary>
        public string ControlName { set; get; }
        /// <summary>
        /// 是否进入任务筛选
        /// </summary>
        public bool IsFilter { set; get; }
        /// <summary>
        /// 控件类型
        /// </summary>
        public int Type { set; get; }
        /// <summary>
        /// 行号
        /// </summary>
        public int Row { set; get; }
        /// <summary>
        /// 列号
        /// </summary>
        public int Col { set; get; }
        /// <summary>
        /// 引导文字
        /// </summary>
        public string Hint { set; get; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string Default { set; get; }
        /// <summary>
        /// 是否验证
        /// </summary>
        public bool Validate { set; get; }
        /// <summary>
        /// 小数点位数（mongo数值类型最小单位为int）
        /// </summary>
        public int Dot { set; get; }
        /// <summary>
        /// 单位 (如：千克、吨、元)
        /// </summary>
        public string Unit { set; get; }
        /// <summary>
        /// 控件附属枚举，目前控件就一个附属枚举，以后有2个的话会拓展一个EnumDefault字段
        /// </summary>
        public int EnumDefault { set; get; }
        /// <summary>
        /// 默认成员
        /// </summary>
        public List<string> DefaultMen { set; get; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string DataSource { set; get; }
        /// <summary>
        /// 选项列表
        /// </summary>
        public List<ControlOptions> Options { set; get; }
        /// <summary>
        /// 是否打印隐藏（OA用）
        /// </summary>
        public bool PrintHide { set; get; }
        /// <summary>
        /// 是否必填（OA用）
        /// </summary>
        public bool Required { set; get; }



        ///////////////////////////////表单明细新增属性start////////////////////////////////////
        /// <summary>
        /// 新定义的表单明细临时id（只有前端传参使用）
        /// </summary>
        public int TempId { set; get; }
        /// <summary>
        /// 表单明细 保存后的实际id
        /// </summary>
        public string FormId { set; get; }
        /// <summary>
        /// 表单明细排序行（表单明细内部控件才会用到）
        /// </summary>
        public int InnerRow { set; get; }
        /// <summary>
        /// 需要求合
        /// </summary>
        public bool NeedSum { set; get; }
        ///////////////////////////////表单明细新增属性end////////////////////////////////////


    }
}
