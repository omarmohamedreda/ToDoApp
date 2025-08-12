using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoApp
{
	public class Program
	{
		static void Main()
		{
			var manager = new ToDoManager();

			while (true)
			{
				Console.Write("Choose your command after then write what you want:" +
					"\nNote: if you choose add function write your task after add keyword directly like this 'add go to ......' " +
					" \n(add / list / done / delete / exit) \n");
				string? input = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(input)) continue;

				var parts = input.Split(' ', 2);
				string command = parts[0].ToLower();
				string argument = parts.Length > 1 ? parts[1] : "";

				switch (command)
				{
					case "add":
						manager.AddTask(argument);
						break;
					case "list":
						manager.ListTasks();
						break;
					case "done":
						manager.MarkDone(argument);
						break;
					case "delete":
						manager.DeleteTask(argument);
						break;
					case "exit":
						return;
					default:
						Console.WriteLine("Unknown command.");
						break;
				}

			}
		}
	}
}
