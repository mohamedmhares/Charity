using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class Case
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CasesNumber { get; set; }
        public bool IsFatherAlive { get; set; }
        public bool IsMotherAlive { get; set; }
        public string Address { get; set; }
        public double Lattuide { get; set; }
        public double Longtuide { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime RecoredDate { get; set; }
    }
}
