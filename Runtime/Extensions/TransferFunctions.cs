using System;
using UnityEngine;

/// <summary>
/// Provides different transfer functions for normalized data (0 to 1) to modify value behaviour between 0,0 and 1,1.
/// </summary>
public static class TransferFunctions
{
    /// <summary>
    /// Applies an exponential transfer function on <paramref name="value"/>.
    /// </summary>
    /// <param name="value">the input value between 0 and 1, inclusive</param>
    /// <param name="exponent">the exponent</param>
    /// <returns>the transferred value</returns>
    public static ITransferable TransferExponential(this ITransferable value, float exponent)
    {
        value.Value = Mathf.Pow(value.Value.AssureBetween01(), exponent);
        return value;
    }

    /// <summary>
    /// Applies an cosine transfer function on <paramref name="value"/> (1 PI to 2 PI).
    /// </summary>
    /// <param name="value">the input value between 0 and 1, inclusive</param>
    /// <returns>the transferred value</returns>
    public static ITransferable TransferCos(this ITransferable value)
    {
        value.Value = Mathf.Cos(value.Value.AssureBetween01().MapFrom01(Mathf.PI, Mathf.PI * 2f)).MapTo01(-1f, 1f);
        return value;
    }

    /// <summary>
    /// Inverts <paramref name="value"/>, meaning 1-x.
    /// </summary>
    /// <param name="value">The value to be inverted</param>
    /// <returns>The inverted value</returns>
    public static ITransferable TransferInvert(this ITransferable value)
    {
        value.Value = 1f - value.Value.AssureBetween01();
        return value;
    }
}