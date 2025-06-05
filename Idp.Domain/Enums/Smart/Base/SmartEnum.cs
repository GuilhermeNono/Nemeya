using System.Runtime.CompilerServices;

namespace Idp.Domain.Enums.Smart.Base;

public abstract class SmartEnum<TEnum> : IEquatable<SmartEnum<TEnum>> where TEnum : SmartEnum<TEnum>
{
    protected string Value { get; }
    public int Index { get; }

    // ReSharper disable once StaticMemberInGenericType
    private static bool _initialized;

    private static readonly Dictionary<int, TEnum> Values = new();

    protected SmartEnum(string value, int index)
    {
        Index = index;
        Value = value;
    }

    public static TEnum? GetByValue(string value)
    {
        EnsureInitialized();
        return Values.Values.FirstOrDefault(x => x.Value == value);
    }

    public static TEnum? GetByIndex(int index)
    {
        EnsureInitialized();
        return Values.GetValueOrDefault(index);
    }

    public static IReadOnlyDictionary<int, TEnum> Get()
    {
        EnsureInitialized();
        return Values.AsReadOnly();
    }

    private static void EnsureInitialized()
    {
        if (_initialized) return;

        RuntimeHelpers.RunClassConstructor(typeof(TEnum).TypeHandle);
        _initialized = true;
    }

    #region | Implicit Operators |

    public static implicit operator string(SmartEnum<TEnum> value)
    {
        return value.Value;
    }

    public static implicit operator int(SmartEnum<TEnum> value)
    {
        return value.Index;
    }

    #endregion

    #region | Equality |

    public override int GetHashCode() => Index.GetHashCode();

    public override string ToString() => Value;

    public bool Equals(SmartEnum<TEnum>? other)
    {
        if (other is null) return false;

        return other.Index == Index;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SmartEnum<TEnum>)obj);
    }

    public static bool operator ==(SmartEnum<TEnum>? a, SmartEnum<TEnum>? b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(SmartEnum<TEnum>? a, SmartEnum<TEnum>? b)
    {
        return !(a == b);
    }

    #endregion
}