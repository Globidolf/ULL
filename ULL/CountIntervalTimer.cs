using System;
using System.Threading;
using static System.Threading.Timeout;
namespace ULL.Timers
{
	public class CountIntervalTimer : TimerBase
	{

		private int _Interval;
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

		private int _Counter;

		private int _Count;
		public int Count
		{
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
					_Timer = new Timer((a) => {
						if(++_Counter <= _Count)  Action(); else Stop();
					}, null, 0, Interval);
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
