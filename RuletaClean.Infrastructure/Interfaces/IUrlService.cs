using RuletaClean.Core.QueryFilters;
using System;

namespace RuletaClean.Infrastructure.Interfaces
{
    public interface IUrlService
    {
        Uri getPostPaginationUrl(BetQueryFilter filter, string actionUrl);
    }
}