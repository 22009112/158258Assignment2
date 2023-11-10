namespace Assignment2_3_.Migrations
{
    using Assignment2_3_.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2_3_.Data.Assignment2_3_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Assignment2_3_.Data.Assignment2_3_Context";
        }

        protected override void Seed(Assignment2_3_.Data.Assignment2_3_Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var areas = new List<City>
            {
                new City {Name = "Beijing"},
                new City {Name = "Lasa"},
                new City {Name = "Yunnan"},
                new City {Name = "Shanxi"},
                new City {Name = "Zhejiang"},
                new City {Name = "Xinjiang"}
            };
            areas.ForEach(c => context.Cities.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var atrractions = new List<Atrraction>
            {
                new Atrraction {Name = "Tian’anmen Square", Address = "Chang'an Street, Dongcheng District, Beijing", Price  = 0,  CityID = areas.Single(c => c.Name == "Beijing").ID },
                new Atrraction {Name = "Palace museum", Address = "No. 4, Jingshan Front Street, Beijing", Price  = 60,  CityID = areas.Single(c => c.Name == "Beijing").ID },
                new Atrraction {Name = "Temple of Heaven", Address = "Chongwen District, Beijing", Price  = 14,  CityID = areas.Single(c => c.Name == "Beijing").ID },
                new Atrraction {Name = "Badaling Great Wall", Address = "Yanqing District, Beijing", Price  = 20,  CityID = areas.Single(c => c.Name == "Beijing").ID },

                new Atrraction {Name = "Potala Palace", Address = "Beijing Middle Road, Chengguan District", Price  = 100,  CityID = areas.Single(c => c.Name == "Lasa").ID },
                new Atrraction {Name = "Nian Qing Tanggula Mountain", Address = "Central and eastern Tibet Autonomous Region", Price  = 0,  CityID = areas.Single(c => c.Name == "Lasa").ID },
                new Atrraction {Name = "Namtso", Address = "Between Lhasa Dangxiong County and Nagqu Bangor County", Price  = 120,  CityID = areas.Single(c => c.Name == "Lasa").ID },

                new Atrraction {Name = "Dali Old City", Address = "Dali City, Dali Bai Autonomous Prefecture", Price  = 0, CityID = areas.Single(c => c.Name == "Yunnan").ID},
                new Atrraction {Name = "Old Town of Lijiang", Address = "Gucheng District Lijiang District", Price  = 50, CityID = areas.Single(c => c.Name == "Yunnan").ID},
                new Atrraction {Name = "Erhai Lake", Address = "Dali City, Dali Prefecture", Price  = 0, CityID = areas.Single(c => c.Name == "Yunnan").ID},
                new Atrraction {Name = "Yulong Snow Mountain", Address = "Lijiang District", Price  = 188, CityID = areas.Single(c => c.Name == "Yunnan").ID},

                new Atrraction {Name = "Terracotta Army", Address = "Mausoleum of Qin Shi Huang, Lintong District, Xi'an City", Price  = 60, CityID = areas.Single(c => c.Name == "Shanxi").ID},
                new Atrraction {Name = "Datang Everbright City", Address = "Yanta District, Xi'an City", Price  = 0, CityID = areas.Single(c => c.Name == "Shanxi").ID},
                new Atrraction {Name = "Mount Hua", Address = "Huayin City, Weinan City", Price  = 100, CityID = areas.Single(c => c.Name == "Shanxi").ID},
                new Atrraction {Name = "The Hukou Waterfalls of Yellow River", Address = "Yichuan County", Price  = 90, CityID = areas.Single(c => c.Name == "Shanxi").ID},

                new Atrraction {Name = "Wuzhen Town", Address = "Tongxiang City, Jiaxing City", Price  = 0, CityID = areas.Single(c => c.Name == "Zhejiang").ID},
                new Atrraction {Name = "Mogan Mountain", Address = "Deqing County, Huzhou District", Price  = 80, CityID = areas.Single(c => c.Name == "Zhejiang").ID},
                new Atrraction {Name = "The West Lake", Address = "Hangzhou District", Price  = 0, CityID = areas.Single(c => c.Name == "Zhejiang").ID},
                new Atrraction {Name = "Thousand Island Lake", Address = "Chun'an County, Hangzhou District", Price  = 195, CityID = areas.Single(c => c.Name == "Zhejiang").ID},

                new Atrraction {Name = "Nalati Scenic Spot", Address = "Xinyuan County", Price  = 95, CityID = areas.Single(c => c.Name == "Xinjiang").ID},
                new Atrraction {Name = "Kanas Lake", Address = "Altay Burzin County", Price  = 0, CityID = areas.Single(c => c.Name == "Xinjiang").ID},
                new Atrraction {Name = "Tianshan Tianchi", Address = "Fukang City, Changji Hui Autonomous Prefecture", Price  = 280, CityID = areas.Single(c => c.Name == "Xinjiang").ID},
                new Atrraction {Name = "Kumtag Desert", Address = "The western part of Gansu Province and the southeastern part of Xinjiang border", Price  = 0, CityID = areas.Single(c => c.Name == "Xinjiang").ID},
            };
            atrractions.ForEach(c => context.Atrractions.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}
