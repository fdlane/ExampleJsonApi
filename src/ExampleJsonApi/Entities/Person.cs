using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource(PublicName = "people")]
public class Person : HopEntity
{
  [Attr] public string? FirstName { get; set; }
  [Attr] public string LastName { get; set; } = null!;
  [HasMany] public ISet<Person> Children { get; set; } = new HashSet<Person>();
}
