using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactManagementService.Model;

    public class ContactManagementServiceContext : DbContext
    {
        public ContactManagementServiceContext (DbContextOptions<ContactManagementServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ContactManagementService.Model.ContactDetails> ContactDetails { get; set; } = default!;
    }
