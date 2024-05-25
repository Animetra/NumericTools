using System;
using UnityEngine;

/// <summary>
/// Provides several extension methods for int, float, Vector2 and Vector3 to simplify handling their values.
/// </summary>
public static class NumericHandling
{
    // Mapping

    /// <summary>
    /// Linear and not clamped mapping of a value space defined by <paramref name="inA"/> and <paramref name="inB"/> to a value space defined by <paramref name="outA"/> and <paramref name="outB"/>. 
    /// </summary>
    /// <param name="value">Value to apply the mapping to</param>
    /// <param name="inA">The value in input space which will be mapped to <paramref name="outA"/></param>
    /// <param name="inB">The value in input space which will be mapped to <paramref name="outB"/></param>
    /// <param name="outA">The value <paramref name="inA"/> will be mapped on</param>
    /// <param name="outB">The value <paramref name="inB"/> will be mapped on</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static int Map(this int value, int inA, int inB, int outA, int outB)
        => inB - inA == 0
            ? throw new ArgumentException("input space needs to have an extent.")
            : ((value - inA) / (inB - inA)) * (outB - outA) + outA;

    /// <summary>
    /// Linear and not clamped mapping of a value space defined by <paramref name="inA"/> and <paramref name="inB"/> to a value space defined by <paramref name="outA"/> and <paramref name="outB"/>. 
    /// </summary>
    /// <param name="value">Value to apply the mapping to</param>
    /// <param name="inA">The value in input space which will be mapped to <paramref name="outA"/></param>
    /// <param name="inB">The value in input space which will be mapped to <paramref name="outB"/></param>
    /// <param name="outA">The value <paramref name="inA"/> will be mapped on</param>
    /// <param name="outB">The value <paramref name="inB"/> will be mapped on</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static float Map(this float value, float inA, float inB, float outA, float outB)
        => inB - inA == 0
            ? throw new ArgumentException("input space needs to have an extent.")
            : ((value - inA) / (inB - inA)) * (outB - outA) + outA;

    /// <summary>
    /// Linear and not clamped mapping of the value space between 0 and 1 to a value space defined by <paramref name="outA"/> and <paramref name="outB"/>. 
    /// </summary>
    /// <param name="value">Value to apply the mapping to</param>
    /// <param name="outA">The value <paramref name="inA"/> will be mapped on</param>
    /// <param name="outB">The value <paramref name="inB"/> will be mapped on</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    /// <remarks>Can be used to map normalized data to a needed value range or for linear inter- and extrapolation.</remarks>
    public static float MapFrom01(this float value, float outA, float outB)
        => value * (outB - outA) + outA;

    /// <summary>
    /// Linear and not clamped mapping of a value space defined by <paramref name="inA"/> and <paramref name="inB"/> to the value space between 0 and 1. 
    /// </summary>
    /// <param name="value">Value to apply the mapping to</param>
    /// <param name="inA">The value in input space which will be mapped to 0</param>
    /// <param name="inB">The value in input space which will be mapped to 1</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    /// <remarks>Can be used to normalize data.</remarks>
    public static float MapTo01(this float value, float inA, float inB)
        => inB - inA == 0
            ? throw new ArgumentException("input space needs to have an extent.")
            : (value - inA) / (inB - inA);

    /// <summary>
    /// Linear and not clamped mapping of a 2D value space defined by <paramref name="inA"/> and <paramref name="inB"/> to a 2D value space defined by <paramref name="outA"/> and <paramref name="outB"/>. 
    /// </summary>
    /// <param name="value">Vector2 to apply the mapping to</param>
    /// <param name="inA">The Vector2 in input space which will be mapped to <paramref name="outA"/></param>
    /// <param name="inB">The Vector2 in input space which will be mapped to <paramref name="outB"/></param>
    /// <param name="outA">The Vector2 <paramref name="inA"/> will be mapped on</param>
    /// <param name="outB">The Vector2 <paramref name="inB"/> will be mapped on</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static Vector2 Map(this Vector2 value, Vector2 inA, Vector2 inB, Vector2 outA, Vector2 outB)
        => new Vector2(value.x.Map(inA.x, inB.x, outA.x, outB.x), value.y.Map(inA.y, inB.y, outA.y, outB.y));

