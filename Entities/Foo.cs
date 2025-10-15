using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class Foo : Identifiable<long>
{
  [Attr] public string DisplayName { get; set; } = null!;
}