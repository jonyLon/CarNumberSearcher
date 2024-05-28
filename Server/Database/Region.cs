using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database
{
    public class Region
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string RegionName { get; set; }


        public override string ToString()
        {
            return $"{Code} => {RegionName} region";
        }
    }
}
