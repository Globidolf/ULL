/***************************************
 *	ULL.Timers.State
 * 
 *	Author:		Silvan Pfister
 * 
 *	Version:	1.0
 * 
 *	Project:	ULL
 * 
 ***************************************/

namespace ULL.Timers
{
	/// <summary>
	/// Describes the current state of a timer
	/// </summary>
	public enum State
	{
		/// <summary>
		/// This state is invalid. Something went wrong.
		/// </summary>
		Invalid,
		/// <summary>
		/// The timer is currently running.
		/// </summary>
		Running,
		/// <summary>
		/// The timer has been paused and can continue.
		/// </summary>
		Paused,
		/// <summary>
		/// The timer has been stopped. It cannot continue.
		/// </summary>
		Stopped
	}
}