using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AceAmazingRace.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        public ActionResult Index(HttpPostedFileBase file)  
        {  
            if (file != null && file.ContentLength > 0)  
                try 
                {  

                    var target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();

                    string path = Path.Combine(Server.MapPath("~/Images"),  
                                               Path.GetFileName(file.FileName));  
                    file.SaveAs(path);  
                    ViewBag.Message = "File uploaded successfully";  
                }  
                catch (Exception ex)  
                {  
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();  
                }  
            else 
            {  
                ViewBag.Message = "You have not specified a file.";  
            }  
            return View();  
}
    }
}