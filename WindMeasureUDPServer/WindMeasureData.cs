using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindMeasureUDPServer
{
    public class WindMeasureData
    {
        public int Id { get; set; }
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }
    }
}
