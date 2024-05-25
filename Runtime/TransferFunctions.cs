using System;
using UnityEngine;

/// <summary>
/// Provides different transfer functions for normalized data to modify value behaviour between 0,0 and 1,1.
/// </summary>
public static class TransferFunctions
{
    /// <summary>
    /// Applies an exponential transfer function on <paramref name="value"/>.
    /// </summary>
    /// <param name="value">the input value between 0 and 1, inclusive</param>
    /// <param name="exponent">the exponent</param>
    /// <returns>the transferred value</returns>
    public static float TransferExponential(this float value, float exponent)
        => Mathf.Pow(value.AssureBetween01(), exponent);
    
    /// <summary>
    /// Applies an cosine transfer function on <paramref name="value"/> (1 PI to 2 Pi).
    /// </summary>
    /// <param name="value">the input value between 0 and 1, inclusive</param>
    /// <param name="exponent">the exponent</param>
    /// <returns>the transferred value</returns>
    public static float TransferCos(this float value)
        => Mathf.Cos(value.AssureBetween01().MapFrom01(Mathf.PI, Mathf.PI * 2f)).MapTo01(-1f, 1f);

    /// <summary>
    /// Inverts <paramref name="value"/>, meaning 1-x.
    /// </summary>
    /// <param name="value">The value to be inverted</param>
    /// <returns>The inverted value</returns>
    public static float TransferInvert(this float value)
        => 1f - value.AssureBetween01();
}