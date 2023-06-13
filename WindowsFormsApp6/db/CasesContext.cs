using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp6.db
{
    class CasesContext : System.Data.Entity.DbContext
    {
      /*  protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data source = cases.db");
        }public CasesContext(DbContextOptions<CasesContext> contextOptions) : base(contextOptions) 
        {

        }
      */
      protected  void OnConfiguring(DbContextOptionsBuilder builder) 
        {
            builder.UseSqlite("Data source= Casesfile.db");
        }
        public System.Data.Entity.DbSet<Cases> Cases { get; set; }
    }
}
