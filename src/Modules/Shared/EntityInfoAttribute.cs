namespace Shared;

[AttributeUsage(AttributeTargets.Property)]
public class EntityInfoAttribute : Attribute
{
    public string Name { get; }
    public Type? ConverterType { get; }

    public EntityInfoAttribute(string name, Type? converterType = null)
    {
        Name = name;
        ConverterType = converterType;
    }
}


