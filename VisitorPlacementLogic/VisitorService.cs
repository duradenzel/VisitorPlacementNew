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
                .RuleFor(v => v.RegistrationDate, f => f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now.AddDays(30)));


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
            int groupId = 1;
            List<Visitor> visitorsCopy = new List<Visitor>(visitors);
            visitorsCopy.RemoveAll(v => v.IsAllowedAccess == false);

            List<Group> groups = new List<Group>();


            while (visitorsCopy.Any())
            {
                int groupSize = r.Next(1,8);
                var currentGroup = visitorsCopy.Take(groupSize).ToList();

                if (currentGroup.Any(v => v.IsAdult)){
                    visitorsCopy.RemoveAll(v => currentGroup.Contains(v));
                    currentGroup.ForEach(v => v.GroupId = groupId);
                    var group = new Group
                    {
                        Id = groupId,
                        Visitors = currentGroup,
                        RegistrationDate = currentGroup.First(v => v.IsAdult).RegistrationDate
                    };
                    groups.Add(group);
                }
                else{
                    visitorsCopy.OrderBy(v => r.Next());
                }
                groupId++;
            }

            return groups;
            
        }

        // public List<Visitor> UpdateVisitorIds(List<Group> groups, List<Visitor> visitors){
        //       foreach (var group in groups)
        //     {
        //         foreach (var visitor in group.Visitors)
        //         {
        //             var v = visitors.FirstOrDefault(v => v.Id == visitor.Id);
        //             if (v != null)
        //             {
        //                 v.GroupId = group.Id;
        //             }
        //         }
        //     }
        //     return visitors;
        // }


    }
}
