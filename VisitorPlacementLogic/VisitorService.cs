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
        public async Task<List<Visitor>> GenerateRandomVisitors(int count)
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
            Random r = new Random();
            List<Visitor> visitorsCopy = new List<Visitor>(visitors);
            
            

            List<Group> groups = new List<Group>();

            int groupSize = new Random().Next(1,8);

            while (visitorsCopy.Any())
            {
                var currentGroup = visitorsCopy.Take(groupSize).ToList();

                if (currentGroup.Any(v => v.IsAdult)){
                    visitorsCopy.RemoveAll(v => currentGroup.Contains(v));
                    var group = new Group
                    {
                        Visitors = currentGroup,
                        RegistrationDate = currentGroup.First(v => v.IsAdult).RegistrationDate
                    };
                    groups.Add(group);
                }
                else{
                    visitorsCopy.OrderBy(v => r.Next());
                }
            }

            return groups;
            
        }


    }
}
