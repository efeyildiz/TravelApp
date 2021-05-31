using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Repository.Abstract
{
    public interface ISehirRepository
    {
        Sehir GetByID(int sehirId);
        IQueryable<Sehir> GetAll();
        void AddSehir(Sehir entity);
        void UpdateSehir(Sehir entity);
        void DeleteSehir(int sehirId);
        void SaveSehir(Sehir entity);
    }
}
