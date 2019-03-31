using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSWebsite.DomainObjects
{
    public class RSObject
    {
        public RSObject(int id, string name, Dictionary<DateTime, int> dailyPrices)
        {
            Id = id;
            Name = name;
            DailyPrices = dailyPrices;
        }

        public RSObject() {}

        public int Id { get; protected set; }
        
        public string Name { get; protected set; }

        public Dictionary<DateTime, int> DailyPrices { get; protected set; }
    }
}
