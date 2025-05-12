using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _piris.DomainService.Objects
{
    public partial class PositionObject
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string PositionType { get; set; }
        public int PositionValue { get; set; }
        public string PositionCurrency { get; set; }
        public int PositionPrice { get; set; }
        public int PriceCurrency { get; set; }
    }
    public enum PositionType
    {
        Production = 0,
        Service = 1,
        Bonus = 2
    }
}