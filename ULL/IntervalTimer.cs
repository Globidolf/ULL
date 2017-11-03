using System;
using System.Threading;
using static System.Threading.Timeout;
namespace ULL.Timers
{
    public class IntervalTimer : TimerBase
	{
		private int _Interval;
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
		
		public IntervalTimer(Action action, int interval)
		{
			_Action = action;
			_Interval = interval;
			Start();
		}

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
		public override void Pause()
		{
			if (TimerState != State.Paused && TimerState != State.Stopped)
			{
				_PauseStamp = DateTime.Now;
				_Timer.Change(Infinite, Infinite);
				_TimerState = State.Paused;
			}
		}
		public override void Stop()
		{
			if (TimerState != State.Stopped)
			{
				_Timer.Change(Infinite, Infinite);
				_Timer.Dispose();
				_TimerState = State.Stopped;
			}
		}
	}
}
