using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Bar : HopEntity
{
  [Attr] public string DisplayName { get; set; } = null!;
}
