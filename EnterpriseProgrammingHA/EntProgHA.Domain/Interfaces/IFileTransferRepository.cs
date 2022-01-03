using EntProgHA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Domain.Interfaces
{
    public interface IFileTransferRepository
    {
        IEnumerable<FileTransfer> GetFileTransfers();
    }
}
