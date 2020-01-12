using System;

namespace DelegateChain
{
    delegate void Notify(string message);

    class Notifier {
        //delegator type variable
        public Notify EventOccured;
    }

    class EventListener {
        private string name;
        public EventListener(string name)
        {
            this.name = name;
        }

        //method to callback
        public void SomethingHappend(string message)
        {
            Console.WriteLine($"{name}.SomethingHappend : {message}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            //delegator instance
            Notifier notifier = new Notifier();

            EventListener listener1 = new EventListener("listener1");
            EventListener listener2 = new EventListener("listener2");
            EventListener listener3 = new EventListener("listener3");

            //chaining way1
            //combine method to delegator instance
            notifier.EventOccured += listener1.SomethingHappend;
            notifier.EventOccured += listener2.SomethingHappend;
            notifier.EventOccured += listener3.SomethingHappend;
            //call delegator
            notifier.EventOccured("You've got mail.");

            Console.WriteLine();

            //remove method to delegator instance
            notifier.EventOccured -= listener2.SomethingHappend;
            notifier.EventOccured("Download complete.");

            Console.WriteLine();

            //chaining way2
            notifier.EventOccured = new Notify(listener2.SomethingHappend)
                                   + new Notify(listener3.SomethingHappend);
            notifier.EventOccured("Missile launch detected.");

            Console.WriteLine();

            //chaining way3
            Notify notify1 = new Notify(listener1.SomethingHappend);
            Notify notify2 = new Notify(listener2.SomethingHappend);

            notifier.EventOccured = (Notify)Delegate.Combine(notify1, notify2);
            notifier.EventOccured("Fire!!");

            Console.WriteLine();

            notifier.EventOccured = (Notify)Delegate.Remove(notifier.EventOccured, notify2);
            notifier.EventOccured("RPG!!");
        }
    }
}
