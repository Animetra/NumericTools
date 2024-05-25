// Copyright (c) Lukas Fuchs 2023. All Rights Reserved.

using System;
using UnityEngine;

[Serializable]
public struct ClampedFloat01 :
    ITransferable,
    IComparable
{
    [SerializeField][Range(0, 1)] private float _value;

    public float Value
    {
        get => _value;
        set => _value = value.Clamp01();
    }

    public ClampedFloat01(float initValue)
    {
        _value = initValue;
        _value = _value.Clamp01();
    }

    public int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }

    public static implicit operator float(ClampedFloat01 clampedFloat01) => clampedFloat01.Value;
    public static implicit operator ClampedFloat01(float value) => new ClampedFloat01(value.AssureBetween01());
    public static implicit operator ClampedFloat(ClampedFloat01 clampedFloat01) => new ClampedFloat(clampedFloat01.Value, 0, 1);
    public static ClampedFloat01 operator +(ClampedFloat01 a, ClampedFloat01 b) => new ClampedFloat01(a.Value + b.Value);
    public static ClampedFloat01 operator -(ClampedFloat01 a, ClampedFloat01 b) => new ClampedFloat01(a.Value - b.Value);
    public static ClampedFloat01 operator *(ClampedFloat01 a, ClampedFloat01 b) => new ClampedFloat01(a.Value * b.Value);
    public static ClampedFloat01 operator /(ClampedFloat01 a, ClampedFloat01 b) => new ClampedFloat01(a.Value / b.Value);
    public static ClampedFloat01 operator +(ClampedFloat01 a, int b) { a.Value += b; return a; }
    public static ClampedFloat01 operator -(ClampedFloat01 a, int b) { a.Value -= b; return a; }
    public static ClampedFloat01 operator *(ClampedFloat01 a, int b) { a.Value *= b; return a; }
    public static ClampedFloat01 operator /(ClampedFloat01 a, int b) { a.Value /= b; return a; }
    public static ClampedFloat01 operator +(ClampedFloat01 a, float b) { a.Value += b; return a; }
    public static ClampedFloat01 operator -(ClampedFloat01 a, float b) { a.Value -= b; return a; }
    public static ClampedFloat01 operator *(ClampedFloat01 a, float b) { a.Value *= b; return a; }
    public static ClampedFloat01 operator /(ClampedFloat01 a, float b) { a.Value /= b; return a; }
    public static bool operator <(ClampedFloat01 a, ClampedFloat01 b) => a.Value < b.Value;
    public static bool operator <=(ClampedFloat01 a, ClampedFloat01 b) => a.Value <= b.Value;
    public static bool operator >(ClampedFloat01 a, ClampedFloat01 b) => a.Value > b.Value;
    public static bool operator >=(ClampedFloat01 a, ClampedFloat01 b) => a.Value >= b.Value;
    public static bool operator ==(ClampedFloat01 a, ClampedFloat01 b) => a.Value == b.Value;
    public static bool operator !=(ClampedFloat01 a, ClampedFloat01 b) => a.Value != b.Value;
    public static bool operator <(ClampedFloat01 a, float b) => a.Value < b;
    public static bool operator <=(ClampedFloat01 a, float b) => a.Value <= b;
    public static bool operator >(ClampedFloat01 a, float b) => a.Value > b;
    public static bool operator >=(ClampedFloat01 a, float b) => a.Value >= b;
    public static bool operator ==(ClampedFloat01 a, float b) => a.Value == b;
    public static bool operator !=(ClampedFloat01 a, float b) => a.Value != b;
    public static bool operator <(ClampedFloat01 a, int b) => a.Value < b;
    public static bool operator <=(ClampedFloat01 a, int b) => a.Value <= b;
    public static bool operator >(ClampedFloat01 a, int b) => a.Value > b;
    public static bool operator >=(ClampedFloat01 a, int b) => a.Value >= b;
    public static bool operator ==(ClampedFloat01 a, int b) => a.Value == b;
    public static bool operator !=(ClampedFloat01 a, int b) => a.Value != b;
    public override bool Equals(object a) => a is ClampedFloat01 clampeFloatA && clampeFloatA.GetHashCode() == GetHashCode();
    public override int GetHashCode() => HashCode.Combine(Value);
}
