using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using brightskills.Data;
using brightskills.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace brightskills.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
    private readonly ILogger<AdminController> _logger;
    private readonly AppDbContext _context;

    public AdminController(ILogger<AdminController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

     

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            _logger.LogInformation("Dashboard Requsted");
            return View();
        }

        [HttpGet]
        [Route("ManageCourses")]
        public IActionResult ManageCourses()
        {
            return View();
        }

        [HttpGet]
        [Route("ManageSessions")]
        public IActionResult ManageSessions()
        {
            return View();
        }

        [HttpGet]
        [Route("ManageUsers")]
        public IActionResult ManageUsers()
        {
            return View();
        }

        [HttpGet]
        [Route("Reports")]
        public IActionResult Reports()
        {
            return View();
        }
        [HttpGet]
         [Route("Settings")]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        public   IActionResult AddCourse()
        {
            var CourseList=_context.tbl_course_list.ToList();
            return View(CourseList);
            
        }
       
       [HttpPost]
       [Route("AddCourse")]
       public async Task<IActionResult> AddCourseIn( AddCourseModel acmodel ){

            if(ModelState.IsValid){


                var courselist=new AddCourseModel{

                    course_name=acmodel.course_name,
                    course_description=acmodel.course_description,
                    course_duration=acmodel.course_duration,
                    trainer_name=acmodel.trainer_name,

                };

                _context.tbl_course_list.Add(courselist);

                await _context.SaveChangesAsync();
               
               _logger.LogInformation("Course detail has been submitted successfully");
               
               var UpdatedCourseList=_context.tbl_course_list.ToList();
               return View("AddCourse",UpdatedCourseList);
               


            }
            else{
                return View(acmodel) ; 
            }
            
       }

        [HttpGet]
        [Route("DeleteCourse/{CourseID}")]
          public IActionResult DeleteCourse(int CourseID)
        {
            var selectedcourse=_context.tbl_course_list.Find(CourseID);

            if(selectedcourse==null)
            {
                return NotFound();
            }

            _context.tbl_course_list.Remove(selectedcourse);
            _context.SaveChanges();

            var UpdatedCourseList1=_context.tbl_course_list.ToList();
            return RedirectToAction("AddCourse","Admin",UpdatedCourseList1);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}