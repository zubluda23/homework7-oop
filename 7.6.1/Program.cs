using System;

namespace FactoryMethodCustom
{
  
    public abstract class LogisticsCreator
    {
        public abstract Transport FactoryMethod(int type);
    }

    public class ConcreteLogisticsCreator : LogisticsCreator
    {
        public override Transport FactoryMethod(int type)
        {
            switch (type)
            {
                case 1:
                    return new Truck();

                case 2:
                    return new Airplane();

                case 3:
                    return new Train();

                default:
                    throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

  
    public abstract class Transport
    {
        public abstract void Deliver();
    }

   
    public class Truck : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Truck: delivery by road in container.");
        }
    }

    public class Airplane : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Airplane: express delivery by air.");
        }
    }

    public class Train : Transport
    {
        public override void Deliver()
        {
            Console.WriteLine("Train: large cargo delivery by rail.");
        }
    }

    class MainApp
    {
        static void Main()
        {
            LogisticsCreator creator = new ConcreteLogisticsCreator();

            for (int i = 1; i <= 3; i++)
            {
                var transport = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created {1}", i, transport.GetType());
                transport.Deliver();
            }

            Console.ReadKey();
        }
    }
}