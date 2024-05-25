using System;

public static class Assurance
{
    /// <summary>
    /// Assures that a value is not NaN.
    /// </summary>
    /// <param name="value">The value which might be NaN</param>
    /// <param name="replace">Optional value <paramref name="value"/> will be replaced with, if it's NaN.</param>
    /// <returns>the not NaN value</returns>
    public static float AssureNotNaN(this float value, float? replace)
    {
        if (float.IsNaN(value))
        {
            return (replace is float notNullReplace) ? notNullReplace : throw new Exception("value is NaN");
        }
        else
        {
            return value;
        }
    }

    /// <summary>
    /// Assures that a value is between 0 and 1, inclusive.
    /// </summary>
    /// <param name="value">the value needed to be between 0 and 1.</param>
    /// <returns>the value, if it's between 0 and 1.</returns>
    public static float AssureBetween01(this float value)
        => value is < 0 or > 1 ? throw new ArgumentException("Input value needs to be between 0 and 1.") : value;
}

