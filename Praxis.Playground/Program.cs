using System;
using Praxis.Contracts;
using Praxis.Core;
using Praxis.Library;

namespace Praxis.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var bucket = new[]
            {
                new IProblem[]
                {
                    //new Educative(),
                    new LCEasy()
                }
            };

            foreach (var classes in bucket)
            {
                foreach (var item in classes)
                {
                    Helper.InsertBlankSep(2);
                    Console.WriteLine($"// Executing: {item.GetType().Name}");
                    Console.WriteLine("// ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ----");
                    
                    item.Run();
                }

                Console.WriteLine("// ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ----");
            }

            Helper.InsertBlankSep();
            Console.WriteLine("Press [enter] to quit.");
            Console.ReadKey();

        }
    }
}
