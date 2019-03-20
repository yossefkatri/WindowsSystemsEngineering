using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency.BE;
namespace Emergency.model
{
    class AnalystModel
    {
        public List<analyst> analysts{ get; set; }
        public void Addanalyst(analyst analyst)
        {
            analysts.Add(analyst);
        }
        public void Removeanalyst(analyst analyst)
        {
            analysts.Remove(analyst);
        }
    }
}
