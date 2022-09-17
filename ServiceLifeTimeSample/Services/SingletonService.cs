using ServiceLifeTimeSample.Contracts;
using System;

namespace ServiceLifeTimeSample.Services
{
    public class SingletonService : ISingletonService
    {
        private readonly Guid Id;

        public SingletonService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}
