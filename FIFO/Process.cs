using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
	public class Process
	{
		public int TimeIn { get; set; }
		public int ProcessionTime { get; set; }
		public string Name { get; set; }

		public int RealTime { get; set; }
		public int EndTime { get; set; }

		public Process(string name, int timeIn, int process)
		{
			this.Name = name;
			this.TimeIn = timeIn;
			this.ProcessionTime = process;
			this.RealTime = 0;
			this.EndTime = 0;
		}

		public static void swap(List<Process> list, int i, int j)
		{
			Process temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}

		public static List<Process> SortTimeIn(List<Process> list)
		{
			for(int i = 0; i < list.Count() - 1; i++)
			{
				for(int j = i + 1; j < list.Count(); j++)
				{
					if(list[i].TimeIn > list[j].TimeIn)
					{
						swap(list, i, j);
					}
				}
			}
			return list;
		}

		public static Queue<Process> ToQueue(List<Process> list)
		{
			Queue<Process> queue = new Queue<Process>();
			foreach(Process item in list)
			{
				queue.Enqueue(item);
			}
			return queue;
		}

		public static int CountTime(List<Process> list)
		{
			int count = 0;
			foreach(Process item in list)
			{
				count += item.ProcessionTime;
			}
			return count;
		}

		public static void setRealTime(List<Process> list)
		{
			// thằng đầu tiên có thời gian đợi là thời gian nó vô
			var waitTime = list[0].TimeIn;
			
			for(int i = 0; i < list.Count(); i++)
			{
				list[i].RealTime = waitTime;
				list[i].EndTime = waitTime + list[i].ProcessionTime;
				waitTime += list[i].ProcessionTime;
			}
		}
	}
}
