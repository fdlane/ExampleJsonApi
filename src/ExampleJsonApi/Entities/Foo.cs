using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Foo : AaaHopEntity
{
  [Attr] public string DisplayName { get; set; } = null!;
}
