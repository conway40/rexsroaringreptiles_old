using Demo_Nmm_Xml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Nmm_Xml.DAL
{
    public interface IBreweryRepository
    {
        IEnumerable<Brewery> SelectAll();
        Brewery SelectOne(int id);
        void Insert(Brewery brewery);
        void Update(Brewery brewery);
        void Delete(int id);
    }
}