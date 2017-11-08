using System;
using System.Threading;
using static System.Threading.Timeout;
namespace ULL.Timers
{
	/// <summary>
	/// This Timer will invoke a callback periodically.
	/// </summary>
    public class IntervalTimer : TimerBase
	{
		#region Fields
		private int _Interval;
		#endregion
		#region Properties
		/// <summary>
		/// The interval in which the callback is invoked periodically
		/// </summary>
		public int Interval {
			get { return _Interval; }
			set { switch (TimerState) {
					case State.Running: // If the is running we have to pause it momentarily.
						Pause();
						_Interval = value;
						Start();
						break;
					default: _Interval = value; break;
			} }
		}
		#endregion
		#region Methods
		#region Constructor
		/// <summary>
		/// Creates an instance of this <see cref="IntervalTimer"/> class
		/// </summary>
		/// <param name="action">The callback for the timer</param>
		/// <param name="interval">The interval in ms in which the callback is invoked</param>
		/// <param name="start">If true, will start the timer immediately</param>
		public IntervalTimer(Action action, int interval, bool start = false)
		{
			_Action = action;
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
			if (TimerState != State.Running)
			{
				if (TimerState == State.Paused)
				{
					int passed = (_PauseStamp - _StartStamp).Milliseconds % Interval;
					_StartStamp = DateTime.Now.AddMilliseconds(-passed);
					_Timer.Change(Interval - passed, Interval);
				}
				else
				{
					_StartStamp = DateTime.Now;
					_Timer = new Timer((a) => Action(), null, 0, Interval);
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
