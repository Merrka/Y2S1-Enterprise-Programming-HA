﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntProgHA.Domain.Models
{
    public class FileTransfer
    {
        [Key]
        public int Id { get; set; }
        public string SenderEmail { get; set; }
        public string RecieverEmail { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Password { get; set; }
        public string FileUrl { get; set; }
    }
}