    /// <summary>
    /// Linear and not clamped mapping of the 2D value space between 0,0 and 1,1 to a 2D value space defined by <paramref name="outA"/> and <paramref name="outB"/>. 
    /// </summary>
    /// <param name="value">Vector2 to apply the mapping to</param>
    /// <param name="outA">The Vector2 0,0 will be mapped on</param>
    /// <param name="outB">The Vector2 1,1 will be mapped on</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static Vector2 MapFrom01(this Vector2 value, Vector2 outA, Vector2 outB)
        => new Vector2(value.x.MapFrom01(outA.x, outB.x), value.y.MapFrom01(outA.y, outB.y));

    /// <summary>
    /// Linear and not clamped mapping of a 2D value space defined by <paramref name="inA"/> and <paramref name="inB"/> to the 2D value space between 0,0 and 1,1. 
    /// </summary>
    /// <param name="value">Value to apply the mapping to</param>
    /// <param name="inA">The Vector2 in input space which will be mapped to 0,0</param>
    /// <param name="inB">The Vector2 in input space which will be mapped to 1,1</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static Vector2 MapTo01(this Vector2 value, Vector2 inA, Vector2 inB)
        => new Vector2(value.x.MapTo01(inA.x, inB.x), value.y.MapFrom01(inA.y, inB.y));

    /// <summary>
    /// Linear and not clamped mapping of a 3D value space defined by <paramref name="inA"/> and <paramref name="inB"/> to a 3D value space defined by <paramref name="outA"/> and <paramref name="outB"/>. 
    /// </summary>
    /// <param name="value">Vector3 to apply the mapping to</param>
    /// <param name="inA">The Vector3 in input space which will be mapped to <paramref name="outA"/></param>
    /// <param name="inB">The Vector3 in input space which will be mapped to <paramref name="outB"/></param>
    /// <param name="outA">The Vector3 <paramref name="inA"/> will be mapped on</param>
    /// <param name="outB">The Vector3 <paramref name="inB"/> will be mapped on</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static Vector3 Map(this Vector3 value, Vector3 inA, Vector3 inB, Vector3 outA, Vector3 outB)
        => new Vector3(value.x.Map(inA.x, inB.x, outA.x, outB.x), value.y.Map(inA.y, inB.y, outA.y, outB.y), value.z.Map(inA.z, inB.z, outA.z, outB.z));

    /// <summary>
    /// Linear and not clamped mapping of the 3D value space between 0,0,0 and 1,1,1 to a 3D value space defined by <paramref name="outA"/> and <paramref name="outB"/>. 
    /// </summary>
    /// <param name="value">Vector3 to apply the mapping to</param>
    /// <param name="outA">The Vector3 0,0,0 will be mapped on</param>
    /// <param name="outB">The Vector3 1,1,1 will be mapped on</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static Vector3 MapFrom01(this Vector3 value, Vector3 outA, Vector3 outB)
        => new Vector3(value.x.MapFrom01(outA.x, outB.x), value.y.MapFrom01(outA.y, outB.y), value.z.MapFrom01(outA.z, outB.z));

    /// <summary>
    /// Linear and not clamped mapping of a 3D value space defined by <paramref name="inA"/> and <paramref name="inB"/> to the 3D value space between 0,0,0 and 1,1,1. 
    /// </summary>
    /// <param name="value">Value to apply the mapping to</param>
    /// <param name="inA">The Vector3 in input space which will be mapped to 0,0,0</param>
    /// <param name="inB">The Vector3 in input space which will be mapped to 1,1,1</param>
    /// <returns>the mapped <paramref name="value"/> in output space</returns>
    public static Vector3 MapTo01(this Vector3 value, Vector3 inA, Vector3 inB)
        => new Vector3(value.x.MapTo01(inA.x, inB.x), value.y.MapTo01(inA.y, inB.y), value.z.MapTo01(inA.z, inB.z));

    // Clamping

    /// <summary>
    /// Clamps the input value <paramref name="value"/> between the borders <paramref name="min"/> and <paramref name="max"/>, including the borders.
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <param name="min">The lower border</param>
    /// <param name="max">The higher border</param>
    /// <returns>the clamped value</returns>
    public static int Clamp(this int value, int? min, int? max)
    {
        if ((min is null && max is null) || max < min) { throw new ArgumentException("borders are both null or max is lower than min"); }
        if (min is int notNullMin) { value = value < notNullMin ? notNullMin : value; }
        if (max is int notNullMax) { value = value > notNullMax ? notNullMax : value; }

        return value;
    }

