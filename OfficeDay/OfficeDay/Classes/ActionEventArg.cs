using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Classes
{
	public enum ActionType
	{
		ComeIn, 
		Leave
	}

	public class ActionEventArg
	{
		public Person Person { get; private set; }
		public ActionType ActionType { get; private set; }
		public DateTime Time { get; private set; }

		public ActionEventArg(Person person, ActionType actionType, DateTime time)
		{
			ActionType = actionType;
			Person = person;
			Time = time;
		}
	}
}
