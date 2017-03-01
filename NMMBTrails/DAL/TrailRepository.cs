using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NMMBTrails.Models;

namespace NMMBTrails.DAL
{
    public class TrailRepository : ITrailRepository, IDisposable
    {
        private List<Trail> _trails;

        public TrailRepository()
        {
            _trails = HttpContext.Current.Session["Trails"] as List<Trail>;
        }

        public IEnumerable<Trail> SelectAll()
        {
            Save();
            return _trails;
        }

        public Trail SelectOne(int id)
        {
            Trail selectedTraill = _trails.Where(t => t.Id == id).FirstOrDefault();
            return selectedTraill;
        }

        public void Insert (Trail trail)
        {
            Save();
            _trails.Add(trail);
        }

        public void Update(Trail updatedTrail)
        {
            var oldTrail = _trails.Where(t => t.Id == updatedTrail.Id).FirstOrDefault();

            if (oldTrail != null)
            {
                _trails.Remove(oldTrail);
                _trails.Add(updatedTrail);
            }

            Save();
        }

        public void Delete(int id)
        {
            var trail = _trails.Where(t => t.Id == id).FirstOrDefault();
            if (trail != null)
            {
                _trails.Remove(trail);
            }

            Save();
        }

        public void Save()
        {
            //JSONDataService js = new JSONDataService();
            XMLDataService xml = new XMLDataService();
            xml.Write(_trails);
        }

        public void Dispose()
        {
            _trails = null;
        }
    }
}