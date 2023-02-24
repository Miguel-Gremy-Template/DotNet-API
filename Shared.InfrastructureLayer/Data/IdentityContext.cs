﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Entities.Identity;

namespace Shared.Infrastructure.Data
{
	public class IdentityContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(Shared.Infrastructure.Marker).Assembly);
		}
	}
}