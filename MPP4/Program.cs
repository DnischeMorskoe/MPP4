using System;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MPP4
{

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Учеба\3_курс\СПП\MPP4\MPP4\Files";
            string resultPath = @"D:\Учеба\3_курс\СПП\MPP4\ResultTests\";

            List<string> pathes = new List<string>(Directory.GetFiles(path));
            Pipeline pipeline = new Pipeline();
            List<IEnumerable<PipeItem>> items = new List<IEnumerable<PipeItem>>();


            for (int i = 0; i < pathes.Count; i += 2)
            {
                items.Add(pathes.GetRange(i, Math.Min(2, pathes.Count - i)).Select(x => new PipeItem(x)));
            }

            foreach (IEnumerable<PipeItem> item in items)
            {
                var read = new TransformBlock<PipeItem[], PipeItem[]>(Pipeline.Read);
                var generate = new TransformBlock<PipeItem[], PipeItem[]>(Pipeline.Generate);
                var write = new ActionBlock<PipeItem[]>(Pipeline.Write);

                read.Post(item.ToArray());
                read.Complete();

            }


        }
    }



}