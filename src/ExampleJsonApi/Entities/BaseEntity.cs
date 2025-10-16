using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace ExampleJsonApi.Entities;

public abstract class BaseEntity : Identifiable<long>
{
  [Attr] public string? CreatedBy { get; set; } = null!;
}
