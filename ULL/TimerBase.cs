/***************************************
 *	ULL.Timers.TimerBase
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
	/// The base class for all timers, providing generic functionality propably used by all implementations.
	/// </summary>
	public abstract class TimerBase
	{
		#region Fields
		/// <summary>
		/// The point in time the Timer started
		/// </summary>
		protected DateTime _StartStamp;
		/// <summary>
		/// The point in time the Timer paused
		/// </summary>
		protected DateTime _PauseStamp;
		/// <summary>
		/// The actual timer
		/// </summary>
		protected Timer _Timer;
		/// <summary>
		/// The callback for the timer
		/// </summary>
		protected Action _Action;
		/// <summary>
		/// The current state of the timer
		/// </summary>
		protected State _TimerState;
		#endregion
		#region Properties
		/// <summary>
		/// Gets or Sets the state of the current timer.
		/// Will invoke the corresponding method if set.
		/// </summary>
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
		/// <summary>
		/// Gets or Sets the callback of the timer.
		/// Can be set while the timer is running.
		/// </summary>
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
		#endregion
		#region Methods
		/// <summary>
		/// The start method of the timer.
		/// <para>
		/// Set <see cref="_StartStamp"/> to <see cref="DateTime.Now"/>
		/// as well as <see cref="TimerState"/> to <see cref="State.Running"/> here.
		/// Also configure and run the <see cref="_Timer"/> here.
		/// </para>
		/// <para>
		/// Handle the case in which the timer is paused by calling <see cref="Timer.Change(int, int)"/>
		/// and set <see cref="_StartStamp"/> to (<see cref="DateTime.Now"/> - (<see cref="_PauseStamp"/> - <see cref="_StartStamp"/>)).
		/// </para>
		/// </summary>
		public abstract void Start();
		/// <summary>
		/// The pause method of the timer.
		/// <para>
		/// Set <see cref="TimerState"/> to <see cref="State.Paused"/>
		/// as well as <see cref="_PauseStamp"/> to <see cref="DateTime.Now"/>
		/// and call <see cref="Timer.Change(int, int)"/> with <see cref="Infinite"/> as parameters.
		/// </para>
		/// </summary>
		public abstract void Pause();
		/// <summary>
		/// The stop method of the timer.
		/// <para>
		/// First, call <see cref="_Timer"/> with <see cref="Infinite"/> as parameters,
		/// then call <see cref="IDisposable.Dispose"/> on the timer.
		/// Finally set <see cref="TimerState"/> to <see cref="State.Stopped"/>.
		/// </para>
		/// </summary>
		public abstract void Stop();
		#endregion
	}
}