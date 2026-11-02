using System;

namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree myTree = new PlainChristmasTree();

            OrnamentsDecorator ornamentsTree = new OrnamentsDecorator();
            GarlandDecorator garlandTree = new GarlandDecorator();

            ornamentsTree.SetComponent(myTree);
            garlandTree.SetComponent(ornamentsTree);

            garlandTree.Operation();

            Console.Read();
        }
    }


    abstract class ChristmasTree
    {
        public abstract void Operation();
    }

 
    class PlainChristmasTree : ChristmasTree
    {
        public override void Operation()
        {
            Console.WriteLine("Plain green Christmas tree.");
        }
    }


    abstract class ChristmasTreeDecorator : ChristmasTree
    {
        protected ChristmasTree component;

        public void SetComponent(ChristmasTree component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

 
    class OrnamentsDecorator : ChristmasTreeDecorator
    {
        private string addedOrnaments;

        public override void Operation()
        {
            base.Operation();
            addedOrnaments = "baubles, snowflakes, and star topper";
            Console.WriteLine($"Added Christmas ornaments ({addedOrnaments}).");
        }
    }

    
    class GarlandDecorator : ChristmasTreeDecorator
    {
        public override void Operation()
        {
            base.Operation();
            LightUp();
            Console.WriteLine("The tree is now decorated with glowing lights.");
        }

        void LightUp()
        {
            Console.WriteLine("Garland lights turned on: tree is glowing!");
        }
    }
}