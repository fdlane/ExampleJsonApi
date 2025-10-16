using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

[Resource]
public class xBar : BaseEntity
{
  [Attr] public string DisplayName { get; set; } = null!;
}
