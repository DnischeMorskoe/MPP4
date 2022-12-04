using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP4
{
    public class PipeItem
    {
        public string path;
        public string code;

        public PipeItem(string path)
        {
            this.path = path;
        }

        public PipeItem(string path, string code)
        {
            this.path = path;
            this.code = code;
        }

    }
}
