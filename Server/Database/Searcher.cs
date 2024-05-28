using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database
{
    public class Searcher
    {
        public Region ReturnRegion(string code)
        {
            using (var con = new RegionContext()) {

                return con.Regions.First(r => r.Code == code);
            }
        } 
    }
}
