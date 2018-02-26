using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reptiles_Xml.Models;

namespace Reptiles_Xml.DAL
{
    public interface IReptileRepository
    {
        IEnumerable<Reptile> SelectAll();
        Reptile SelectOne(int id);
        void Insert(Reptile reptile);
        void Update(Reptile reptile);
        void Delete(int id);
    }
}
