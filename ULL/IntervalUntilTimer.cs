using System;
using System.Collections.Generic;
using System.Text;

namespace ULL.Timers
{
	public class IntervalUntilTimer : TimerBase
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

		private DateTime _End;
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

		public IntervalUntilTimer(Action action, int interval, DateTime end)
		{
			_Action = action;
			_Interval = interval;

		}

		public override void Pause()
		{

		}

		public override void Start()
		{
			throw new NotImplementedException();
		}

		public override void Stop()
		{
			throw new NotImplementedException();
		}
	}
}
