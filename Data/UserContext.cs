using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeAlkemy.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChallengeAlkemy.Data
{
    public class UserContext : IdentityDbContext<User>
    {
        private const string Schema = "users";
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
        }
    }
}

