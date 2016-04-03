using OfficeDay.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDay.Classes
{




	class Scheduler : IScheduler
	{
		public event SchedulerActionHandler SchedulerActionEvent;

		public void Start()
		{
			List<Person> personList = new List<Person>();
			while (true)
			{
				PrintMenu();
				ConsoleKey ch = Console.ReadKey(true).Key;
				Switcher1(ch, personList);
				Console.ReadKey(true);
			}
		}

		public void RunSchedulerActionEvent(Person person, ActionType action, DateTime time)
		{
			var e = SchedulerActionEvent;
			if (e != null)
				e(new ActionEventArg(person, action, time));
		}

		void PrintMenu()
		{
			Console.Clear();
			Console.WriteLine("Это эмуляция офиса, задайте событие: ");
			Console.WriteLine("1. Приход работника");
			Console.WriteLine("2. Уход работника (видимо, домой)");
			Console.WriteLine("3. Приход начальника");
		}

		void Switcher1(ConsoleKey ch, List<Person> personList)
		{
			switch (ch)
			{
				case ConsoleKey.D1:
				case ConsoleKey.NumPad1:
					PersonComing(personList); break;
				case ConsoleKey.D2:
				case ConsoleKey.NumPad2:
					PersonLeaving(personList); break;
				case ConsoleKey.D3:
				case ConsoleKey.NumPad3:
					BossComing(personList); break;
			}
		}

		void PersonComing(List<Person> personList)
		{
			Console.WriteLine("Как зовут этого работника?");
			

			string comingPersonName = Console.ReadLine();

			foreach (Person person in personList)
				if (person.Name == comingPersonName)
				{
					Console.WriteLine("Такой работник уже пришёл");
					return;
				}

			Person comingPerson = new Person(comingPersonName);
			personList.Add(comingPerson);
			RunSchedulerActionEvent(comingPerson, ActionType.ComeIn, DateTime.Now);
		}

		void PersonLeaving(List<Person> personList)
		{
			if (personList.Capacity == 0)
			{
				Console.WriteLine("Офис пуст, никто не работает");
				return;
			}
			Console.WriteLine("Как зовут этого работника?");

			string comingPersonName = Console.ReadLine();
			
			foreach (Person person in personList)
				if (person.Name == comingPersonName)
				{
					RunSchedulerActionEvent(person, ActionType.Leave, DateTime.Now);
					personList.Remove(person);
					return;
				}
			Console.WriteLine("Такой работник не приходил");
		}

		void BossComing(List<Person> personList)
		{

			if (personList.Capacity == 0)
			{
				Console.WriteLine("Офис пуст, никто не работает");
				return;
			}
			
				foreach (Person person in personList)
					Console.WriteLine("{0} сказал: Я здесь", person.Name);
		}
	}
}
