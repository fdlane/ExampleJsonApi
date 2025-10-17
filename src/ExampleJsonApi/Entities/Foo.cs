using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Foo : HopEntity
{
  [Attr] public string DisplayName { get; set; } = null!;
}
