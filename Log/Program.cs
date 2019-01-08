using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    class Program
    {
        static void Main(string[] args)
        {

            TEMP temp =  new TEMP("João", 18, 'M');
            TEMP temp2 = new TEMP("Maria", 24, 'F');
            TEMP temp3 = new TEMP("Larissa", 18, 'F');
            List<TEMP> temps = new List<TEMP> { temp, temp2, temp3 };


            Log log = new Log(temp2);
            var mylog = log.NewLog();
            mylog.SetLog("Meu log da Maria");
            mylog.PrintLog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MyLog.txt";

            foreach (var item in temps)
            {
                Log log1 = new Log("Meu log personalizado",item);
                ClientLog client = new ClientLog(log1);
                //client.SetLog("Log:");
                client.PrintLog();

                Log log2 = new Log(item);
                var clientlog = log2.NewLog();
                clientlog.PrintLog();
                clientlog.SaveLog(path);
            }
            Console.ReadKey();
        }
    }
}
