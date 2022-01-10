using EntProgHA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Domain.Interfaces
{
    public interface IFileTransferRepository
    {
        public IEnumerable<FileTransfer> GetFileTransfers();

        public void AddFileTransfer(FileTransfer ft);
    }
}
