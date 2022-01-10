using EntProgHA.Application.Interfaces;
using EntProgHA.Application.Services;
using EntProgHA.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace EntProgHA.Mvc.Controllers
{
    [Authorize]
    public class FileTransferController : Controller
    {

        private IFileTransferService _fileTransferService;
        private IWebHostEnvironment _hostEnv;
        public FileTransferController(IFileTransferService fileTransferService, IWebHostEnvironment hostEnv)
        {
            _fileTransferService = fileTransferService;
            _hostEnv = hostEnv;
        }

        public IActionResult Index()
        {
            FileTransferViewModel model = _fileTransferService.GetFileTransfers();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.FileTransfer = _fileTransferService.GetFileTransfers();
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddFileTransferViewModel model, IFormFile File)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (File != null)
                    {
                        string newFilename = Guid.NewGuid() + Path.GetExtension(File.FileName);
                        string absolutePath = _hostEnv.WebRootPath + "\\files";
                        string absolutePathWithFilename = absolutePath + "\\" + newFilename;
                        model.FileUrl = newFilename;

                        using (FileStream fs = new FileStream(absolutePathWithFilename, FileMode.CreateNew, FileAccess.Write))
                        {
                            File.CopyTo(fs);
                            fs.Close();
                        }

                        //SendSimpleMessage();
                        //Console.WriteLine(SendSimpleMessage().Content.ToString());
                    }


                    _fileTransferService.AddFileTransfer(model);
                    ViewBag.Message = "FileTransfer added successfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "FileTransfer wasn't added successfully";
            }
            return View(model);
        }
        //create new method for mailgun code
        /*public static IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3/sandbox93754b4e116544abb2b65d3c43d8ec6a.mailgun.org");
            client.Authenticator = new HttpBasicAuthenticator("api", "68502337aeb36f964dd1a090996d8ca2-76f111c4-ed598f2c");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox93754b4e116544abb2b65d3c43d8ec6a.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "admin@merrka.com");
            request.AddParameter("to", "attard.kurt.2001@gmail.com");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.Method = Method.POST;
            return client.Execute(request);
        }*/


    }
}
