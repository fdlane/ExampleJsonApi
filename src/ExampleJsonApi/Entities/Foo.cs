using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource(PublicName = "foos")]
public class Foo : HopEntity
{
  [Attr] public string DisplayName { get; set; } = null!;
  [Attr] public string? FooOnlyMarker { get; set; }
}
