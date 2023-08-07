using EarthBlog.Core.Entities;

namespace EarthBlog.Entities.Concrete;

public class Language : Entity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool IsActived { get; set; }
}