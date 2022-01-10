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
                        //1. to generate a new unique filename
                        //5389205C-813B-4AFA-A453-B912C30BF933.jpg
                        string newFilename = Guid.NewGuid() + Path.GetExtension(File.FileName);

                        //2. find what the absolute path to the folder Files is
                        //C:\Users\attar\Source\Repos\SWD62BEP2021v2\Presentation\Files\5389205C-813B-4AFA-A453-B912C30BF933.jpg

                        //hostEnv.ContentRootPath : C:\Users\attar\Source\Repos\SWD62BEP2021v2\Presentation
                        //hostEnv.WebRootPath:  C:\Users\attar\Source\Repos\SWD62BEP2021v2\Presentation\wwwroot

                        string absolutePath = _hostEnv.WebRootPath + "\\Files";
                        string absolutePathWithFilename = absolutePath + "\\" + newFilename;
                        model.FileUrl = "\\Files\\" + newFilename;
                        //3. do the transfer/saving of the actual physical file

                        using (FileStream fs = new FileStream(absolutePathWithFilename, FileMode.CreateNew, FileAccess.Write))
                        {
                            File.CopyTo(fs);
                            fs.Close();
                        }
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



    }
}
