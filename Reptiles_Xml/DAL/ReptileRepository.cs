using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reptiles_Xml.Models;

namespace Reptiles_Xml.DAL
{
    public class ReptileRepository : IReptileRepository, IDisposable
    {
        private List<Reptile> _reptiles;

        public ReptileRepository()
        {
            ReptileXmlDataService reptileXmlDataService = new ReptileXmlDataService();
            
            using (reptileXmlDataService)
            {
                _reptiles = reptileXmlDataService.Read() as List<Reptile>;
            }
        }

        public IEnumerable<Reptile> SelectAll()
        {
            return _reptiles;
        }

        public Reptile SelectOne(int id)
        {
            Reptile selectedReptile = _reptiles.Where(p => p.Id == id).FirstOrDefault();

            return selectedReptile;
        }

        public void Insert(Reptile reptile)
        {
            reptile.Id = NextIdValue();
            _reptiles.Add(reptile);

            Save();
        }

        private int NextIdValue()
        {
            int currentMaxId = _reptiles.OrderByDescending(b => b.Id).FirstOrDefault().Id;
            return currentMaxId + 1;
        }

        public void Update(Reptile UpdateReptile)
        {
            var oldReptile = _reptiles.Where(b => b.Id == UpdateReptile.Id).FirstOrDefault();

            if (oldReptile != null)
            {
                _reptiles.Remove(oldReptile);
                _reptiles.Add(UpdateReptile);
            }

            Save();
        }

        public void Delete(int id)
        {
            var reptile = _reptiles.Where(b => b.Id == id).FirstOrDefault();

            if (reptile != null)
            {
                _reptiles.Remove(reptile);
            }

            Save();
        }

        public void Save()
        {
            ReptileXmlDataService reptileXmlDataService = new ReptileXmlDataService();

            using (reptileXmlDataService)
            {
                reptileXmlDataService.Write(_reptiles);
            }
        }

        public void Dispose()
        {
            _reptiles = null;
        }
    }
}