using OfficeDay.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Interfaces
{
	public delegate void IncomingHandler(Person person, DateTime time);
	public delegate void LeavingHandler(Person person, DateTime time);

	public interface IOffice : ISchedulerListener
	{
		event IncomingHandler IncomingEvent;
		event LeavingHandler LeavingEvent;

		void CheckIncoming(Person person, DateTime time);
		void CheckLeaving(Person person, DateTime time);

		void WhenSchedulerActs(ActionEventArg arg);
	}
}
