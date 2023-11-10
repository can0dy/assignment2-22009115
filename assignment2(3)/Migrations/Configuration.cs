namespace assignment2_3_.Migrations
{
    using assignment2_3_.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<assignment2_3_.Data.assignment2_3_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(assignment2_3_.Data.assignment2_3_Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var categories = new List<Category>
            {
                new Category {Name = "Women's clothing"},
                new Category {Name = "Men's clothing"},
                new Category {Name = "Children's clothing"},
                new Category {Name = "Jewelry"},
                new Category {Name = "Shoes"},
                new Category {Name = "Dresses"}
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var clothings = new List<Clothing>
            {
                new Clothing {Name = "Dress", Type = "Coordinates", Price  = 362, CategoryID = categories.Single(c => c.Name == "Women's clothing").ID },
                new Clothing {Name = "Knitwear", Type = "Top", Price  = 472, CategoryID = categories.Single(c => c.Name == "Women's clothing").ID },
                new Clothing {Name = "Pants", Type = "Pants", Price  = 226, CategoryID = categories.Single(c => c.Name == "Women's clothing").ID },
                new Clothing {Name = "Windbreaker", Type = "Top", Price  = 662, CategoryID = categories.Single(c => c.Name == "Women's clothing").ID },

                new Clothing {Name = "Shorts", Type = "Pants", Price  = 283, CategoryID = categories.Single(c => c.Name == "Men's clothing").ID },
                new Clothing {Name = "Jeans", Type = "Pants", Price  = 412, CategoryID = categories.Single(c => c.Name == "Men's clothing").ID },
                new Clothing {Name = "Overcoat", Type = "Top", Price  = 862, CategoryID = categories.Single(c => c.Name == "Men's clothing").ID },
                new Clothing {Name = "Cardigan", Type = "Top", Price  = 1362, CategoryID = categories.Single(c => c.Name == "Men's clothing").ID },


                new Clothing {Name = "Casual pants", Type = "Pants", Price  = 432, CategoryID = categories.Single(c => c.Name == "Children's clothing").ID },
                new Clothing {Name = "Skirt", Type = "Coordinates", Price  = 362, CategoryID = categories.Single(c => c.Name == "Children's clothing").ID },
                new Clothing {Name = "Frock", Type = "Coordinates", Price  = 583, CategoryID = categories.Single(c => c.Name == "Children's clothing").ID },
                new Clothing {Name = "Sweater", Type = "Top", Price  = 725, CategoryID = categories.Single(c => c.Name == "Children's clothing").ID },

                new Clothing {Name = "Earrings", Type = "Gold jewelry", Price  = 369, CategoryID = categories.Single(c => c.Name == "Jewelry").ID },
                new Clothing {Name = "Necklace", Type = "Silver jewelry", Price  = 662, CategoryID = categories.Single(c => c.Name == "Jewelry").ID },
                new Clothing {Name = "Ring", Type = "Gold jewelry", Price  = 988, CategoryID = categories.Single(c => c.Name == "Jewelry").ID },
                new Clothing {Name = "Bracelet", Type = "Jade jewelry", Price  = 749, CategoryID = categories.Single(c => c.Name == "Jewelry").ID },

                new Clothing {Name = "Sneakers", Type = "Men's shoes", Price  = 269, CategoryID = categories.Single(c => c.Name == "Shoes").ID },
                new Clothing {Name = "Skates", Type = "Women's shoes", Price  = 318, CategoryID = categories.Single(c => c.Name == "Shoes").ID },
                new Clothing {Name = "High heels", Type = "Women's shoes", Price  = 725, CategoryID = categories.Single(c => c.Name == "Shoes").ID },
                new Clothing {Name = "Mary Jane shoes", Type = "Women's shoes", Price  = 839, CategoryID = categories.Single(c => c.Name == "Shoes").ID },

                new Clothing {Name = "Suit", Type = "Coordinates", Price  = 1539, CategoryID = categories.Single(c => c.Name == "Dresses").ID },
                new Clothing {Name = "Tuxedo", Type = "Coordinates", Price  = 2109, CategoryID = categories.Single(c => c.Name == "Dresses").ID },
                new Clothing {Name = "Professional attire", Type = "Coordinates", Price  = 988, CategoryID = categories.Single(c => c.Name == "Dresses").ID },
                new Clothing {Name = "Formal dress", Type = "Coordinates", Price  = 2809, CategoryID = categories.Single(c => c.Name == "Dresses").ID }


                };
            clothings.ForEach(c => context.Clothings.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}
