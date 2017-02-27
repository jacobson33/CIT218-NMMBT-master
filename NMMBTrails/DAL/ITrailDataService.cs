using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMMBTrails.Models;

namespace NMMBTrails.DAL
{
    public interface ITrailDataService
    {
        IEnumerable<Trail> Read();
        void Write(IEnumerable<Trail> trails);
    }
}
