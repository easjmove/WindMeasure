using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindMeasureAPI.Models;

namespace WindMeasureAPI.Managers
{
    public class WindMeasureManager : IWindMeasureManager
    {
        private static int _nextId = 1;
        private static List<WindMeasureData> _data = new List<WindMeasureData>()
        {
            new WindMeasureData() {Id=_nextId++, WindDirection = WindDataGenerator.NextDirection(), WindSpeed = WindDataGenerator.NextSpeed()},
            new WindMeasureData() {Id=_nextId++, WindDirection = WindDataGenerator.NextDirection(), WindSpeed = WindDataGenerator.NextSpeed()},
            new WindMeasureData() {Id=_nextId++, WindDirection = WindDataGenerator.NextDirection(), WindSpeed = WindDataGenerator.NextSpeed()},
            new WindMeasureData() {Id=_nextId++, WindDirection = WindDataGenerator.NextDirection(), WindSpeed = WindDataGenerator.NextSpeed()},
            new WindMeasureData() {Id=_nextId++, WindDirection = WindDataGenerator.NextDirection(), WindSpeed = WindDataGenerator.NextSpeed()}
        };

        public IEnumerable<WindMeasureData> GetAll(int minimumSpeed)
        {
            if (minimumSpeed == 0)
            {
                return new List<WindMeasureData>(_data);
            }
            else
            {
                return _data.FindAll(measure => measure.WindSpeed >= minimumSpeed);
            }

        }

        public WindMeasureData Add(WindMeasureData newMeasure)
        {
            newMeasure.Id = _nextId++;
            _data.Add(newMeasure);
            return newMeasure;
        }
    }
}
