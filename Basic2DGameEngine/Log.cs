using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGameEngine
{
    public class Log
    {
        public static void Normal(string msg) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[Normal] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info(string msg) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[Info] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(string msg) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Waring] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Error(string msg) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
