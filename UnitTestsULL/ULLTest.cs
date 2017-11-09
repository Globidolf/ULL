using System;
using ULL.Vectors;
using ULL.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTestsULL
{
	[TestClass]
	public class ULLTest
	{
		#region Fields

		/// <summary>
		/// Random Number Generator
		/// </summary>
		Random RNG;

		/// <summary>
		/// Coordinate Values
		/// </summary>
		float X, Y, Z, W, W2, Z2, Y2, X2;
		
		/// <summary>
		/// Timer Values. D -> Delay, I -> Interval, C -> Count
		/// </summary>
		int D, I, C;

		/// <summary>
		/// Tolerable deviation from expectation
		/// </summary>
		double Delta;

		#endregion

		[TestInitialize]
		public void Init()
		{
			Delta = 0.0000002;
			RNG = new Random();
			X = (float)(RNG.Next() - int.MaxValue / 2) / 1000;
			Y = (float)(RNG.Next() - int.MaxValue / 2) / 1000;
			Z = (float)(RNG.Next() - int.MaxValue / 2) / 1000;
			W = (float)(RNG.Next() - int.MaxValue / 2) / 1000;

			X2 = (float)(RNG.Next() - int.MaxValue / 2) / 1000;
			Y2 = (float)(RNG.Next() - int.MaxValue / 2) / 1000;
			Z2 = (float)(RNG.Next() - int.MaxValue / 2) / 1000;
			W2 = (float)(RNG.Next() - int.MaxValue / 2) / 1000;

			D = RNG.Next(800, 1200);
			I = RNG.Next(1000 / 10, 1000 / 2);
			C = RNG.Next(4, 12);
		}

		#region Vec2
		[TestCategory("Vec2")]
		[TestCategory("SQRT")]
		[TestMethod]
		public void Vec2Distance()
		{
			Vec2 Source1 = new Vec2(X, Y);
			Vec2 Source2 = new Vec2(X2, Y2);
			float Expected = (float)Math.Sqrt((X2 - X) * (X2 - X) + (Y2 - Y) * (Y2 - Y));
			Assert.AreEqual(Expected / Source1.Distance(Source2), 1, Delta);
		}
		[TestCategory("Vec2")]
		[TestCategory("SQRT")]
		[TestMethod]
		public void Vec2DistanceZero()
		{
			Vec2 Source = new Vec2(X, Y);
			float Expected = (float)Math.Sqrt(X * X + Y * Y);
			Assert.AreEqual(Expected / Source.Distance(Vec2.ZERO), 1, Delta);
		}
		[TestCategory("Vec2")]
		[TestMethod]
		public void Vec2Mix()
		{
			Vec2 Source = new Vec2(X, Y);
			Vec2 Expected = new Vec2(Y, X);
			Assert.AreEqual(Expected, Source.YX);
		}
		[TestCategory("Vec2")]
		[TestCategory("Vec4")]
		[TestMethod]
		public void Vec2ToV4()
		{
			Vec2 Source = new Vec2(X, Y);
			Vec4 Expected = new Vec4(X, Y, 0, 0);
			Assert.AreEqual(Expected, Source);
		}
		[TestCategory("Vec2")]
		[TestCategory("Vec3")]
		[TestMethod]
		public void Vec2ToV3()
		{
			Vec2 Source = new Vec2(X,Y);
			Vec3 Expected = new Vec3(X, Y, 0);
			Assert.AreEqual(Expected, Source);
		}
		#endregion
		#region Vec3
		[TestCategory("Vec3")]
		[TestCategory("Vec2")]
		[TestMethod]
		public void Vec3ToV2()
		{
			Vec3 Source = new Vec3(X, Y, Z);
			Vec2 Expected = new Vec2(X, Y);
			Assert.AreEqual(Expected, (Vec2)Source);
		}
		[TestCategory("Vec4")]
		[TestCategory("Vec3")]
		[TestMethod]
		public void Vec3ToV4()
		{
			Vec3 Source = new Vec3(X, Y, Z);
			Vec4 Expected = new Vec4(X, Y, Z, 0);
			Assert.AreEqual<Vec4>(Expected, Source);
		}
		[TestCategory("Vec3")]
		[TestCategory("Vec2")]
		[TestMethod]
		public void Vec3Mixes()
		{
			Vec3 Source = new Vec3(X, Y, Z);
			Vec3 XZY = new Vec3(X, Z, Y);
			Vec3 YXZ = new Vec3(Y, X, Z);
			Vec3 YZX = new Vec3(Y, Z, X);
			Vec3 ZYX = new Vec3(Z, Y, X);
			Vec3 ZXY = new Vec3(Z, X, Y);

			Vec2 XY = new Vec2(X, Y);
			Vec2 XZ = new Vec2(X, Z);
			Vec2 YX = new Vec2(Y, X);
			Vec2 YZ = new Vec2(Y, Z);
			Vec2 ZX = new Vec2(Z, X);
			Vec2 ZY = new Vec2(Z, Y);

			Assert.AreEqual(XZY, Source.XZY);
			Assert.AreEqual(YXZ, Source.YXZ);
			Assert.AreEqual(YZX, Source.YZX);
			Assert.AreEqual(ZXY, Source.ZXY);
			Assert.AreEqual(ZYX, Source.ZYX);

			Assert.AreEqual(XY, Source.XY);
			Assert.AreEqual(XZ, Source.XZ);
			Assert.AreEqual(YX, Source.YX);
			Assert.AreEqual(YZ, Source.YZ);
			Assert.AreEqual(ZX, Source.ZX);
			Assert.AreEqual(ZY, Source.ZY);
		}
		[TestCategory("Vec3")]
		[TestCategory("SQRT")]
		[TestMethod]
		public void Vec3Distance()
		{
			Vec3 Source1 = new Vec3(X, Y, Z);
			Vec3 Source2 = new Vec3(X2, Y2, Z2);
			float Expected = (float)Math.Sqrt((X2 - X) * (X2 - X) + (Y2 - Y) * (Y2 - Y) + (Z2 - Z) * (Z2 - Z));
			Assert.AreEqual(Expected / Source1.Distance(Source2), 1, Delta);
		}
		[TestCategory("Vec3")]
		[TestCategory("SQRT")]
		[TestMethod]
		public void Vec3DistanceZero()
		{
			Vec3 Source = new Vec3(X, Y, Z);
			float Expected = (float)Math.Sqrt(X * X + Y * Y + Z * Z);
			Assert.AreEqual(Expected / Source.Distance(Vec2.ZERO), 1, Delta);
		}
		#endregion
		#region Vec4
		[TestCategory("Vec4")]
		[TestCategory("Vec3")]
		[TestCategory("Vec2")]
		[TestMethod]
		public void Vec4Mixes()
		{
			Vec4 Source = new Vec4(X, Y, Z, W);


			Vec3 XZY = new Vec3(X, Z, Y);
			Vec3 YXZ = new Vec3(Y, X, Z);
			Vec3 YZX = new Vec3(Y, Z, X);
			Vec3 ZYX = new Vec3(Z, Y, X);
			Vec3 ZXY = new Vec3(Z, X, Y);

			Vec2 XY = new Vec2(X, Y);
			Vec2 XZ = new Vec2(X, Z);
			Vec2 YX = new Vec2(Y, X);
			Vec2 YZ = new Vec2(Y, Z);
			Vec2 ZX = new Vec2(Z, X);
			Vec2 ZY = new Vec2(Z, Y);

			Assert.AreEqual(XZY, Source.XZY);
			Assert.AreEqual(YXZ, Source.YXZ);
			Assert.AreEqual(YZX, Source.YZX);
			Assert.AreEqual(ZXY, Source.ZXY);
			Assert.AreEqual(ZYX, Source.ZYX);

			Assert.AreEqual(XY, Source.XY);
			Assert.AreEqual(XZ, Source.XZ);
			Assert.AreEqual(YX, Source.YX);
			Assert.AreEqual(YZ, Source.YZ);
			Assert.AreEqual(ZX, Source.ZX);
			Assert.AreEqual(ZY, Source.ZY);
		}
		[TestCategory("Vec4")]
		[TestCategory("SQRT")]
		[TestMethod]
		public void Vec4Distance()
		{
			Vec4 Source1 = new Vec4(X, Y, Z, W);
			Vec4 Source2 = new Vec4(X2, Y2, Z2, W2);
			float Expected = (float)Math.Sqrt(
				(X2 - X) * (X2 - X) + 
				(Y2 - Y) * (Y2 - Y) + 
				(Z2 - Z) * (Z2 - Z) + 
				(W2 - W) * (W2 - W));
			Assert.AreEqual(Expected / Source1.Distance(Source2), 1, Delta);
		}
		[TestCategory("Vec4")]
		[TestCategory("SQRT")]
		[TestMethod]
		public void Vec4DistanceZero()
		{
			Vec4 Source = new Vec4(X, Y, Z, W);
			float Expected = (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
			Assert.AreEqual(Expected / Source.Distance(Vec4.ZERO), 1, Delta);
		}
		#endregion
		#region Timers
		[TestCategory("SingleTimer")]
		[TestMethod]
		public void SingleTimerTest()
		{
			bool done = false;
			DateTime TEnd = new DateTime(), TStart;

			new SingleTimer(() => done = true, D, true);
			TStart = DateTime.Now;

			Task.Run(() =>
			{
				while (!done) ;
				TEnd = DateTime.Now;
			}).Wait();
			
			Assert.AreEqual(D, (TEnd - TStart).TotalMilliseconds, D / 100f);
		}

		[TestCategory("SingleTimer")]
		[TestCategory("IntervalTimer")]
		[TestMethod]
		public void IntervalTimerTest()
		{
			bool done = false;
			int counter = 0;
			new SingleTimer(() => done = true, I * C, true);
			IntervalTimer IT = new IntervalTimer(() => counter++, I, true);

			Task.Run(() =>
			{
				while (!done) ;
				IT.Stop();
			}).Wait();

			Assert.AreEqual(C, counter);
		}

		[TestCategory("IntervalUntilTimer")]
		[TestMethod]
		public void IntervalUntilTimer()
		{
			bool done = false;
			int counter = 0;
			DateTime TEnd = new DateTime(), TStart;

			new IntervalUntilTimer(() => counter++, I, DateTime.Now.AddMilliseconds(D), () => done=true, true);
			TStart = DateTime.Now;

			Task.Run(() =>
			{
				while (!done) ;
				TEnd = DateTime.Now;
			}).Wait();

			Assert.AreEqual(D, (TEnd - TStart).TotalMilliseconds, D / 10f);
			Assert.AreEqual(D / I + 1, counter);
		}
		[TestCategory("CountIntervalTimer")]
		[TestMethod]
		public void CountIntervalTimer()
		{
			bool done = false;
			int counter = 0;
			DateTime TEnd = new DateTime(), TStart;
			new CountIntervalTimer(() => counter++, C, I, ()=> done = true, true);
			TStart = DateTime.Now;

			Task.Run(() =>
			{
				while (!done) ;
				TEnd = DateTime.Now;
			}).Wait();

			Assert.AreEqual(I * C, (TEnd - TStart).TotalMilliseconds, I * C / 10f);
			Assert.AreEqual(C, counter);
		}
		#endregion
	}
}
