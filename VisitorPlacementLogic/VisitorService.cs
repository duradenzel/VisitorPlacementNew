using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementModels;

namespace VisitorPlacementLogic
{
    public class VisitorService
    {
        public List<Visitor> GenerateRandomVisitors(int count)
        {
            var visitors = new List<Visitor>();

            var faker = new Faker<Visitor>()
                .RuleFor(v => v.Id, f => f.UniqueIndex)
                .RuleFor(v => v.Name, f => f.Name.FullName())
                .RuleFor(v => v.DateOfBirth, f => f.Date.Between(DateTime.Now.AddYears(-60), DateTime.Now))
                .RuleFor(v => v.IsAdult, (f, v) => (DateTime.Now - v.DateOfBirth).TotalDays >= 365 * 12)
                .RuleFor(v => v.RegistrationDate, f => f.Date.Past());


            for (int i = 0; i < count; i++)
            {
                var visitor = faker.Generate();
                visitors.Add(visitor);
            }

            return visitors.OrderBy(v => v.RegistrationDate).ToList(); ;
        }

        public List<Group> GenerateGroups(List<Visitor> visitors)
        {
            List<Group> groups = new List<Group>();

            return groups;
        }
    }
}
