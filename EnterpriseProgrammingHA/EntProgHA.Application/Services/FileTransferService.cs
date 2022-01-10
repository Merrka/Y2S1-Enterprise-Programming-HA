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
        public void AddFileTransfer(AddFileTransferViewModel model)
        {
            _fileTransferRepository.AddFileTransfer(
                new Domain.Models.FileTransfer()
                {
                    SenderEmail = model.SenderEmail,
                    RecieverEmail = model.RecieverEmail,
                    Title = model.Title,
                    Message = model.Message,
                    Password = model.Password,
                    FileUrl = model.FileUrl

                });
        }
    }
}
