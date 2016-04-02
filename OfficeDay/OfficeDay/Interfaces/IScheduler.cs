using OfficeDay.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Interfaces
{
	public delegate void SchedulerActionHandler(ActionEventArg arg);
 
	public interface IScheduler
	{
		event SchedulerActionHandler SchedulerActionEvent;

		void Start();
	}
}
