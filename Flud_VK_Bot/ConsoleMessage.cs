using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flud_VK_Bot
{
    class ConsoleMessage
    {
        private string Message="";

        internal string Go()
        {
            Console.WriteLine("\n Введите свое сообщение и нажмите Enter\n");
            Message = Console.ReadLine();
            return Message;
        }
    }
}
