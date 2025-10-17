using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource(PublicName = "bars")]
public class Bar : HopEntity
{
  [Attr] public string DisplayName { get; set; } = null!;

  [Attr] public string? BarOnlyMarker { get; set; }
}
