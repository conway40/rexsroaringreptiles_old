using Demo_Nmm_Xml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Nmm_Xml.DAL
{
    /// <summary>
    /// data service interface to read and write an entire file based on the Brewery class
    /// </summary>
    public interface IBreweryDataService
    {
        List<Brewery> Read();
        void Write(List<Brewery> Breweries);
    }
}