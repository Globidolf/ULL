using System;
namespace ULL
{
	/// <summary>
	/// Provides some Shortcuts for specific calculations repetitively used as well as wrapper for the default Math library.
	/// If a faster way to calculate specific aspects is available it can be replaced here.
	/// </summary>
    internal static class Utility
    {
		internal static float Square(float value) { return value * value; }
		internal static float Sqrt(float value) { return (float)Math.Sqrt(value); }
    }
}
