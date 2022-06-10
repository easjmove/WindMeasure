using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindMeasureAPI.Models
{
    public class WindDataGenerator
    {
        private static readonly string[] Directions = { "N", "NE", "E", "SE", "S", "SW", "W", "NW" };
        private static int _speed = 6;
        private static int _direction = 0;
        private static readonly Random _ran = new Random();

        public static int NextSpeed()
        {
            _speed += _ran.Next(-1, 2);
            if (_speed < 0) _speed = 0;
            return _speed;
        }

        public static string NextDirection()
        {
            _direction += _ran.Next(-1, 2);
            if (_direction == -1) _direction = 7;
            if (_direction == 8) _direction = 0;
            return Directions[_direction];
        }
    }
}
