using EntProgHA.Application.Interfaces;
using EntProgHA.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntProgHA.Mvc.Controllers
{
    [Authorize]
    public class FileTransferController : Controller
    {

        private IFileTransferService _fileTransferService;
        public FileTransferController(IFileTransferService fileTransferService)
        {
            _fileTransferService = fileTransferService;
        }

        public IActionResult Index()
        {
            FileTransferViewModel model = _fileTransferService.GetFileTransfers();

            return View(model);
        }

    }
}
