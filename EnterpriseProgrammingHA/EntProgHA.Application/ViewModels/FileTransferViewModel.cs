using EntProgHA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Application.ViewModels
{
    public class FileTransferViewModel
    {
        public IEnumerable<FileTransfer> FileTransfers { get; set; }
    }
}
