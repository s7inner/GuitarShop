using ElibraryManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ElibraryManagement.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() :
            base("con")
        { }

        public DbSet<guitar_master_tbl> guitar_master_tbls { get; set; }
        public DbSet<guitar_fav_master_tbl> guitar_fav_master_tbls { get; set; }

    }
}