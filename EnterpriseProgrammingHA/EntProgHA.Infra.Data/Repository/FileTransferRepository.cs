using EntProgHA.Domain.Interfaces;
using EntProgHA.Domain.Models;
using EntProgHA.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Infra.Data.Repository
{
    public class FileTransferRepository : IFileTransferRepository
    {
        private FileTransferDBContext _ctx;

        public FileTransferRepository(FileTransferDBContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<FileTransfer> GetFileTransfers()
        {
            return _ctx.FileTransfers;
        }
    }
}
