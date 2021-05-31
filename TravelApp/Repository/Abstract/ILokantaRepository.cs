using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;

namespace TravelApp.Repository.Abstract
{
    public interface ILokantaRepository
    {
        Lokanta GetByID(int lokantaId);
        IQueryable<Lokanta> GetAll();
        void AddLokanta(Lokanta entity);
        void UpdateLokanta(Lokanta entity);
        void SaveLokanta(Lokanta entity);
        void DeleteLokanta(int lokantaId);
    }
}
