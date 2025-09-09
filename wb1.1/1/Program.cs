using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    internal class Program
    {
        static bool IsWeekend(uint day, uint dayOfTheWeek)
        {
            dayOfTheWeek = dayOfTheWeek % 7; // Must be between 0 and 7
            int offset = (int)(-dayOfTheWeek); // Offset puts weekend closer, so it's negative

            bool isWeekday = false;
            if ((day == 7 + offset || day == 8 + offset) ||
                (day == 14 + offset || day == 15 + offset) ||
                (day == 21 + offset || day == 22 + offset) ||
                (day == 28 + offset || day == 29 + offset))
            {
                isWeekday = true;
            }
            bool isHoliday = day <= 5 && day >= 1 || day >= 8 && day <= 10;
            
            return isHoliday || isWeekday;
        }
        static void Main()
        {
            do
            {
                Console.Write("Введите номер дня недели, с которого начинается месяц (1-пн,...7-вс): ");
                uint dayOfTheWeek = Convert.ToUInt32(Console.ReadLine());
                
                Console.Write("Введите день месяца: ");
                uint day = Convert.ToUInt32(Console.ReadLine());

                if (day == 0 || dayOfTheWeek == 0)
                {
                    break;
                }
                else {
                    Console.WriteLine("-----Проверяем выходной ли день-----");
                    if (IsWeekend(day,dayOfTheWeek))
                    {
                        Console.WriteLine("Выходной день");
                    }
                    else
                    {
                        Console.WriteLine("Рабочий день");
                    }
                }
            } while(true);
        }
    }
}
