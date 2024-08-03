using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tentativa1.Models;
using tentativa1.Data;

namespace tentativa1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class infoWebsiteController : ControllerBase
    {
        private readonly apiContext _context;

        public infoWebsiteController(apiContext context)
        {
            _context = context;
        }

        //create/edit
        [HttpPost]
        public JsonResult CreateEdit(InfoWebsite infoWebsite)
        {
            if (infoWebsite.Id == 0)
            {
                _context.InformacaoWeb.Add(infoWebsite);
            }
            else
            { 

                _context.InformacaoWeb.Update(infoWebsite);
        
            }
            _context.SaveChanges();
            return new JsonResult(Ok(infoWebsite));
        }

        [HttpGet]
        public JsonResult Get(int id) 
        {
            var result = _context.InformacaoWeb.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult Delete(int id) 
        {
            var result = _context.InformacaoWeb.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            _context.InformacaoWeb.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet("/All")]
        public JsonResult GetAll(string id) 
        { 
            var result = _context.InformacaoWeb.ToList();
            return new JsonResult(Ok(result));
        }
    }
}
