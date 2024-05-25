using System;
using UnityEngine;

[Serializable]
public struct ClampedFloat :
	IComparable
{
	[SerializeField] private float _value;
	public float? Minimum { get; private set; }
	public float? Maximum { get; private set; }

	public float Value
	{
		get => _value;
		set => _value = value.Clamp(Minimum, Maximum);
	}

	public ClampedFloat(float initValue, float? minimum, float? maximum)
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

	public static implicit operator float(ClampedFloat clampedFloat) => clampedFloat.Value;
	public static ClampedFloat operator +(ClampedFloat a, int b) { a.Value += b; return a; }
	public static ClampedFloat operator -(ClampedFloat a, int b) { a.Value -= b; return a; }
	public static ClampedFloat operator *(ClampedFloat a, int b) { a.Value *= b; return a; }
	public static ClampedFloat operator /(ClampedFloat a, int b) { a.Value /= b; return a; }
	public static ClampedFloat operator +(ClampedFloat a, float b) { a.Value += b; return a; }
	public static ClampedFloat operator -(ClampedFloat a, float b) { a.Value -= b; return a; }
	public static ClampedFloat operator *(ClampedFloat a, float b) { a.Value *= b; return a; }
	public static ClampedFloat operator /(ClampedFloat a, float b) { a.Value /= b; return a; }
	public static bool operator <(ClampedFloat a, ClampedFloat b) => a.Value < b.Value;
	public static bool operator <=(ClampedFloat a, ClampedFloat b) => a.Value <= b.Value;
	public static bool operator >(ClampedFloat a, ClampedFloat b) => a.Value > b.Value;
	public static bool operator >=(ClampedFloat a, ClampedFloat b) => a.Value >= b.Value;
	public static bool operator ==(ClampedFloat a, ClampedFloat b) => a.Value == b.Value;
	public static bool operator !=(ClampedFloat a, ClampedFloat b) => a.Value != b.Value;
	public static bool operator <(ClampedFloat a, float b) => a.Value < b;
	public static bool operator <=(ClampedFloat a, float b) => a.Value <= b;
	public static bool operator >(ClampedFloat a, float b) => a.Value > b;
	public static bool operator >=(ClampedFloat a, float b) => a.Value >= b;
	public static bool operator ==(ClampedFloat a, float b) => a.Value == b;
	public static bool operator !=(ClampedFloat a, float b) => a.Value != b;
	public static bool operator <(ClampedFloat a, int b) => a.Value < b;
	public static bool operator <=(ClampedFloat a, int b) => a.Value <= b;
	public static bool operator >(ClampedFloat a, int b) => a.Value > b;
	public static bool operator >=(ClampedFloat a, int b) => a.Value >= b;
	public static bool operator ==(ClampedFloat a, int b) => a.Value == b;
	public static bool operator !=(ClampedFloat a, int b) => a.Value != b;
	public override bool Equals(object a) => a is ClampedFloat clampeFloatA && clampeFloatA.GetHashCode() == GetHashCode();
	public override int GetHashCode() => HashCode.Combine(Value, Minimum, Maximum);

}
