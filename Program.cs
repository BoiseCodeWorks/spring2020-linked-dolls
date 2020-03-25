using System;
using linked.Models;

namespace linked
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Step 1. Make all the data
            Doll chewy = new Doll("Chewbacca");
            Doll han = new Doll("Han Solo");
            Doll obi = new Doll("Obi-Wan Kenobi");
            Doll luke = new Doll("Luke Skywalker");
            Doll leia = new Doll("Leia Organa");
            Doll c3po = new Doll("C-3PO");
            Doll r2d2 = new Doll("R2-D2");

            // Step 2. Establish Relationships
            chewy.OuterDoll = r2d2;
            chewy.InnerDoll = han;
            han.OuterDoll = chewy;
            han.InnerDoll = obi;
            obi.OuterDoll = han;
            obi.InnerDoll = luke;
            luke.OuterDoll = obi;
            luke.InnerDoll = leia;
            leia.OuterDoll = luke;
            leia.InnerDoll = c3po;
            c3po.OuterDoll = leia;
            c3po.InnerDoll = r2d2;
            r2d2.OuterDoll = c3po;
            r2d2.InnerDoll = chewy;

            Doll activeDoll = chewy;
            while (true)
            {
                Console.WriteLine($"Current Doll {activeDoll.Name}");
                Console.WriteLine($"(I)n, (O)ut or (R)emove?");
                char input = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (input)
                {
                    case 'i':
                        if (activeDoll.InnerDoll == null)
                        {
                            System.Console.WriteLine("No inner doll");
                            break;
                        }
                        activeDoll = activeDoll.InnerDoll;
                        break;
                    case 'o':
                        if (activeDoll.OuterDoll == null)
                        {
                            System.Console.WriteLine("No outer doll");
                            break;
                        }
                        activeDoll = activeDoll.OuterDoll;
                        break;
                    case 'r':
                        if (activeDoll.InnerDoll != null)
                        {
                            activeDoll.InnerDoll.OuterDoll = activeDoll.OuterDoll;
                            System.Console.WriteLine($"{activeDoll.InnerDoll.Name} now has an outer doll of {activeDoll.InnerDoll.OuterDoll.Name}");
                        }
                        if (activeDoll.OuterDoll != null)
                        {
                            activeDoll.OuterDoll.InnerDoll = activeDoll.InnerDoll;
                            System.Console.WriteLine($"{activeDoll.OuterDoll.Name} now has an inner doll of {activeDoll.OuterDoll.InnerDoll.Name}");
                        }
                        if (activeDoll.OuterDoll != null)
                        {
                            activeDoll = activeDoll.OuterDoll;
                        }
                        else
                        {
                            activeDoll = activeDoll.InnerDoll;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }

        }
    }
}
