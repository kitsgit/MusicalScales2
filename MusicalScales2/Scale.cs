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
        static int length=12;
        static string[] notes = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

        public string name;
        public string formula;
        public string root;

        public Scale(string n, string f, string r)

        {
            this.name = n;
            this.formula = f;
            this.root = r;
        }
        public Scale(string n, string f)
        {
            this.name = n;
            this.formula = f;
        }
        public void Print()
        {
            int position = Array.IndexOf(notes, this.root);
            int[] seq = new int[30];
            for (int i = 0; i < this.formula.Length; i++)
            {
                seq[i] = Int32.Parse(this.formula[i].ToString());
                Console.Write(notes[position % length] + " ");
                position += seq[i];
            }
            Console.WriteLine();
        }

        public void PrintAll()
        {
            for (int i = 0; i < notes.Length; i++)
            {
                Scale s = new Scale(this.name, this.formula, notes[i]);
                s.Print();
            }
        }
        static public string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
