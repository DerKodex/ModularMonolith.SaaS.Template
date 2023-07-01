﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.TenantIdentity.DomainFeatures.Infrastructure.Configuration
{
    public class TenantIdentityConfigurationValidator : IValidateOptions<TenantIdentityConfiguration>
    {
        public ValidateOptionsResult Validate(string name, TenantIdentityConfiguration tenantIdentityConfiguration)
        {
            if (string.IsNullOrEmpty(tenantIdentityConfiguration.GoogleClientId))
            {
                return ValidateOptionsResult.Fail("");
            }

            if (string.IsNullOrEmpty(tenantIdentityConfiguration.MicrosoftClientId))
            {
                return ValidateOptionsResult.Fail("");
            }

            if (string.IsNullOrEmpty(tenantIdentityConfiguration.GoogleClientSecret))
            {
                return ValidateOptionsResult.Fail("");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
