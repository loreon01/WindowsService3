using System;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService_Lorenzo_Manzo
{
    public class IncrementService : ServiceBase
    {
        private Timer timer;
        private int counter;
        private DateTime executionDateTime;
        private TimeSpan interval;

        public IncrementService()
        {
            this.ServiceName = "IncrementService";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            LoadConfiguration();

            counter = 0;
            string path = @"E\increment.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            timer = new Timer();
            timer.Interval = interval.TotalMilliseconds;
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private void LoadConfiguration()
        {
            executionDateTime = new DateTime(2023, 8, 30, 12, 0, 0);
            interval = TimeSpan.FromHours(24);
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now >= executionDateTime)
            {
                counter++;
                string path = @"E\Increment.txt";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(counter);
                }

                executionDateTime = executionDateTime.Add(interval);
            }
        }
    }
}
