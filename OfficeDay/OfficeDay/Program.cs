using OfficeDay.Classes;
using OfficeDay.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay
{
	class Program
	{
		static void Main(string[] args)
		{
			IScheduler scheduler = new Scheduler();
			IOffice office = new Office();
			Monitor monitor = new Monitor();
			office.IncomingEvent += monitor.WhenCame;
			office.LeavingEvent += monitor.WhenLeave;
			scheduler.SchedulerActionEvent += office.WhenSchedulerActs;
			scheduler.Start();
			Console.ReadKey();
		}
	}
}
