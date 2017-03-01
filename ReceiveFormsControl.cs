using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ReceiveFormsControl
    {
        /// <summary>
        /// 临时id
        /// </summary>
        public int TempId { set; get; }
        /// <summary>
        /// 表单明细id
        /// </summary>
        public string FormId { set; get; }

        public List<ReceiveControl> Controls { set; get; }
    }
}
