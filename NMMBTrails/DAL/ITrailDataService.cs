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
        List<Trail> Read();
        void Write(List<Trail> trails);
    }
}
