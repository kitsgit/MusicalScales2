using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalScales2
{
    [Serializable]
    public class Scale
    {
        public string name;
        public string formula;
       // public int length;
       // public string notes;
       // public string root;

        public Scale(string n, string f)

        {
            this.name = n;
            this.formula = f;
        }

        public void Print()
        {

        }
    }
}
