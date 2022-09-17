using ServiceLifeTimeSample.Contracts;
using System;

namespace ServiceLifeTimeSample.Services
{
    public class ScopedService : IScopedService
    {
        private readonly Guid Id;

        public ScopedService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}
