/***************************************
 *	ULL.Timers.CountIntervalTimer
 * 
 *	Author:		Silvan Pfister
 * 
 *	Version:	1.0
 * 
 *	Project:	ULL
 * 
 ***************************************/

using System;
using System.Threading;
using static System.Threading.Timeout;
namespace ULL.Timers
{
	/// <summary>
	/// This timer will invoke a callback a certain amount of times periodically
	/// </summary>
	public class CountIntervalTimer : TimerBase
	{
		#region Fields
		private int _Interval;
		private int _Counter;
		private int _Count;
		#endregion
		#region Properties
		/// <summary>
		/// The interval in which the callback is invoked periodically
		/// </summary>
		public int Interval {
			get { return _Interval; }
			set {
				switch (TimerState)
				{
					case State.Running: // If the is running we have to pause it momentarily.
						Pause();
						_Interval = value;
						Start();
						break;
					default: _Interval = value; break;
				}
			}
		}
		/// <summary>
		/// The total amount of times the callback can be invoked by this timer
		/// </summary>
		public int Count {
			get { return _Count; }
			set {
				switch (TimerState)
				{
					case State.Running:
						if (_Counter >= value) // New value causes the counter reach the max count. Stop and don't resume
						{
							Stop();
							_Count = value;
						}
						else
						{
							Pause();
							_Count = value;
							Start();
						}
						break;
					default: _Count = value; break;
				}
			}
		}
		#endregion
		#region Methods
		#region Constructor
		public CountIntervalTimer(Action action, int count, int interval, bool start = false)
		{
			_Action = action;
			_Count = count;
			_Interval = interval;
			if (start) Start();
		}
		#endregion
		#region TimerBase Implementation
		/// <summary>
		/// Starts or continues the timer. Is ignored if the Timer is running while called.
		/// </summary>
		public override void Start()
		{
			if (TimerState != State.Running) // ignore if running
			{
				if (TimerState == State.Paused) // calculate offset and modify startstamp, restart timer with interval offset from pause
				{
					int passed = (_PauseStamp - _StartStamp).Milliseconds;
					_StartStamp = DateTime.Now.AddMilliseconds(-passed);
					_Timer.Change(Interval - (passed % Interval), Interval); // (passed % interval) is the amount of time missing from the previous interval
				}
				else // reset counter, set start time, create timer
				{
					_Counter = 0;
					_StartStamp = DateTime.Now;
					_Timer = new Timer((a) =>
					{
						if (++_Counter <= _Count) Action(); else Stop();
					}, null, 0, Interval);
				}
				_TimerState = State.Running;
			}
		}
		/// <summary>
		/// Pauses the timer if it is currently running.
		/// </summary>
		public override void Pause()
		{
			if (TimerState != State.Paused && TimerState != State.Stopped)
			{
				_PauseStamp = DateTime.Now;
				_Timer.Change(Infinite, Infinite);
				_TimerState = State.Paused;
			}
		}
		/// <summary>
		/// Stops the timer and frees resources
		/// </summary>
		public override void Stop()
		{
			if (TimerState != State.Stopped)
			{
				_Timer.Change(Infinite, Infinite);
				_Timer.Dispose();
				_TimerState = State.Stopped;
			}
		}
		#endregion
		#endregion
	}
}