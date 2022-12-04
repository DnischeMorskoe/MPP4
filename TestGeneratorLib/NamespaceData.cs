using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeneratorLib
{
    public class NamespaceData
    {
        public string Name { get; }
        public ClassData ClassName { get; }

        public NamespaceData(string name, ClassData className)
        {
            Name = name;
            ClassName = className;
        }

    }
}
