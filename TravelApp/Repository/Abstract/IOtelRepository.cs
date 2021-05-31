using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Repository.Abstract
{
    public interface IOtelRepository
    {
        Otel GetByID(int otelId);
        IQueryable<Otel> GetAll();
        void AddOtel(Otel entity);
        void UpdateOtel(Otel entity);
        void SaveOtel(Otel entity);
        void DeleteOtel(int otelId);
    }
}
