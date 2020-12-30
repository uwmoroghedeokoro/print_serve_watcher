using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using System.Timers;

namespace print_serve_watcher
{
    class Program
    {
        static Timer timer = new Timer(10);
        static void Main(string[] args)
        {
            try
            {
                timer.Elapsed += timer_Elapsed;
                timer.Start();

                Console.Read();


            }
            catch (Exception ex)
            {

            }

        }

        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
               // Console.WriteLine("L");
                PrintServer ps = new PrintServer();
               // PrintServer ps = new PrintServer(System.Printing.PrintSystemDesiredAccess.AdministrateServer);
                // PrintQueueCollection pQueue = ps.GetPrintQueues();
                PrintQueueCollection pQueue = ps.GetPrintQueues();
               // new PrintQueue(ps, printer.printer_name, PrintSystemDesiredAccess.AdministratePrinter)
                int x = 1;
                foreach (PrintQueue pq in pQueue)
                {
                  //  Console.WriteLine(pq.Name);

                    foreach (var job in ps.GetPrintQueue(pq.Name).GetPrintJobInfoCollection())
                    {
                        job.Pause();
                       // Console.WriteLine("Paused - " + job.Name);
                    }
                    //  Console.WriteLine("----");
                }


            }
            catch (Exception ex)
            {

            }


        }
    }
}
