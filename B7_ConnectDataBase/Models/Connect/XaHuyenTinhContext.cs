using System;
using System.IO;
using B7_ConnectDataBase.Models.EF;
using B7_ConnectDataBase.Models.TypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace B7_ConnectDataBase.Models.Connect
{
    public partial class XaHuyenTinhContext : DbContext
    {
        public XaHuyenTinhContext()
        {
        }

        public XaHuyenTinhContext(DbContextOptions<XaHuyenTinhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Huyen> Huyen { get; set; }
        public virtual DbSet<Tinh> Tinh { get; set; }
        public virtual DbSet<Xa> Xa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();
                var connectionString = configuration.GetConnectionString("ConnectDatabaseContextString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TinhType());
            modelBuilder.ApplyConfiguration(new HuyenType());
            modelBuilder.ApplyConfiguration(new XaType());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
