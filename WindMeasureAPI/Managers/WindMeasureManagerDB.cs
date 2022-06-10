using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindMeasureAPI.Models;

namespace WindMeasureAPI.Managers
{
    public class WindMeasureManagerDB : IWindMeasureManager
    {
        private WindMeasureContext _context;

        public WindMeasureManagerDB(WindMeasureContext context)
        {
            _context = context;
        }

        public WindMeasureData Add(WindMeasureData newMeasure)
        {
            newMeasure.Id = 0;
            _context.Add(newMeasure);
            _context.SaveChanges();
            return newMeasure;
        }

        public IEnumerable<WindMeasureData> GetAll(int minimumSpeed)
        {

            return from measurement in _context.Measurements
                   where (minimumSpeed == 0 || measurement.WindSpeed >= minimumSpeed)
                   select measurement;
        }
    }
}
