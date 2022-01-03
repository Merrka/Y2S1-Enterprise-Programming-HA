using EntProgHA.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Application.Interfaces
{
    public interface IFileTransferService
    {
        FileTransferViewModel GetFileTransfers();
    }
}
