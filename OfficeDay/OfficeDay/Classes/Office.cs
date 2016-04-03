using OfficeDay.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Classes
{
	class Office : IOffice
	{
		public event IncomingHandler IncomingEvent;
		public event LeavingHandler LeavingEvent;

		public void CheckIncoming(Person person, DateTime time)
		{
			RunIncomingEvent(person, time);
			this.IncomingEvent += person.WhenCame;
			this.LeavingEvent += person.WhenLeave;
		}

		public void CheckLeaving(Person person, DateTime time)
		{
			this.IncomingEvent -= person.WhenCame;
			this.LeavingEvent -= person.WhenLeave;
			RunLeavingEvent(person, time);
		}

		protected void RunIncomingEvent(Person person, DateTime time)
		{
			var e = IncomingEvent;
			if (e != null)
				e(person, time);
		}

		protected void RunLeavingEvent(Person person, DateTime time)
		{
			var e = LeavingEvent;
			if (e != null)
				e(person, time);
		}

		public void WhenSchedulerActs(ActionEventArg arg)
		{
			if (arg.ActionType == ActionType.ComeIn)
				CheckIncoming(arg.Person, arg.Time);
			else if (arg.ActionType == ActionType.Leave)
				CheckLeaving(arg.Person, arg.Time);
		}

	}
}
