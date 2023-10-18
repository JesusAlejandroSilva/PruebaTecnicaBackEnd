using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntitiesLayer.Models;
using static System.Net.Mime.MediaTypeNames;

namespace DataLayer.DBContext
{
    public class TestContext : DbContext
    {
        private static TestContext testContext = null;

        public TestContext()
            : base("TestContext")
        {

        }

        public DbSet<Deportistas> Deportistas { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Registros> Registros { get; set; }


        public static TestContext Create()
        {
            if(testContext == null)
                testContext = new TestContext();
            

            return new TestContext();
        }

    }
}
