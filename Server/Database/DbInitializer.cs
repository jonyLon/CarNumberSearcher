using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Database
{
    public class DbInitializer
    {
        public static void Init(RegionContext rc)
        {
            rc.Database.EnsureCreated();

            if (rc.Regions.Any())
            {
                return;
            }

            var reg = new Region[]
            {
                new Region{ Code = "BK", RegionName = "Rivne" },
                new Region{ Code = "AB", RegionName = "Vinnytsia" },
                new Region{ Code = "AS", RegionName = "Volyn" },
                new Region{ Code = "AE", RegionName = "Dnipropetrovsk" },
                new Region{ Code = "AA", RegionName = "Kyiv" },
                new Region{ Code = "VA", RegionName = "Kirovohrad" },
                new Region{ Code = "BB", RegionName = "Luhansk" },
                new Region{ Code = "VS", RegionName = "Lviv" },
            };


            foreach ( var region in reg )
            {
                rc.Regions.Add(region);
            }
            rc.SaveChanges();
        }
    }
}
