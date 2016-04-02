using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Classes
{
	enum DayTime
	{
		morning,
		day,
		evening,
		night
	}

	public class Person
	{
		public string Name { get; private set; }

		public Person(string name)
		{
			Name = name;
			if (string.IsNullOrEmpty(name))
				Name = "безымянный";
		}

		public void WhenCame(Person he, DateTime time)
		{

			switch (DayTimer(time))
			{
				case DayTime.morning:
					Console.WriteLine("{0} сказал: Доброе утро, {1}", Name, he.Name); break;
				case DayTime.day:
					Console.WriteLine("{0} сказал: Добрый день, {1}", Name, he.Name); break;
				case DayTime.evening:
					Console.WriteLine("{0} сказал: Добрый вечер, {1}", Name, he.Name); break;
				case DayTime.night:
					Console.WriteLine("{0} сказал: Да здравствует ещё одна сова, {1}!", Name, he.Name); break;
			}
		}

		public void WhenLeave(Person he, DateTime time)
		{
			switch (DayTimer(time))
			{
				case DayTime.morning:
					Console.WriteLine("{0} сказал: Что так рано, {1}?", Name, he.Name); break;
				case DayTime.day:
					Console.WriteLine("{0} сказал: Хорошего дня, {1}", Name, he.Name); break;
				case DayTime.evening:
					Console.WriteLine("{0} сказал: Приятного вечера, {1}", Name, he.Name); break;
				case DayTime.night:
					Console.WriteLine("{0} сказал: Спокойной ночи, {1}", Name, he.Name); break;
			}
		}

		DayTime DayTimer(DateTime time)
		{
			if (time.Hour > 6 && time.Hour <= 10)
				return DayTime.morning;
			else if (time.Hour > 10 && time.Hour <= 16)
				return DayTime.day;
			else if (time.Hour > 16 && time.Hour <= 23)
				return DayTime.evening;
			else
				return DayTime.night;
		}

	}
}
