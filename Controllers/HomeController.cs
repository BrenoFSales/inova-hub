using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet2.Models;
using Microsoft.EntityFrameworkCore;
// using System.Web.Helpers;

namespace aspnet2.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController : Controller
{
    private readonly MyDbContext db;

    public HomeController(MyDbContext _db)
    {
        db = _db;

    }

    [Route("")]
    public IActionResult Index() {
        // seleciona cada ideia + upvotes correspondentes
        // https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/join-operations#group-join
        var query = (from i in db.Ideas
            join u in db.Upvotes on i.Id equals u.IdIdea into Upvotes
            select new {
                Idea = i,
                Upvotes = Upvotes.ToList(),
            });

        ViewBag.Ideas = query.ToList();

        return View();
    }

    [Route("Idea/{id?}")]
    public IActionResult Idea(int? id) {
        var query = db.Ideas.Where(x => x.Id == id).Single();

        ViewBag.Idea = query;
        ViewBag.Title = query.Title;
       
        return View();
    }

    [Route("Cadastro")]
    public IActionResult Cadastro() {
        return View();
    }

    // [Route("json")]
    // public String Json() {
    //     return System.Web.
    // }

    [Route("Contacts")]
    public IActionResult Contacts()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // TODO: melhorar isso daqui, t� feio e � usual s� por enquanto
    [Route("VerificarLogin")]
    public async Task<IActionResult> VerificarLogin(string login, string pass)
    {
        var isValid = false;
        var dataFromContext = await db.Users.ToListAsync();
        foreach (var data in dataFromContext)
        {
            // fazer isso daqui usando linq
            if ((data.Name == login && data.Password == pass) || (data.Email == login && data.Password == pass) ) 
            {
                isValid = true;
                break;
            }    
        }
        return Content($"{isValid}");

    }
}
