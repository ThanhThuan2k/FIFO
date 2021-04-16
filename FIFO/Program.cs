using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFO
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.OutputEncoding = Encoding.UTF8;
				Console.Write("Nhập số lượng tiến trình: ");
				int numberOfProcess = Convert.ToInt32(Console.ReadLine());

				List<Process> temp = new List<Process>();
				Queue<Process> queue = new Queue<Process>();
				for (int i = 0; i < numberOfProcess; i++)
				{
					Console.Write("Nhập tên tiến trình: ");
					string text = Console.ReadLine();
					Console.Write("Nhập thời gian vào: ");
					int timeIn = Convert.ToInt32(Console.ReadLine());
					Console.Write("Nhập thời gian thực thi: ");
					int processingTime = Convert.ToInt32(Console.ReadLine());
					Console.WriteLine();
					Process newProcess = new Process(text, timeIn, processingTime);
					temp.Add(newProcess);
				}
				// sắp xếp các tiến trình theo thứ tự tăng dần của thời gian vào
				temp = Process.SortTimeIn(temp);

				// đặt thời gian chạy thực tế cho mỗi tiến trình sau khi có đầy đủ thông tin 
				Process.setRealTime(temp);

				// bỏ vào queue theo thứ tự thời gian vào
				queue = Process.ToQueue(temp);
				// bắt đầu đếm
				int totalTime = Process.CountTime(temp);

				Console.WriteLine("Tổng thời gian: " + totalTime);
				Console.WriteLine("Thứ tự các tiến trình theo thời gian: ");
				foreach (var item in queue)
				{
					Console.WriteLine("Tiến trình " + item.Name);
					Console.WriteLine("Thời gian vào thực tế: " + item.RealTime);
					Console.WriteLine("Thời gian hoàn thành thực tế: " + item.EndTime);
					Console.WriteLine();
				}

				Console.Read();
			}
			catch
			{
				Console.WriteLine("Vui lòng nhập số hợp lệ.");
			}
		}
	}
}
