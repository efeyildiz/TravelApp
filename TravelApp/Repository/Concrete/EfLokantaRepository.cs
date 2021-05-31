using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Repository.Concrete
{
    public class EfLokantaRepository : ILokantaRepository
    {
        private TravelContext context;

        public EfLokantaRepository(TravelContext _context)
        {
            context = _context;
        }

        public void AddLokanta(Lokanta entity)
        {
            context.Lokantas.Add(entity);
            context.SaveChanges();
        }

        public void DeleteLokanta(int lokantaId)
        {
            var lokanta = context.Lokantas.FirstOrDefault(p => p.LokantaId == lokantaId);
            if (lokanta != null)
            {
                context.Lokantas.Remove(lokanta);
                context.SaveChanges();
            }
        }

        public IQueryable<Lokanta> GetAll()
        {
            return context.Lokantas;
        }

        public Lokanta GetByID(int lokantaId)
        {
            return context.Lokantas.FirstOrDefault(p => p.LokantaId == lokantaId);
        }

        public void SaveLokanta(Lokanta entity)
        {
            if (entity.LokantaId == 0)
            {
                context.Lokantas.Add(entity);
            }
            else
            {
                var lokanta = GetByID(entity.LokantaId);

                if (lokanta != null)
                {
                    lokanta.lokantaAd = entity.lokantaAd;
                    lokanta.lokantaTel = entity.lokantaTel;
                    lokanta.lokantaPuan = entity.lokantaPuan;
                    lokanta.lokantaAdres = entity.lokantaAdres;
                    lokanta.lokantaAciklama = entity.lokantaAciklama;
                    lokanta.lokantaImage = entity.lokantaImage;
                    lokanta.SehirId = entity.SehirId;

                }
            }
            context.SaveChanges();
        }

        public void UpdateLokanta(Lokanta entity)
        {
            var lokanta = GetByID(entity.LokantaId);

            if (lokanta != null)
            {
                lokanta.lokantaAd = entity.lokantaAd;
                lokanta.lokantaTel = entity.lokantaTel;
                lokanta.lokantaPuan = entity.lokantaPuan;
                lokanta.lokantaAdres = entity.lokantaAdres;
                lokanta.lokantaAciklama = entity.lokantaAciklama;
                lokanta.lokantaImage = entity.lokantaImage;
                lokanta.SehirId = entity.SehirId;

                context.SaveChanges();
            }
            context.SaveChanges();
        }
    }
}
