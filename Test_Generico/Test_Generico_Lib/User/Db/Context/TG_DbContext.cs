using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Test_Generico_Lib.User;
using Test_Generico_Lib.User.Db.SqlMsg;

namespace Test_Generico_Lib.User
{
    class TG_DbContext : DbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<SqlMsg> sqlMsg { get; set; }

        /// <summary>
        /// Context to use the db the Connection string is defined in the app.config prop TGDB 
        /// </summary>
        public TG_DbContext() : base(Properties.Settings.Default.TGDB)
        {

        }

        /// <summary>
        /// here is where we map the entity with the table
        /// </summary>
        /// <param name="modelbuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>()
               .ToTable("TG_User");
        }
    }
}
