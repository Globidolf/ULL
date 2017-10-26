namespace ULL.Vector
{
	/// <summary>
	/// Represents a vector in 3D space
	/// </summary>
	public class Vec3
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
		/// <summary>
		/// The depth Z axis coordinate of this vector
		/// </summary>
		public float Z { get; set; }
		#endregion
		#region Constants
		/// <summary>
		/// A 3D-Vector representing the top direction (0,1,0)
		/// </summary>
		public static Vec3 TOP { get { return new Vec3(0, 1, 0); } }
		/// <summary>
		/// A 3D-Vector representing the bottom direction (0,-1,0)
		/// </summary>
		public static Vec3 BOTTOM { get { return new Vec3(0, -1, 0); } }
		/// <summary>
		/// A 3D-Vector representing the left direction (-1,0,0)
		/// </summary>
		public static Vec3 LEFT { get { return new Vec3(-1, 0, 0); } }
		/// <summary>
		/// A 3D-Vector representing the right direction (0,-1,0)
		/// </summary>
		public static Vec3 RIGHT { get { return new Vec3(1, 0, 0); } }
		/// <summary>
		/// A 4D-Vector representing the front direction (0,0,1)
		/// </summary>
		public static Vec3 FRONT { get { return new Vec3(0, 0, 1); } }
		/// <summary>
		/// A 4D-Vector representing the front direction (0,0,-1)
		/// </summary>
		public static Vec3 BACK { get { return new Vec3(0, 0, -1); } }
		/// <summary>
		/// A 3D-Vector with all values being zero (0,0,0)
		/// </summary>
		public static Vec3 ZERO { get { return new Vec3(0, 0, 0); } }
		/// <summary>
		/// A 3D-Vector with all values being one (1,1,1)
		/// </summary>
		public static Vec3 ONE { get { return new Vec3(1, 1, 1); } }
		#endregion
		#region Dimension Swap
		public Vec3 XYZ { get { return new Vec3(X, Y, Z); } }
		public Vec3 XZY { get { return new Vec3(X, Z, Y); } }
		public Vec3 YXZ { get { return new Vec3(Y, X, Z); } }
		public Vec3 YZX { get { return new Vec3(Y, Z, X); } }
		public Vec3 ZXY { get { return new Vec3(Z, X, Y); } }
		public Vec3 ZYX { get { return new Vec3(Z, Y, X); } }
		#region Downscale to Vec2
		public Vec2 XY { get { return new Vec2(X, Y); } }
		public Vec2 XZ { get { return new Vec2(X, Z); } }
		public Vec2 YX { get { return new Vec2(Y, X); } }
		public Vec2 YZ { get { return new Vec2(Y, Z); } }
		public Vec2 ZX { get { return new Vec2(Z, X); } }
		public Vec2 ZY { get { return new Vec2(Z, Y); } }
		#endregion
		#endregion
		#region Constructors
		/// <summary>
		/// Creates a 3D vector with zero distance (0,0,0)
		/// </summary>
		public Vec3() : this(0) {}
		/// <summary>
		/// Creates a 3D vector with all coordinates set to <paramref name="value"/>
		/// </summary>
		/// <param name="value">The value to set the coordinates to</param>
		public Vec3(float value) { X = Y = Z = value; }
		/// <summary>
		/// Duplicates the 3D vector <paramref name="copy"/> into a new instance.
		/// </summary>
		/// <param name="copy">The vector to duplicate</param>
		public Vec3(Vec3 copy) : this(copy.X,copy.Y,copy.Z) { }
		/// <summary>
		/// Turns a 2D vector into a 3D vector, with the remaining axis set to 0(zero).
		/// </summary>
		/// <param name="vec">The vector to duplicate</param>
		public Vec3(Vec2 vec) : this(vec.X,vec.Y,0) { }
		public Vec3(Vec4 vec) : this(vec.X, vec.Y, vec.Z) { }
		/// <summary>
		/// Creates a specific 3D vector instance with the given values
		/// </summary>
		/// <param name="x">The value of the horizontal X coordinate</param>
		/// <param name="y">The value of the vertical Y coordinate</param>
		public Vec3(float x, float y, float z) { X = x; Y = y; Z = z; }
		#endregion
		#region Methods
		/// <summary>
		/// Calculates the squared distance between this vector and the <paramref name="other"/> vector.
		/// Use this instead of <see cref="Distance(Vec3)"/> where possible to increase performance.
		/// </summary>
		/// <param name="other">The second vector to calculate the distance between</param>
		/// <returns>The squared distance between this vector and the <paramref name="other"/></returns>
		public float DistanceSquared(Vec3 other) { return Utility.Square(X - other.X) + Utility.Square(Y - other.Y) + Utility.Square(Z - other.Z); }
		/// <summary>
		/// Calculates the distance between this vector and the <paramref name="other"/> vector.
		/// Try to use <see cref="DistanceSquared(Vec3)"/> instead where possible to increase performance.
		/// Use this method with <see cref="ZERO"/> as parameter to get the magnitude.
		/// </summary>
		/// <param name="other">The second vector to calculate the distance between</param>
		/// <returns>The distance between this vector and the <paramref name="other"/></returns>
		public float Distance(Vec3 other) { return Utility.Sqrt(DistanceSquared(other)); }
		/// <summary>
		/// Calculates the dot product of this vector and the <paramref name="other"/> vector.
		/// </summary>
		/// <param name="other">The second vector to calculate a dot product with</param>
		/// <returns>Returns the dot product of this and the <paramref name="other"/> vector</returns>
		public float Dot(Vec3 other) { return X * other.X + Y * other.Y + Z * other.Z; }
		/// <summary>
		/// Calculates the cross vector from this vector and the <paramref name="other"/> vector.
		/// </summary>
		/// <param name="other">The second vector to calculate the cross vector from</param>
		/// <returns>Returns the cross vector of this and the <paramref name="other"/> vector</returns>
		public Vec3 Cross(Vec3 other) { return new Vec3(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X); }
		/// <summary>
		/// Calculates a normalized Vector which has the same direction as the current one but a magnitude/distance of 1.
		/// </summary>
		/// <returns>The normalized vector</returns>
		public Vec3 Normalize()
		{
			float mag = Distance(ZERO);
			return new Vec3(
				X / mag,
				Y / mag,
				Z / mag);
		}
		/// <summary>
		/// Calculates the inversion of this vector
		/// </summary>
		/// <returns>Returns the inverted version of this vector</returns>
		public Vec3 Invert() { return new Vec3(this) * -1; }
		#endregion
		#region Operators
		#region Conversion
		public static implicit operator Vec3(float src) { return new Vec3(src); }
		public static implicit operator Vec3(int src) { return new Vec3(src); }
		// The double conversion may have data loss as side effect. In most cases this is neglibligle, 
		// however if the compilation occurs with 'STRICT', it will turn into an explicit operator.
#if STRICT
		public static explicit operator Vec3(double src) { return new Vec3((float)src); }
#else
		public static implicit operator Vec3(double src) { return new Vec3((float)src); }
#endif
		public static implicit operator Vec3(long src) { return new Vec3(src); }
		public static implicit operator Vec3(Vec2 src) { return new Vec3(src); }
		public static implicit operator Vec3(Vec4 src) { return new Vec3(src); }
#endregion
		#region Calculation
		#region Vec3 : float
		/// <summary>
		/// Multiplies a vector with a float
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> float</param>
		/// <param name="right">The right float the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec3 operator *(Vec3 left, float right) { return new Vec3(left.X * right, left.Y * right, left.Z * right); }
		/// <summary>
		/// Divides a vector by a float
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> float</param>
		/// <param name="right">The right float the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec3 operator /(Vec3 left, float right) { return new Vec3(left.X / right, left.Y / right, left.Z / right); }
		/// <summary>
		/// Adds a float to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> float added to</param>
		/// <param name="right">The right float to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec3 operator +(Vec3 left, float right) { return new Vec3(left.X + right, left.Y + right, left.Z + right); }
		/// <summary>
		/// Subtracts a float from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> float subtracted from</param>
		/// <param name="right">The right float to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec3 operator -(Vec3 left, float right) { return new Vec3(left.X - right, left.Y - right, left.Z - right); }
		#endregion
		#region Vec3 : Vec3
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec3 operator *(Vec3 left, Vec3 right) { return new Vec3(left.X * right.X, left.Y * right.Y, left.Z * right.Z); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec3 operator /(Vec3 left, Vec3 right) { return new Vec3(left.X / right.X, left.Y / right.Y, left.Z / right.Z); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec3 operator +(Vec3 left, Vec3 right) { return new Vec3(left.X + right.X, left.Y + right.Y, left.Z + right.Z); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec3 operator -(Vec3 left, Vec3 right) { return new Vec3(left.X - right.X, left.Y - right.Y, left.Z - right.Z); }
		#endregion
		#region Vec3 : Vec2
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec3 operator *(Vec3 left, Vec2 right) { return new Vec3(left.X * right.X, left.Y * right.Y, left.Z); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec3 operator /(Vec3 left, Vec2 right) { return new Vec3(left.X / right.X, left.Y / right.Y, left.Z); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec3 operator +(Vec3 left, Vec2 right) { return new Vec3(left.X + right.X, left.Y + right.Y, left.Z); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec3 operator -(Vec3 left, Vec2 right) { return new Vec3(left.X - right.X, left.Y - right.Y, left.Z); }
		#endregion
		#region Vec3 : Vec4
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec4 operator *(Vec3 left, Vec4 right) { return new Vec4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, right.W); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec4 operator /(Vec3 left, Vec4 right) { return new Vec4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, right.W); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec4 operator +(Vec3 left, Vec4 right) { return new Vec4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, right.W); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec4 operator -(Vec3 left, Vec4 right) { return new Vec4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, right.W); }
		#endregion
		#endregion
		#endregion
	}
}