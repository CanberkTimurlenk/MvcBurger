using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBurger.Persistance.Configurations
{
    public class UsersWithRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            
        }
    }
}
