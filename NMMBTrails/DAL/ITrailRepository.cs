using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMMBTrails.Models;

namespace NMMBTrails.DAL
{
    public interface ITrailRepository
    {
        IEnumerable<Trail> SelectAll();
        Trail SelectOne(int id);
        void Insert(Trail trail);
        void Update(Trail trail);
        void Delete(int id);
    }
}