    /// <summary>
    /// Clamps the input value <paramref name="value"/> between the borders <paramref name="min"/> and <paramref name="max"/>, including the borders.
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <param name="min">The lower border</param>
    /// <param name="max">The higher border</param>
    /// <returns>the clamped value</returns>
    public static float Clamp(this float value, float? min, float? max)
    {
        if ((min is null && max is null) || max < min) { throw new ArgumentException("borders are both null or max is lower than min"); }
        if (min is float notNullMin) { value = value < notNullMin ? notNullMin : value; }
        if (max is float notNullMax) { value = value > notNullMax ? notNullMax : value; }

        return value;
    }

    /// <summary>
    /// Clamps the input value <paramref name="value"/> between 0 and 1.
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <returns>the clamped value</returns>
    public static float Clamp01(this float value)
        => Mathf.Clamp01(value);

    /// <summary>
    /// Clamps <paramref name="value"/> component-wise between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="value">The Vector2 to clamp</param>
    /// <param name="min">The lower borders</param>
    /// <param name="max">The higher borders</param>
    /// <returns>the clamped Vector2</returns>
    public static Vector2 Clamp(this Vector2 value, Vector2? min, Vector2? max)
        => new Vector2(value.x.Clamp(min?.x, max?.x), value.y.Clamp(min?.y, max?.y));

    /// <summary>
    /// Clamps <paramref name="value"/> component-wise between 0,0 and 1,1.
    /// </summary>
    /// <param name="value">The value to clamp</param>
    /// <returns>the clamped Vector2</returns>
    public static Vector2 Clamp01(this Vector2 value)
        => value.Clamp(Vector2.zero, Vector2.one);

    /// <summary>
    /// Clamps the magnitude of <paramref name="value"/> between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="value">The Vector2, whose magnitude to clamp</param>
    /// <param name="min">The minimum magnitude</param>
    /// <param name="max">The maximum magnitude</param>
    /// <returns>the clamped Vector2</returns>
    /// <exception cref="ArgumentException"></exception>
    public static Vector2 ClampMagnitude(this Vector2 value, float? min, float? max)
    {
        if (min < 0 || max < 0) { throw new ArgumentException("borders need to be greater than 0"); }

        float currentMagnitude = value.magnitude;
        if (currentMagnitude == 0) { throw new ArgumentException("input value must have a magnitude greater than 0"); }

        float targetMagnitude = currentMagnitude.Clamp(min, max);

        return currentMagnitude != targetMagnitude ? value * (targetMagnitude / currentMagnitude) : value;
    }

    /// <summary>
    /// Clamps <paramref name="value"/> component-wise between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="value">The Vector3 to clamp</param>
    /// <param name="min">The lower borders</param>
    /// <param name="max">The higher borders</param>
    /// <returns>the clamped Vector2</returns>
    public static Vector3 Clamp(this Vector3 value, Vector3? min, Vector3? max)
        => new Vector3(value.x.Clamp(min?.x, max?.x), value.y.Clamp(min?.y, max?.y), value.z.Clamp(min?.z, max?.z));

    /// <summary>
    /// Clamps <paramref name="value"/> component-wise between 0,0,0 and 1,1,1.
    /// </summary>
    /// <param name="value">The Vector3 to clamp</param>
    /// <returns>the clamped Vector3</returns>
    public static Vector3 Clamp01(this Vector3 value)
        => value.Clamp(Vector3.zero, Vector3.one);

    /// <summary>
    /// Clamps the magnitude of <paramref name="value"/> between <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="value">The Vector3, whose magnitude to clamp</param>
    /// <param name="min">The minimum magnitude</param>
    /// <param name="max">The maximum magnitude</param>
    /// <returns>the clamped Vector3</returns>
    public static Vector3 ClampMagnitude(this Vector3 value, float? min, float? max)
    {
        if (min < 0 || max < 0) { throw new ArgumentException("borders need to be greater than 0"); }

        float currentMagnitude = value.magnitude;
        if (currentMagnitude == 0) { throw new ArgumentException("input value must have a magnitude greater than 0"); }

        float targetMagnitude = currentMagnitude.Clamp(min, max);

        return currentMagnitude != targetMagnitude ? value * (targetMagnitude / currentMagnitude) : value;
    }

    // Other

    /// <summary>
    /// Determines whether a value is even
    /// </summary>
    /// <param name="value">The value which might be even</param>
    /// <returns>true if even</returns>
    public static bool IsEven(this int value)
        => value % 2 == 0;
}