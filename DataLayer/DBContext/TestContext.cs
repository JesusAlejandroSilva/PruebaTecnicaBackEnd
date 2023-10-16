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

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


        public static TestContext Create()
        {
            if(testContext == null)
                testContext = new TestContext();
            

            return new TestContext();
        }

    }
}
