﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Attributes;
using Shared.Core.Configuration;

namespace API.Configuration
{
	[ConfigOrder(0)]
	public class ServiceInstaller_Localization : IServiceInstaller
	{
		public void Configure(IServiceCollection services, IConfiguration configuration)
		{
			services.AddLocalization(opt =>
			{

			});
		}
	}
}
