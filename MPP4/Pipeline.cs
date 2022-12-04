using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace MPP4
{
    public class Pipeline
    {
        public static string resultPath;
        public static async Task<PipeItem[]> Read(PipeItem[] items)
        {
            Console.WriteLine("Reading");
            return await Task<PipeItem[]>.Factory.StartNew(() => items.Select(x => new PipeItem(x.path, File.ReadAllText(x.path))).ToArray());
        }

        public static async Task<PipeItem[]> Generate(PipeItem[] items)
        {
            
            Console.WriteLine("Generating");
            return;
        }

        public static void Write(PipeItem[] items)
        {
            Console.WriteLine("Writing");
           
        }

    }
}
