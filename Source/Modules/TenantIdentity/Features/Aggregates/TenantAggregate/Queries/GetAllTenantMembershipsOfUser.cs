﻿using Microsoft.EntityFrameworkCore;
using Modules.TenantIdentity.Features.Infrastructure.EFCore;
using Modules.TenantIdentity.Web.Shared.DTOs.Aggregates.Tenant;
using Shared.Features.CQRS.Query;
using System.Threading;

namespace Modules.TenantIdentity.Features.Aggregates.TenantAggregate.Queries
{
    public class GetAllTenantMembershipsOfUser : IQuery<List<TenantMembershipDTO>>
    {
        public Guid UserId { get; set; }
    }
    public class GetAllTenantMembershipsOfUserQueryHandler : IQueryHandler<GetAllTenantMembershipsOfUser, List<TenantMembershipDTO>>
    {
        private readonly TenantIdentityDbContext tenantIdentityDbContext;
        public GetAllTenantMembershipsOfUserQueryHandler(TenantIdentityDbContext tenantIdentityDbContext)
        {
            this.tenantIdentityDbContext = tenantIdentityDbContext;
        }

        public async Task<List<TenantMembershipDTO>> HandleAsync(GetAllTenantMembershipsOfUser query, CancellationToken cancellation)
        {
            var tenantMemberships = await tenantIdentityDbContext.TenantMeberships.Where(tm => tm.UserId == query.UserId).ToListAsync();
            return tenantMemberships.Select(tm => tm.ToDTO()).ToList();
        }
    }
}
