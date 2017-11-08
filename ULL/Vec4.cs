namespace ULL.Vector
{
	/// <summary>
	/// Represents a vector in 4D space
	/// </summary>
	public class Vec4
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
		/// <summary>
		/// The depth W axis coordinate of this vector
		/// </summary>
		public float W { get; set; }
		#region Constants
		/// <summary>
		/// A 4D-Vector representing the top direction (0,1,0)
		/// </summary>
		public static Vec4 TOP { get { return new Vec4(0, 1, 0, 0); } }
		/// <summary>
		/// A 4D-Vector representing the bottom direction (0,-1,0)
		/// </summary>
		public static Vec4 BOTTOM { get { return new Vec4(0, -1, 0, 0); } }
		/// <summary>
		/// A 4D-Vector representing the left direction (-1,0,0)
		/// </summary>
		public static Vec4 LEFT { get { return new Vec4(-1, 0, 0, 0); } }
		/// <summary>
		/// A 4D-Vector representing the right direction (0,-1,0)
		/// </summary>
		public static Vec4 RIGHT { get { return new Vec4(1, 0, 0, 0); } }
		/// <summary>
		/// A 4D-Vector representing the front direction (0,0,1,0)
		/// </summary>
		public static Vec4 FRONT { get { return new Vec4(0, 0, 1, 0); } }
		/// <summary>
		/// A 4D-Vector representing the front direction (0,0,-1,0)
		/// </summary>
		public static Vec4 BACK { get { return new Vec4(0, 0, -1, 0); } }
		/// <summary>
		/// A 4D-Vector with the W-axis set to 1(one) (0,0,0,1)
		/// </summary>
		public static Vec4 WPLUS { get { return new Vec4(0, 0, 0, 1); } }
		/// <summary>
		/// A 4D-Vector with the W-axis set to -1(one) (0,0,0,-1)
		/// </summary>
		public static Vec4 WMINUS { get { return new Vec4(0, 0, 0, -1); } }
		/// <summary>
		/// A 4D-Vector with all values being zero (0,0,0)
		/// </summary>
		public static Vec4 ZERO { get { return new Vec4(0, 0, 0, 0); } }
		/// <summary>
		/// A 4D-Vector with all values being one (1,1,1,1)
		/// </summary>
		public static Vec4 ONE { get { return new Vec4(1, 1, 1, 1); } }
		#endregion
		#region Dimension Swap
		public Vec4 XYZW { get { return new Vec4(X, Y, Z, W); } }
		public Vec4 XZYW { get { return new Vec4(X, Z, Y, W); } }
		public Vec4 YXZW { get { return new Vec4(Y, X, Z, W); } }
		public Vec4 YZXW { get { return new Vec4(Y, Z, X, W); } }
		public Vec4 ZXYW { get { return new Vec4(Z, X, Y, W); } }
		public Vec4 ZYXW { get { return new Vec4(Z, Y, X, W); } }

		public Vec4 XYWZ { get { return new Vec4(X, Y, W, Z); } }
		public Vec4 XZWY { get { return new Vec4(X, Z, W, Y); } }
		public Vec4 YXWZ { get { return new Vec4(Y, X, W, Z); } }
		public Vec4 YZWX { get { return new Vec4(Y, Z, W, X); } }
		public Vec4 ZXWY { get { return new Vec4(Z, X, W, Y); } }
		public Vec4 ZYWX { get { return new Vec4(Z, Y, W, X); } }

		public Vec4 XWYZ { get { return new Vec4(X, W, Y, Z); } }
		public Vec4 XWZY { get { return new Vec4(X, W, Z, Y); } }
		public Vec4 YWXZ { get { return new Vec4(Y, W, X, Z); } }
		public Vec4 YWZX { get { return new Vec4(Y, W, Z, X); } }
		public Vec4 ZWXY { get { return new Vec4(Z, W, X, Y); } }
		public Vec4 ZWYX { get { return new Vec4(Z, W, Y, X); } }

		public Vec4 WXYZ { get { return new Vec4(W, X, Y, Z); } }
		public Vec4 WXZY { get { return new Vec4(W, X, Z, Y); } }
		public Vec4 WYXZ { get { return new Vec4(W, Y, X, Z); } }
		public Vec4 WYZX { get { return new Vec4(W, Y, Z, X); } }
		public Vec4 WZXY { get { return new Vec4(W, Z, X, Y); } }
		public Vec4 WZYX { get { return new Vec4(W, Z, Y, X); } }
		#region Downscale to Vec3
		public Vec3 XYW { get { return new Vec3(X, Y, W); } }
		public Vec3 XZW { get { return new Vec3(X, Z, W); } }
		public Vec3 YXW { get { return new Vec3(Y, X, W); } }
		public Vec3 YZW { get { return new Vec3(Y, Z, W); } }
		public Vec3 ZXW { get { return new Vec3(Z, X, W); } }
		public Vec3 ZYW { get { return new Vec3(Z, Y, W); } }

		public Vec3 XWZ { get { return new Vec3(X, W, Z); } }
		public Vec3 XWY { get { return new Vec3(X, W, Y); } }
		public Vec3 YWZ { get { return new Vec3(Y, W, Z); } }
		public Vec3 YWX { get { return new Vec3(Y, W, X); } }
		public Vec3 ZWY { get { return new Vec3(Z, W, Y); } }
		public Vec3 ZWX { get { return new Vec3(Z, W, X); } }

		public Vec3 WYZ { get { return new Vec3(W, Y, Z); } }
		public Vec3 WZY { get { return new Vec3(W, Z, Y); } }
		public Vec3 WXZ { get { return new Vec3(W, X, Z); } }
		public Vec3 WZX { get { return new Vec3(W, Z, X); } }
		public Vec3 WXY { get { return new Vec3(W, X, Y); } }
		public Vec3 WYX { get { return new Vec3(W, Y, X); } }

		public Vec3 XYZ { get { return new Vec3(X, Y, Z); } }
		public Vec3 XZY { get { return new Vec3(X, Z, Y); } }
		public Vec3 YXZ { get { return new Vec3(Y, X, Z); } }
		public Vec3 YZX { get { return new Vec3(Y, Z, X); } }
		public Vec3 ZXY { get { return new Vec3(Z, X, Y); } }
		public Vec3 ZYX { get { return new Vec3(Z, Y, X); } }
		#endregion
		#region Downscale to Vec2
		public Vec2 YX { get { return new Vec2(Y, X); } }
		public Vec2 XY { get { return new Vec2(X, Y); } }
		public Vec2 XZ { get { return new Vec2(X, Z); } }
		public Vec2 ZX { get { return new Vec2(Z, X); } }
		public Vec2 YZ { get { return new Vec2(Y, Z); } }
		public Vec2 ZY { get { return new Vec2(Z, Y); } }

		public Vec2 WX { get { return new Vec2(W, X); } }
		public Vec2 WY { get { return new Vec2(W, Y); } }
		public Vec2 WZ { get { return new Vec2(W, Z); } }
		public Vec2 XW { get { return new Vec2(X, W); } }
		public Vec2 YW { get { return new Vec2(Y, W); } }
		public Vec2 ZW { get { return new Vec2(Z, W); } }
		#endregion
		#endregion
		#endregion
		#region Constructors
		/// <summary>
		/// Creates a 4D vector with zero distance (0,0,0)
		/// </summary>
		public Vec4() : this(0) {}
		/// <summary>
		/// Creates a 4D vector with all coordinates set to <paramref name="value"/>
		/// </summary>
		/// <param name="value">The value to set the coordinates to</param>
		public Vec4(float value) { X = Y = Z = W = value; }
		/// <summary>
		/// Duplicates the 4D vector <paramref name="copy"/> into a new instance.
		/// </summary>
		/// <param name="copy">The vector to duplicate</param>
		public Vec4(Vec4 copy) : this(copy.X,copy.Y,copy.Z,copy.W) { }
		/// <summary>
		/// Turns a 3D vector into a 4D vector, with the remaining axis set to 0(zero).
		/// </summary>
		/// <param name="vec">The vector to duplicate</param>
		public Vec4(Vec3 vec) : this(vec.X, vec.Y, vec.Z, 0) { }
		/// <summary>
		/// Turns a 2D vector into a 4D vector, with the remaining axis set to 0(zero).
		/// </summary>
		/// <param name="vec">The vector to duplicate</param>
		public Vec4(Vec2 vec) : this(vec.X,vec.Y,0,0) { }
		/// <summary>
		/// Creates a specific 4D vector instance with the given values
		/// </summary>
		/// <param name="x">The value of the horizontal X coordinate</param>
		/// <param name="y">The value of the vertical Y coordinate</param>
		/// <param name="z">The value of the depth Z coordinate</param>
		/// <param name="w">The value of the fourth W coordinate</param>
		public Vec4(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
		#endregion
		#region Methods
		/// <summary>
		/// Calculates the squared distance between this vector and the <paramref name="other"/> vector.
		/// Use this instead of <see cref="Distance(Vec4)"/> where possible to increase performance.
		/// </summary>
		/// <param name="other">The second vector to calculate the distance between</param>
		/// <returns>The squared distance between this vector and the <paramref name="other"/></returns>
		public float DistanceSquared(Vec4 other) { return Utility.Square(X - other.X) + Utility.Square(Y - other.Y) + Utility.Square(Z - other.Z) + Utility.Square(W - other.W); }
		/// <summary>
		/// Calculates the distance between this vector and the <paramref name="other"/> vector.
		/// Try to use <see cref="DistanceSquared(Vec4)"/> instead where possible to increase performance.
		/// Use this method with <see cref="ZERO"/> as parameter to get the magnitude.
		/// </summary>
		/// <param name="other">The second vector to calculate the distance between</param>
		/// <returns>The distance between this vector and the <paramref name="other"/></returns>
		public float Distance(Vec4 other) { return Utility.Sqrt(DistanceSquared(other)); }
		/// <summary>
		/// Calculates the dot product of this vector and the <paramref name="other"/> vector.
		/// </summary>
		/// <param name="other">The second vector to calculate a dot product with</param>
		/// <returns>Returns the dot product of this and the <paramref name="other"/> vector</returns>
		public float Dot(Vec4 other) { return X * other.X + Y * other.Y + Z * other.Z + W * other.W; }
		/// <summary>
		/// Calculates a normalized Vector which has the same direction as the current one but a magnitude/distance of 1.
		/// </summary>
		/// <returns>The normalized vector</returns>
		public Vec4 Normalize()
		{
			float mag = Distance(ZERO);
			return new Vec4(
				X / mag,
				Y / mag,
				Z / mag,
				W / mag);
		}
		/// <summary>
		/// Calculates the inversion of this vector
		/// </summary>
		/// <returns>Returns the inverted version of this vector</returns>
		public Vec4 Invert() { return new Vec4(this) * -1; }
		/// <summary>
		/// Creates string representation of the current Instance.
		/// </summary>
		/// <returns>A string representing this instance</returns>
		public override string ToString() { return "[" + X + "," + Y + ","+Z+","+W+"]"; }
		#endregion
		#region Operators
		#region Conversion
		public static implicit operator Vec4(float src) { return new Vec4(src); }
		public static implicit operator Vec4(int src) { return new Vec4(src); }
		// The double conversion may have data loss as side effect. In most cases this is neglibligle, 
		// however if the compilation occurs with 'STRICT', it will turn into an explicit operator.
#if STRICT
		public static explicit operator Vec4(double src) { return new Vec4((float)src); }
#else
		public static implicit operator Vec4(double src) { return new Vec4((float)src); }
#endif
		public static implicit operator Vec4(long src) { return new Vec4(src); }
		public static implicit operator Vec4(Vec2 src) { return new Vec4(src); }
		public static implicit operator Vec4(Vec3 src) { return new Vec4(src); }
#endregion
		#region Calculation
		#region Vec4 : float
		/// <summary>
		/// Multiplies a vector with a float
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> float</param>
		/// <param name="right">The right float the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec4 operator *(Vec4 left, float right) { return new Vec4(left.X * right, left.Y * right, left.Z * right, left.W * right); }
		/// <summary>
		/// Divides a vector by a float
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> float</param>
		/// <param name="right">The right float the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec4 operator /(Vec4 left, float right) { return new Vec4(left.X / right, left.Y / right, left.Z / right, left.W / right); }
		/// <summary>
		/// Adds a float to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> float added to</param>
		/// <param name="right">The right float to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec4 operator +(Vec4 left, float right) { return new Vec4(left.X + right, left.Y + right, left.Z + right, left.W + right); }
		/// <summary>
		/// Subtracts a float from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> float subtracted from</param>
		/// <param name="right">The right float to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec4 operator -(Vec4 left, float right) { return new Vec4(left.X - right, left.Y - right, left.Z - right, left.W - right); }
		#endregion
		#region Vec4 : Vec4
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec4 operator *(Vec4 left, Vec4 right) { return new Vec4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec4 operator /(Vec4 left, Vec4 right) { return new Vec4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec4 operator +(Vec4 left, Vec4 right) { return new Vec4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec4 operator -(Vec4 left, Vec4 right) { return new Vec4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W); }
		#endregion
		#region Vec4 : Vec3
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec4 operator *(Vec4 left, Vec3 right) { return new Vec4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec4 operator /(Vec4 left, Vec3 right) { return new Vec4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec4 operator +(Vec4 left, Vec3 right) { return new Vec4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec4 operator -(Vec4 left, Vec3 right) { return new Vec4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W); }
		#endregion
		#region Vec4 : Vec2
		/// <summary>
		/// Multiplies a vector with a vector
		/// </summary>
		/// <param name="left">The left vector to be multiplied with the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is multiplied with </param>
		/// <returns>returns the product of the multiplication</returns>
		public static Vec4 operator *(Vec4 left, Vec2 right) { return new Vec4(left.X * right.X, left.Y * right.Y, left.Z, left.W); }
		/// <summary>
		/// Divides a vector by a vector
		/// </summary>
		/// <param name="left">The left vector to be divided by the <paramref name="right"/> vector</param>
		/// <param name="right">The right vector the <paramref name="left"/> vector is divided by</param>
		/// <returns>returns the result of the division</returns>
		public static Vec4 operator /(Vec4 left, Vec2 right) { return new Vec4(left.X / right.X, left.Y / right.Y, left.Z, left.W); }
		/// <summary>
		/// Adds a vector to a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector added to</param>
		/// <param name="right">The right vector to add to the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the addition</returns>
		public static Vec4 operator +(Vec4 left, Vec2 right) { return new Vec4(left.X + right.X, left.Y + right.Y, left.Z, left.W); }
		/// <summary>
		/// Subtracts a vector from a vector
		/// </summary>
		/// <param name="left">The left vector to have the <paramref name="right"/> vector subtracted from</param>
		/// <param name="right">The right vector to subtract from the <paramref name="left"/> vector</param>
		/// <returns>returns the result of the subtraction</returns>
		public static Vec4 operator -(Vec4 left, Vec2 right) { return new Vec4(left.X - right.X, left.Y - right.Y, left.Z, left.W); }
#endregion
#endregion
#endregion
	}
}