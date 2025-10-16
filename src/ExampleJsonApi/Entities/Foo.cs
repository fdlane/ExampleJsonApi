using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Foo : BaseEntity
{
  [Attr] public string DisplayName { get; set; } = null!;
}
