using System;
using System.Collections.Generic;
using System.Text;

namespace Birras.Core.Interfaces
{
    public interface IWeatherService
    {
        int GetWeatherByDay(DateTime date);
    }
}
