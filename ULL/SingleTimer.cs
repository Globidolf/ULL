/***************************************
 *	ULL.Timers.SingleTimer
 * 
 *	Author:		Silvan Pfister
 * 
 *	Version:	0.1
 * 
 *	Project:	ULL
 * 
 ***************************************/

using System;
using System.Threading;
using static System.Threading.Timeout; 
namespace ULL.Timers
{
    public class SingleTimer : TimerBase
    {
		private int _Delay;
		public int Delay {
			get { return _Delay; }
			set { switch (TimerState) {
					case State.Running: // If the is running we have to pause it momentarily.
						Pause();
						_Delay = value;
						Start();
						break;
					default: _Delay = value; break;
			} }
		}
		
		public SingleTimer(Action action, int delay)
		{
			_Action = action;
			_Delay = delay;
			Start();
		}

		public override void Start() {
			if (TimerState != State.Running)
			{
				if (TimerState == State.Paused)
				{
					int passed = (_PauseStamp - _StartStamp).Milliseconds;
					_StartStamp = DateTime.Now.AddMilliseconds(-passed);
					_Timer.Change(Delay - passed, Infinite);
				}
				else
				{
					_StartStamp = DateTime.Now;
					_Timer = new Timer((a) => Action(), null, Delay, Infinite);
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
