/***************************************
 *	ULL.Timers.TimerBase
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
	public abstract class TimerBase
	{
		protected DateTime _StartStamp;
		protected DateTime _PauseStamp;
		protected Timer _Timer;
		protected Action _Action;
		protected State _TimerState;

		public State TimerState {
			get { return _TimerState; }
			set {
				switch (value)
				{
					case State.Invalid: break;
					case State.Running: Start(); break;
					case State.Paused: Pause(); break;
					case State.Stopped: Stop(); break;
				}
			}
		}
		public Action Action {
			get { return _Action; }
			set {
				if (TimerState == State.Stopped) _Action = value;
				else if (TimerState != State.Invalid)
				{
					bool wasRunning = TimerState == State.Running;                  // Store the current state
					if (wasRunning) Pause();                                        // Ensure that the pause stamp is set
					Stop();                                                         // Deletes Current Timer (and as side effect applies the stopped state)
					_Action = value;                                                // Apply new action
					_Timer = new Timer((a) => Action(), null, Infinite, Infinite);  // Create a paused timer with the new action
					_TimerState = State.Paused;                                     // Handle the situation as if the timer was paused all along.
					if (wasRunning) Start();                                        // Continue if the timer was running
				}
			}
		}

		public abstract void Start();
		public abstract void Pause();
		public abstract void Stop();

	}
}