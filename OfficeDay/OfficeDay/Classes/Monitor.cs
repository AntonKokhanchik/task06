using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Classes
{
	public class Monitor
	{
		public void WhenCame(Person person, DateTime time)
		{
			Console.WriteLine("{0}:{1}: {2} пришёл на работу", time.Hour, time.Minute, person.Name);
		}

		public void WhenLeave(Person person, DateTime time)
		{
			Console.WriteLine("{0}:{1}: {2} уходит", time.Hour, time.Minute, person.Name);
		}
	}
}
