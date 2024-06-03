﻿using Bigon.Infrastructure.Commons.Abstracts;
using Bigon.Infrastructure.Entites;
using Bigon.Infrastructure.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Data
{
    public class DataContext:DbContext
    {
        private readonly IDateTimeServive _dateTimeServive;
        private readonly IIdentityService _identityService;

        public DataContext(DbContextOptions options,
            IDateTimeServive dateTimeServive,
            IIdentityService identityService
            ):base(options)
        {
            _dateTimeServive = dateTimeServive;
            _identityService = identityService;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override int SaveChanges()
        {
            var changes =this.ChangeTracker.Entries<IAuditableEntity>();
            if(changes !=null)
            {
                foreach (var entity in changes
                    .Where(ch => ch.State == EntityState.Added ||
                    ch.State ==EntityState.Deleted || 
                    ch.State ==EntityState.Modified))
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            entity.Entity.CreatedBy = _identityService.GetPrincicipialId();
                            entity.Entity.CreatedAt = _dateTimeServive.ExecutingTime;
                            break;
                       
                        case EntityState.Modified:
                            entity.Entity.ModifiedBy = _identityService.GetPrincicipialId() ;
                            entity.Entity.ModifiedAt = _dateTimeServive.ExecutingTime;
                            break;
                        case EntityState.Deleted:
                            entity.State = EntityState.Modified;
                            entity.Entity.DeletedBy = _identityService.GetPrincicipialId();
                            entity.Entity.DeletedAt = _dateTimeServive.ExecutingTime;
                            break;


                        default:
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }







    }
}
