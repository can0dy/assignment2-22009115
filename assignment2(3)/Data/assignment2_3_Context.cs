using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace assignment2_3_.Data
{
    public class assignment2_3_Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public assignment2_3_Context() : base("name=assignment2_3_Context")
        {
        }

        public System.Data.Entity.DbSet<assignment2_3_.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<assignment2_3_.Models.Clothing> Clothings { get; set; }
    }
}
