using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reptiles_Xml.Models;

namespace Reptiles_Xml.DAL
{
    /// <summary>
    /// data service interface to read and write an entire file based on the Reptile class
    /// </summary>
    public interface IReptileDataServices
    {
        List<Reptile> Read();
        void Write(List<Reptile> Reptiles);
    }
}
