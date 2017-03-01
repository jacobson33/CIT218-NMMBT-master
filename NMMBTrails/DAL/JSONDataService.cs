using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using NMMBTrails.Models;

namespace NMMBTrails.DAL
{
    public class JSONDataService : ITrailDataService
    {
        public List<Trail> Read()      {



            return new List<Trail>();
        }

        public void Write(List<Trail> trails)
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\jacobs33\\Source\\Repos\\CIT218-NMMBT-master\\NMMBTrails\\App_Data", false);

                JavaScriptSerializer js = new JavaScriptSerializer();

                string jsonData = js.Serialize(trails);

                using (sw)
                {
                    sw.Write(jsonData);
                }
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}