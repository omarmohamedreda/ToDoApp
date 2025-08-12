using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoApp
{
	public class ToDoManager
	{
		private string filePath = "tasks.json";
		private List<TaskItem> tasks = new List<TaskItem>();

		public ToDoManager()
		{
			LoadTasks();
		}

		public void AddTask(string description)
		{
			if (string.IsNullOrWhiteSpace(description))
			{
				Console.WriteLine("Please provide a task description.");
				return;
			}
			tasks.Add(new TaskItem { Description = description, IsDone = false });
			SaveTasks();
			Console.WriteLine("Task added.");
		}

		public void ListTasks()
		{
			if (tasks.Count == 0)
			{
				Console.WriteLine("No tasks found.");
				return;
			}

			for (int i = 0; i < tasks.Count; i++)
			{
				var status = tasks[i].IsDone ? "[X]" : "[ ]";
				Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
			}
		}

		public void MarkDone(string indexStr)
		{
			if (int.TryParse(indexStr, out int index) && index > 0 && index <= tasks.Count)
			{
				tasks[index - 1].IsDone = true;
				SaveTasks();
				Console.WriteLine($"Task #{index} marked as done.");
			}
			else
			{
				Console.WriteLine("Invalid task number.");
			}
		}

		public void DeleteTask(string indexStr)
		{
			if (int.TryParse(indexStr, out int index) && index > 0 && index <= tasks.Count)
			{
				tasks.RemoveAt(index - 1);
				SaveTasks();
				Console.WriteLine($"Task #{index} deleted.");
			}
			else
			{
				Console.WriteLine("Invalid task number.");
			}
		}

		private void SaveTasks()
		{
			File.WriteAllText(filePath, JsonSerializer.Serialize(tasks));
		}

		private void LoadTasks()
		{
			if (File.Exists(filePath))
			{
				tasks = JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(filePath));
			}
		}
	}
}

