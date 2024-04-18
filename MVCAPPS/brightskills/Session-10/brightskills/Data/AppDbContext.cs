using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using brightskills.Models;
using Microsoft.EntityFrameworkCore;

namespace brightskills.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }

        public DbSet<AddCourseModel> tbl_course_list {get; set;}
        public DbSet<LoginModel> tbl_login {get; set;}
        public DbSet<RegisterModel> tbl_reg_users {get; set;}


        
    }
}