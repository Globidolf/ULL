using System;
using System.Threading;
using static System.Threading.Timeout;
namespace ULL.Timers
{
	/// <summary>
	/// This Timer class will invoke a callback periodically until a specific point in time is reached.
	/// Can optionally have another callback for when the <see cref="End"/> is reached
	/// </summary>
	public class IntervalUntilTimer : TimerBase
	{
		#region Fields
		private Action _EndCallback;
		private Timer _EndTimer;
		private DateTime _End;
		private int _Interval;
		#endregion
		#region Properties
		#region Utility
		/// <summary>
		/// Calculates the time in MS until <see cref="End"/> is reached.
		/// </summary>
		private int EndTime { get { return End > DateTime.Now ? (int)(End - DateTime.Now).TotalMilliseconds : Infinite; } }
		#endregion
		/// <summary>
		/// The Interval in which the Timer is called periodically
		/// </summary>
		public int Interval
		{
			get { return _Interval; }
			set
			{
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
		/// The Moment the Timer should be stopped automatically
		/// </summary>
		public DateTime End
		{
			get { return _End; }
			set
			{
				switch (TimerState)
				{
					case State.Running:
						_End = value;
						if (value <= DateTime.Now) Stop();
						else
						{
							Pause();
							_End = value;
							Start();
						}
						break;
					default: _End = value; break;
				}
			}
		}
		/// <summary>
		/// The callback to be invoked when <see cref="End"/> is reached
		/// </summary>
		public Action EndCallback
		{
			get { return _EndCallback; }
			set
			{
				_EndCallback = value;
				if (TimerState != State.Stopped)
				{
					_EndTimer.Change(Infinite, Infinite);
					_EndTimer.Dispose();
					_EndTimer = new Timer((a) => { Stop(); _EndCallback?.Invoke(); }, null, EndTime, Infinite);
				}
			}
		}
		#endregion
		#region Methods
		#region Constructor
		/// <summary>
		/// Creates an instance of the <see cref="IntervalUntilTimer"/>
		/// </summary>
		/// <param name="action">The callback for the timer</param>
		/// <param name="interval">The interval in which the callback is called</param>
		/// <param name="end">The time to automatically stop this timer</param>
		/// <param name="endCallback">The callback for when <paramref name="end"/> is reached</param>
		/// <param name="start">If true, the timer will start immediately</param>
		public IntervalUntilTimer(Action action, int interval, DateTime end, Action endCallback = null, bool start = false)
		{
			_Action = action;
			_Interval = interval;
			_End = end;
			_EndCallback = endCallback;
			if (start) Start();
		}
		#endregion
		#region TimerBase Implementation
		/// <summary>
		/// Pauses the Timer.
		/// Note that the timer will stop in this state if <see cref="End"/> is reached while paused.
		/// <see cref="EndCallback"/> will invoke as well in that case.
		/// </summary>
		public override void Pause()
		{
			if (_TimerState == State.Running) // Can only pause when running
			{
				_Timer.Change(Infinite, Infinite);
				_TimerState = State.Paused;
			}
		}
		/// <summary>
		/// Starts or continues the Timer, unless the <see cref="End"/> has been reached.
		/// </summary>
		public override void Start()
		{
			if (TimerState != State.Running) // Ignore if running
			{
				if (EndTime != Infinite)
				{
					if (TimerState == State.Paused)
					{
						_EndTimer.Change(EndTime, Infinite);
						_Timer.Change(0, Interval);
					}
					else // Stopped or Invalid
					{
						_EndTimer = new Timer((a) => { Stop(); _EndCallback?.Invoke(); }, null, EndTime, Infinite);
						_Timer = new Timer((a) => Action(), null, 0, Interval);
					}
					_TimerState = State.Running;
				}
			}
		}
		/// <summary>
		/// Stops the Timer and frees resources
		/// </summary>
		public override void Stop()
		{
			if (TimerState != State.Stopped)
			{
				_EndTimer.Change(Infinite, Infinite);
				_Timer.Change(Infinite, Infinite);
				_EndTimer.Dispose();
				_Timer.Dispose();
				_TimerState = State.Stopped;
			}
		}
		#endregion
		#endregion
	}
}
