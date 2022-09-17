using ServiceLifeTimeSample.Contracts;
using System;

namespace ServiceLifeTimeSample.Services
{
    public class TransientService : ITransientService
    {
        private readonly Guid Id;

        public TransientService()
        {
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}
