using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntProgHA.Application.ViewModels
{
    public class AddFileTransferViewModel
    {
        [Required]
        public string SenderEmail { get; set; }
        [Required]
        public string RecieverEmail { get; set; }
        [Required]
        public string Title { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
        public string FileUrl { get; set; }

    }
}
