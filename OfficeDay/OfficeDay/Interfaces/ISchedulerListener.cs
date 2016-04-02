using OfficeDay.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Interfaces
{
	public interface ISchedulerListener
	{
		void WhenSchedulerActs(ActionEventArg arg);
	}
}
