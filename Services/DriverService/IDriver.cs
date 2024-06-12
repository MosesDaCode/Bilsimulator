using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DriverService
{
    public interface IDriver
    {
        int Hunger { get; set; }
        void IncreaseHunger();
        void Eat();
        HungerLevel GetHungerLevel();
    }

    public enum HungerLevel
    {
        Full,
        Hungry,
        Starving
    }
}
