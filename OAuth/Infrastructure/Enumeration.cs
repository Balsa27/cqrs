using System.Reflection;

namespace OAuth.Infrastructure;

public abstract class Enumeration<T> : IEquatable<Enumeration<T>> where T : Enumeration<T>
{
    protected Enumeration(int value, string name)
    {
        Value = value;
        Name = name;
    }

    public static readonly Dictionary<int, T> Enumerations = CreateEnumerations();

    public int Value { get; protected init; } 
    
    public string Name { get; protected init; } = string.Empty;

    //default is null in both cases
    public static T? FromValue(int value) => Enumerations.TryGetValue(value, out T? enumeration) ? enumeration : default; 
    
    
    public static T? FromName(string name) => Enumerations.Values.SingleOrDefault(v => v.Name == name) ?? default; 
    
    public bool Equals(Enumeration<T>? other)
    {
        //return other == null ? false : GetType() == other.GetType() && Value == other.Value; 
        if(other == null) return false;
        return GetType() == other.GetType() && Value == other.Value;
    }
    
    //if the specified obj is an enumeration of T, then its stored into the other variable and than the
    //result of IEquatable Equals method is called and returned
    public override bool Equals(object? obj) => obj is Enumeration<T> other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Name;

    private static Dictionary<int, T> CreateEnumerations()
    {
        //use reflection to scan current enumeration instance and look for public static fields
        //that are of type T 
        //find all, create dictionary
        
        var enumType = typeof(T);
        
        //GetFields on the enumeration type and then filtering the fields that are assignable to the enumeration type
        //and then getting the concrete values and casting them back to T
        var fields = enumType
            .GetFields(
                BindingFlags.Public | 
                BindingFlags.Static | 
                BindingFlags.FlattenHierarchy)
            .Where(info => enumType.IsAssignableFrom(info.FieldType))
            .Select(info => (T)info.GetValue(default)!);

        return fields.ToDictionary(x => x.Value);
    }
}