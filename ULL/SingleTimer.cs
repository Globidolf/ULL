/***************************************
 *	ULL.Timers.SingleTimer
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
	/// This timer will invoke a callback after a defined delay
	/// </summary>
    public class SingleTimer : TimerBase
    {
		#region Fields
		private int _Delay;
		#endregion
		#region Properties
		/// <summary>
		/// The delay in milliseconds after which the callback will be invoked
		/// </summary>
		public int Delay {
			get { return _Delay; }
			set {
				switch (TimerState)
				{
					case State.Running: // If the is running we have to pause it momentarily.
						Pause();
						_Delay = value;
						Start();
						break;
					default: _Delay = value; break;
				}
			}
		}
		#endregion
		#region Methods
		#region Constructor
		/// <summary>
		/// Creates an instance of the <see cref="SingleTimer"/> class
		/// </summary>
		/// <param name="action">The callback for this timer</param>
		/// <param name="delay">The delay in ms after which the callback is invoked</param>
		/// <param name="start">If true, the timer will start immediately</param>
		public SingleTimer(Action action, int delay, bool start = false)
		{
			_Action = action;
			_Delay = delay;
			if (start) Start();
		}
		#endregion
		#region TimerBase Implementation
		/// <summary>
		/// Starts or continues the timer. Is ignored if the Timer is running while called.
		/// </summary>
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
