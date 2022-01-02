using EntProgHA.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntProgHA.Infra.Data.Context
{
    public class FileTransferDBContext : DbContext
    {
        public FileTransferDBContext(DbContextOptions options) : base(options)
        { }
          
        public DbSet<FileTransfer> FileTransfers { get; set; }
    }
}
