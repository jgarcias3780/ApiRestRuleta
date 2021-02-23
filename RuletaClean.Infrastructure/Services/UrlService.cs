using RuletaClean.Core.QueryFilters;
using RuletaClean.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuletaClean.Infrastructure.Services
{
    public class UrlService : IUrlService
    {
        private readonly string _baseUrl;
        public UrlService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public Uri getPostPaginationUrl(BetQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUrl}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
