using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementModels
{
    public class Group
    {
        public List<Visitor> Visitors { get; set; } = new List<Visitor>();
        public DateTime RegistrationDate { get; set; }

    }
}
