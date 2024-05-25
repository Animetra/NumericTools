// Copyright (c) Lukas Fuchs 2023. All Rights Reserved.

using System;
using UnityEngine;
using Unity.Properties;

[Serializable]
public struct ClampedInt :
    IComparable
{
    [SerializeField] private int _value;
    public int? Minimum { get; private set; }
    public int? Maximum { get; private set; }

    [CreateProperty]
    public int Value
    {
        get => _value;
        set => _value = value.Clamp(Minimum, Maximum);
    }

    public ClampedInt(int initValue, int? minimum, int? maximum)
    {
        _value = initValue;
        Minimum = minimum;
        Maximum = maximum;
        _value = _value.Clamp(Minimum, Maximum);
    }

    public int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }

    public static implicit operator int(ClampedInt value) => value.Value;
    public static ClampedFloat operator +(ClampedInt a, float b) { return new(a.Value + b, a.Minimum, a.Maximum); }
    public static ClampedFloat operator -(ClampedInt a, float b) { return new(a.Value - b, a.Minimum, a.Maximum); }
    public static ClampedFloat operator *(ClampedInt a, float b) { return new(a.Value * b, a.Minimum, a.Maximum); }
    public static ClampedFloat operator /(ClampedInt a, float b) { return new(a.Value / b, a.Minimum, a.Maximum); }
    public static ClampedInt operator +(ClampedInt a, int b) { a.Value += b; return a; }
    public static ClampedInt operator -(ClampedInt a, int b) { a.Value -= b; return a; }
    public static ClampedInt operator *(ClampedInt a, int b) { a.Value *= b; return a; }
    public static ClampedInt operator /(ClampedInt a, int b) { a.Value /= b; return a; }
    public static bool operator <(ClampedInt a, ClampedInt b) => a.Value < b.Value;
    public static bool operator <=(ClampedInt a, ClampedInt b) => a.Value <= b.Value;
    public static bool operator >(ClampedInt a, ClampedInt b) => a.Value > b.Value;
    public static bool operator >=(ClampedInt a, ClampedInt b) => a.Value >= b.Value;
    public static bool operator ==(ClampedInt a, ClampedInt b) => a.Value == b.Value;
    public static bool operator !=(ClampedInt a, ClampedInt b) => a.Value != b.Value;
    public static bool operator <(ClampedInt a, float b) => a.Value < b;
    public static bool operator <=(ClampedInt a, float b) => a.Value <= b;
    public static bool operator >(ClampedInt a, float b) => a.Value > b;
    public static bool operator >=(ClampedInt a, float b) => a.Value >= b;
    public static bool operator ==(ClampedInt a, float b) => a.Value == b;
    public static bool operator !=(ClampedInt a, float b) => a.Value != b;
    public static bool operator <(ClampedInt a, int b) => a.Value < b;
    public static bool operator <=(ClampedInt a, int b) => a.Value <= b;
    public static bool operator >(ClampedInt a, int b) => a.Value > b;
    public static bool operator >=(ClampedInt a, int b) => a.Value >= b;
    public static bool operator ==(ClampedInt a, int b) => a.Value == b;
    public static bool operator !=(ClampedInt a, int b) => a.Value != b;
    public override bool Equals(object a) => a is ClampedInt clampedIntA && clampedIntA.GetHashCode() == GetHashCode();
    public override int GetHashCode() => HashCode.Combine(Value, Minimum, Maximum);
}
