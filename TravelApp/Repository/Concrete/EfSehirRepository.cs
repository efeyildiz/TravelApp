using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Repository.Concrete
{
    public class EfSehirRepository : ISehirRepository
    {
        private TravelContext context;

        public EfSehirRepository(TravelContext _context)
        {
            context = _context;
        }

        public void AddSehir(Sehir entity)
        {
            context.Sehirs.Add(entity);
            context.SaveChanges();
        }

        public void DeleteSehir(int sehirId)
        {
            var sehir = context.Sehirs.FirstOrDefault(p => p.SehirId == sehirId);
            if (sehir != null)
            {
                context.Sehirs.Remove(sehir);
                context.SaveChanges();
            }
        }

        public IQueryable<Sehir> GetAll()
        {
            return context.Sehirs;
        }

        public Sehir GetByID(int sehirId)
        {
            return context.Sehirs.FirstOrDefault(p => p.SehirId == sehirId);
        }

        public void SaveSehir(Sehir entity)
        {
            if (entity.SehirId == 0)
            {
                context.Sehirs.Add(entity);
            }
            else
            {
                var sehir = GetByID(entity.SehirId);

                if (sehir != null)
                {
                    sehir.sehirAd = entity.sehirAd;
                    sehir.Plaka = entity.Plaka;
                }  
            }
            context.SaveChanges();
        }

        public void UpdateSehir(Sehir entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
