using System;

namespace Alarm
{
    public delegate void Running(object sender);

    public class Clock
    {
        public event Running running;
        public int time = 1;

        public Clock() { }
        public void start()
        {
            while(true)
            {
                running(this);
                System.Threading.Thread.Sleep(1000);
                time++;
            }
        }

    }

    public class eventSubscriber
    {
        public Clock clock = new Clock();
        public eventSubscriber()
        {
            this.clock.running += Tick;
            this.clock.running += Alarm;

        }
        public void Tick(object sender)
        {
            Console.WriteLine("click");
        }
        public void Alarm(object sender)
        {
            if (this.clock.time % 5 == 0)
                Console.WriteLine("alarm");
        }

    }

    class program
    {
        static void Main(string[] args)
        {
            eventSubscriber evtsub = new eventSubscriber();
            evtsub.clock.start();
        }
    }
}
