using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model;

namespace DAL.Base
{
    public class DBEntities : DbContext
    {
        public DBEntities()
           : base("name=DBEntities")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //解决EF动态建库数据库表名变为复数问题
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<User> User { get; set; }

        public DbSet<UserRole> UserRole { get; set; }
    }
}
