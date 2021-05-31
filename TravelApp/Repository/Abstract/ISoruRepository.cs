using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Repository.Abstract
{
    public interface ISoruRepository
    {
        Soru GetByID(int soruId);
        IQueryable<Soru> GetAll();
        void AddSoru(Soru entity);
        void UpdateSoru(Soru entity);
        void DeleteSoru(int soruId);
        void SaveSoru(Soru entity);
    }
}
