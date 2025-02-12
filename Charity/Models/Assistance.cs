using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class Assistance
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Helper { get; set; }
        public AssistanceType HelpType { get; set; }
        public int HelpTypeId { get; set; }
    }
}
