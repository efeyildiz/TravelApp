using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Repository.Concrete
{
    public class EfOtelRepository : IOtelRepository
    {
        private TravelContext context;

        public EfOtelRepository(TravelContext _context)
        {
            context = _context;
        }

        public void AddOtel(Otel entity)
        {
            context.Otels.Add(entity);
            context.SaveChanges();
        }

        public void DeleteOtel(int otelId)
        {
            var otel = context.Otels.FirstOrDefault(p => p.OtelId == otelId);
            if (otel != null)
            {
                context.Otels.Remove(otel);
                context.SaveChanges();
            }
        }

        public IQueryable<Otel> GetAll()
        {
            return context.Otels;
        }

        public Otel GetByID(int otelId)
        {
            return context.Otels.FirstOrDefault(p => p.OtelId == otelId);
        }

        public void SaveOtel(Otel entity)
        {
            if (entity.OtelId == 0)
            {
                context.Otels.Add(entity);
            }
            else
            {
                var otel = GetByID(entity.OtelId);
                if (otel != null)
                {
                    otel.otelAd = entity.otelAd;
                    otel.otelTel = entity.otelTel;
                    otel.otelAdres = entity.otelAdres;
                    otel.otelImage = entity.otelImage;
                    otel.otelAciklama = entity.otelAciklama;
                    otel.otelPuan = entity.otelPuan;
                    otel.SehirId = entity.SehirId;
                }
            }
            context.SaveChanges();
        }

        public void UpdateOtel(Otel entity)
        {
            var otel = GetByID(entity.OtelId);

            if (otel!= null)
            {
                otel.otelAciklama = entity.otelAciklama;
                otel.otelAd = entity.otelAd;
                otel.otelAdres = entity.otelAdres;
                otel.otelImage = entity.otelImage;
                otel.otelPuan = entity.otelPuan;
                otel.otelTel = entity.otelTel;
                otel.SehirId = entity.SehirId;

                context.SaveChanges();
            }
            context.SaveChanges();
        }
    }
}
