using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Bar : AaaHopEntity
{
  [Attr] public string DisplayName { get; set; } = null!;
}
