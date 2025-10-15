using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Person : Identifiable<long>
{
  [Attr] public string? FirstName { get; set; }
  [Attr] public string LastName { get; set; } = null!;
  [HasMany] public ISet<Person> Children { get; set; } = new HashSet<Person>();
}