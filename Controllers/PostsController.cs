using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Utils;
using mvc.ViewModel;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class PostsController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var service = new Service();

            var posts = await service.GetAll();

            return View(new PostViewModel{Posts = posts});
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
