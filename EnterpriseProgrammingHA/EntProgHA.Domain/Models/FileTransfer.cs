using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Domain.Models
{
    public class FileTransfer
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; }
        public string RecieverEmail { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
    }
}
