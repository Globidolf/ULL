namespace ULL.Vector
{
	/// <summary>
	/// Represents a vector in 2D space
	/// </summary>
	public class Vec2
	{
		#region Properties
		/// <summary>
		/// The horizontal X axis coordinate of this vector
		/// </summary>
		public float X { get; set; }
		/// <summary>
		/// The vertical Y axis coordinate of this vector
		/// </summary>
		public float Y { get; set; }
		#endregion
		#region Constants
		/// <summary>
		/// A 2D-Vector representing the top direction (0,1)
		/// </summary>
		public static Vec2 TOP { get { return new Vec2(0, 1); } }
		/// <summary>
		/// A 2D-Vector representing the bottom direction (0,-1)
		/// </summary>
		public static Vec2 BOTTOM { get { return new Vec2(0, -1); } }
		/// <summary>
		/// A 2D-Vector representing the left direction (-1,0)
		/// </summary>
		public static Vec2 LEFT { get { return new Vec2(-1, 0); } }
		/// <summary>
		/// A 2D-Vector representing the right direction (0,-1)
		/// </summary>
		public static Vec2 RIGHT { get { return new Vec2(1, 0); } }
		/// <summary>
		/// A 2D-Vector with all values being zero (0,0)
		/// </summary>
		public static Vec2 ZERO { get { return new Vec2(0, 0); } }
		/// <summary>
		/// A 2D-Vector with all values being one (1,1)
		/// </summary>
		public static Vec2 ONE { get { return new Vec2(1, 1); } }
		#endregion
		#region Dimension Swap
		public Vec2 XY { get { return new Vec2(X, Y); } }
		public Vec2 YX { get { return new Vec2(Y, X); } }
		#endregion
		#region Constructors
		/// <summary>
		/// Creates a 2D vector with zero distance (0,0)
		/// </summary>
		public Vec2() : this(0) { }
		/// <summary>
		/// Creates a 2D vector with all coordinates set to <paramref name="value"/>
		/// </summary>
		/// <param name="value">The value to set the coordinates to</param>
		public Vec2(float value) { X = Y = value; }
		/// <summary>
		/// Duplicates the 2D vector <paramref name="copy"/> into a new instance
		/// </summary>
		/// <param name="copy">The vector to duplicate</param>
		public Vec2(Vec2 copy) : this(copy.X, copy.Y) { }
		/// <summary>
		/// Converts a 3D vector to 2D, losing the remaining axis in the process
		/// </summary>
		/// <param name="vec">The 3D vector to convert to 2D</param>
		public Vec2(Vec3 vec) : this(vec.XY) { }
		// Todo: add constructors with other vector classes
		/// <summary>
		/// Creates a specific 2D vector instance with the given values
		/// </summary>
		/// <param name="x">The value of the horizontal X coordinate</param>
		/// <param name="y">The value of the vertical Y coordinate</param>
		public Vec2(float x, float y) { X = x; Y = y; }
		#endregion
		#region Methods
		/// <summary>
		/// Calculates the squared distance between this vector and the <paramref name="other"/> vector.
		/// Use this instead of <see cref="Distance(Vec2)"/> where possible to increase performance.
		/// </summary>
		/// <param name="other">The second vector to calculate the distance between</param>
		/// <returns>The squared distance between this vector and the <paramref name="other"/></returns>
		public float DistanceSquared(Vec2 other) { return Utility.Square(X - other.X) + Utility.Square(Y - other.Y); }
		/// <summary>
		/// Calculates the distance between this vector and the <paramref name="other"/> vector.
		/// Try to use <see cref="DistanceSquared(Vec2)"/> instead where possible to increase performance.
		/// Use this method with <see cref="ZERO"/> as parameter to get the magnitude.
		/// </summary>
		/// <param name="other">The second vector to calculate the distance between</param>
		/// <returns>The distance between this vector and the <paramref name="other"/></returns>
		public float Distance(Vec2 other) { return Utility.Sqrt(DistanceSquared(other)); }
		/// <summary>
		/// Calculates the dot product of this vector and the <paramref name="other"/> vector.
		/// </summary>
		/// <param name="other">The second vector to calculate a dot product with</param>
		/// <returns>Returns the dot product of this and the <paramref name="other"/> vector</returns>
		public float Dot(Vec2 other) { return X * other.X + Y * other.Y; }
		/// <summary>
		/// Calculates a normalized Vector which has the same direction as the current one but a magnitude/distance of 1.
		/// </summary>
		/// <returns>The normalized vector</returns>
		public Vec2 Normalize()
		{
			float mag = Distance(ZERO);
			return new Vec2(
				X / mag,
				Y / mag);
		}
		/// <summary>
		/// Calculates the inversion of this vector
		/// </summary>
		/// <returns>Returns the inverted version of this vector</returns>
		public Vec2 Invert() { return new Vec2(this) * -1; }

		/// <summary>
		/// Creates string representation of the current Instance.
		/// </summary>
		/// <returns>A string representing this instance</returns>
		public override string ToString() { return "[" + X + "," + Y + "]"; }
		#endregion
		#region Operators
		#region Conversion
		public static implicit operator Vec2(float src) { return new Vec2(src); }
		public static implicit operator Vec2(int src) { return new Vec2(src); }
		// The double conversion may have data loss as side effect. In most cases this is neglibligle, 
		// however if the compilation occurs with 'STRICT', it will turn into an explicit operator.
#if STRICT
		public static explicit operator Vec2(double src) { return new Vec2((float)src); }
#else
		public static implicit operator Vec2(double src) { return new Vec2((float)src); }
#endif
		public static implicit operator Vec2(long src) { return new Vec2(src); }
		//Explicit as data loss occurs
		public static explicit operator Vec2(Vec3 src) { return new Vec2(src); }
		//Todo: add type conversion from other vector classes
		#endregion
		#region Calculation
		#region Vec2 : float
		/// <summary>
		/// Multiplies a vector with a float
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> float</param>
		/// <param name="right">The right float the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec2 operator *(Vec2 left, float right) { return new Vec2(left.X * right, left.Y * right); }
		/// <summary>
		/// Divides a vector by a float
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> float</param>
		/// <param name="right">The right float the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec2 operator /(Vec2 left, float right) { return new Vec2(left.X / right, left.Y / right); }
		/// <summary>
		/// Adds a float to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> float added to</param>
		/// <param name="right">The right float to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec2 operator +(Vec2 left, float right) { return new Vec2(left.X + right, left.Y + right); }
		/// <summary>
		/// Subtracts a float from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> float subtracted from</param>
		/// <param name="right">The right float to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec2 operator -(Vec2 left, float right) { return new Vec2(left.X - right, left.Y - right); }
		#endregion
		#region Vec2 : Vec2
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec2 operator *(Vec2 left, Vec2 right) { return new Vec2(left.X * right.X, left.Y * right.Y); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec2 operator /(Vec2 left, Vec2 right) { return new Vec2(left.X / right.X, left.Y / right.Y); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec2 operator +(Vec2 left, Vec2 right) { return new Vec2(left.X + right.X, left.Y + right.Y); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec2 operator -(Vec2 left, Vec2 right) { return new Vec2(left.X - right.X, left.Y - right.Y); }
		#endregion
		#region Vec2 : Vec3
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec3 operator *(Vec2 left, Vec3 right) { return new Vec3(left.X * right.X, left.Y * right.Y, right.Z); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec3 operator /(Vec2 left, Vec3 right) { return new Vec3(left.X / right.X, left.Y / right.Y, right.Z); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec3 operator +(Vec2 left, Vec3 right) { return new Vec3(left.X + right.X, left.Y + right.Y, right.Z); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec3 operator -(Vec2 left, Vec3 right) { return new Vec3(left.X - right.X, left.Y - right.Y, right.Z); }
		#endregion
		#region Vec2 : Vec4
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec4 operator *(Vec2 left, Vec4 right) { return new Vec4(left.X * right.X, left.Y * right.Y, right.Z, right.W); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec4 operator /(Vec2 left, Vec4 right) { return new Vec4(left.X / right.X, left.Y / right.Y, right.Z, right.W); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec4 operator +(Vec2 left, Vec4 right) { return new Vec4(left.X + right.X, left.Y + right.Y, right.Z, right.W); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec4 operator -(Vec2 left, Vec4 right) { return new Vec4(left.X - right.X, left.Y - right.Y, right.Z, right.W); }
		#endregion
		#endregion
		#endregion
	}
}