using EntProgHA.Application.Interfaces;
using EntProgHA.Application.ViewModels;
using EntProgHA.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Application.Services
{
    public class FileTransferService : IFileTransferService
    {
        private IFileTransferRepository _fileTransferRepository;

        public FileTransferService(IFileTransferRepository fileTransferRepository)
        {
            _fileTransferRepository = fileTransferRepository;
        }
        public FileTransferViewModel GetFileTransfers()
        {
            return new FileTransferViewModel()
            {
                FileTransfers = _fileTransferRepository.GetFileTransfers()
            };
        }
    }
}
