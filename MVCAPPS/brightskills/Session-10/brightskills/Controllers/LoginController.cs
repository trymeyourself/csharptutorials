using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using brightskills.Models;
using Microsoft.Data.SqlClient;
using brightskills.Data;

namespace brightskills.Controllers;

public class LoginController : Controller
{




     
    private readonly ILogger<LoginController> _logger;

    private readonly AppDbContext _context;

    public LoginController(ILogger<LoginController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Aboutus()
    {
        return View();
    }

    public IActionResult Contactus()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }






    [HttpPost]
    public IActionResult VerifyLogin(LoginModel lmodel)
    {

        var user = _context.tbl_login.FirstOrDefault(u => u.username == lmodel.username && u.password == lmodel.password);


        if (user != null)
        {


            if (user.jobrole == "trainer")

            {

                return RedirectToAction("Dashboard", "Trainer");
            }
            else if (user.jobrole == "admin")
            {

                return RedirectToAction("Dashboard", "Admin");
            }

            else
            {
                return View(lmodel);

            }

        }

        else
        {

            var user1 = _context.tbl_reg_users.FirstOrDefault(u => u.UserName == lmodel.username && u.Password == lmodel.password);
            if (user1 != null)
            {
                return RedirectToAction("Dashboard", "Trainee");
            }
            else
            {
                return View(lmodel);
            }
        }



    }




    [HttpGet]
     public IActionResult Register()
    {
        var coursenames=_context.tbl_course_list.ToList();
        return View(coursenames);
    }


    
    [HttpPost]
     public IActionResult RegisterDB(RegisterModel rmodel)
    {   
      
       
       if(ModelState.IsValid)
       {
        var userlist=new RegisterModel{
            FullName=rmodel.FullName,
            UserName=rmodel.UserName,
            Email=rmodel.Email,
            ContactNumber=rmodel.ContactNumber,
            Password=rmodel.Password,
            selected_course=rmodel.selected_course
        };

        _context.tbl_reg_users.Add(userlist);
        _context.SaveChanges();
        return View("Login");

       }
       else
       {
        return View(rmodel);
       }


            
    }


    public IActionResult Services()
    {
        return View();
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
