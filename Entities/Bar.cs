using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Bar : Identifiable<long>
{
  [Attr] public string DisplayName { get; set; } = null!;
}