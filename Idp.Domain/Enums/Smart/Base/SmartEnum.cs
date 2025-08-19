using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Idp.Domain.Enums.Smart.Base;

[ExcludeFromCodeCoverage]
public abstract class SmartEnum<TType> : IEquatable<SmartEnum<TType>> where TType : SmartEnum<TType>
{
    private string Value { get; }
    private int Index { get; }

    // ReSharper disable once StaticMemberInGenericType
    private static bool _initialized;

    private static readonly Dictionary<int, TType> Values = new();

    protected SmartEnum(string value, int index)
    {
        Index = index;
        Value = value;
    }

    public static TType? GetByValue(string value)
    {
        EnsureInitialized();
        return Values.Values.FirstOrDefault(x => x.Value == value);
    }

    public static TType? GetByIndex(int index)
    {
        EnsureInitialized();
        return Values.GetValueOrDefault(index);
    }

    public static IReadOnlyDictionary<int, TType> Get()
    {
        EnsureInitialized();
        return Values.AsReadOnly();
    }

    private static void EnsureInitialized()
    {
        if (_initialized) return;

        RuntimeHelpers.RunClassConstructor(typeof(TType).TypeHandle);
        _initialized = true;
    }

    #region | Implicit Operators |

    public static implicit operator string(SmartEnum<TType> value)
    {
        return value.Value;
    }

    public static implicit operator int(SmartEnum<TType> value)
    {
        return value.Index;
    }

    #endregion

    #region | Equality |

    public override int GetHashCode() => Index.GetHashCode();

    public override string ToString() => Value;

    public bool Equals(SmartEnum<TType>? other)
    {
        if (other is null) return false;

        return other.Index == Index;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((SmartEnum<TType>)obj);
    }

    public static bool operator ==(SmartEnum<TType>? a, SmartEnum<TType>? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(SmartEnum<TType>? a, SmartEnum<TType>? b)
    {
        return !(a == b);
    }
    
    #endregion
}