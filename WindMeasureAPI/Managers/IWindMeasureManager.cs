using System.Collections.Generic;
using WindMeasureAPI.Models;

namespace WindMeasureAPI.Managers
{
    public interface IWindMeasureManager
    {
        WindMeasureData Add(WindMeasureData newMeasure);
        IEnumerable<WindMeasureData> GetAll(int minimumSpeed);
    }
}