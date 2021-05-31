using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelApp.Models;
using TravelApp.Repository.Abstract;

namespace TravelApp.Repository.Concrete
{
    public class EfSoruRepository : ISoruRepository
    {
        private TravelContext context;

        public EfSoruRepository(TravelContext _context)
        {
            context = _context;
        }

        public void AddSoru(Soru entity)
        {
            context.Sorus.Add(entity);
            context.SaveChanges();
        }

        public void DeleteSoru(int soruId)
        {
            var soru = context.Sorus.FirstOrDefault(p => p.SoruId == soruId);
            if (soru != null)
            {
                context.Sorus.Remove(soru);
                context.SaveChanges();
            }
        }

        public IQueryable<Soru> GetAll()
        {
            return context.Sorus;
        }

        public Soru GetByID(int soruId)
        {
            return context.Sorus.FirstOrDefault(p => p.SoruId == soruId);
        }

        public void SaveSoru(Soru entity)
        {
            if (entity.SoruId == 0)
            {

                context.Sorus.Add(entity);
            }
            else
            {
                var soru = GetByID(entity.SoruId);

                if (soru != null)
                {
                    soru.soruTittle = entity.soruTittle;
                    soru.soruBody = entity.soruBody;
                    soru.Cevap = entity.Cevap;
                }
            }
            context.SaveChanges();
        }

        public void UpdateSoru(Soru entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
