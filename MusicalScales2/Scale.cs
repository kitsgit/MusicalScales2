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
            Console.WriteLine("Hello");
        }
        public Scale(string n, string f)
        {
            this.name = n;
            this.formula = f;
            Console.WriteLine("Hello");
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
        static public string scaleConvert(string s)
        {
            int[] ar = new int[20];
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                char c2 = '.';
                if (i < s.Length - 1)
                {
                    c2 = s[i + 1];
                }
                if (c2 == '+')
                {
                    char c3 = s[i + 2];
                    if ((c1 == 'w' && c3 == 'h') || (c1 == 'h' && c3 == 'w'))
                    {
                        ar[j] = 3;
                        j++;
                    }
                    else if (c1 == 'w' && c3 == 'w')
                    {
                        ar[j] = 4;
                        j++;
                    }
                    else if (c1 == 'h' && c3 == 'h')
                    {
                        ar[j] = 2;
                        j++;
                    }
                    i += 2;
                }
                else
                {
                    if (c1 == 'w')
                    {
                        ar[j] = 2;
                        j++;
                    }
                    else if (c1 == 'h')
                    {
                        ar[j] = 1;
                        j++;
                    }
                }

            }
            string ss = String.Join(",", ar.Select(p => p.ToString()).ToArray());
            ss = ss.Replace(",","");
            ss = ss.Replace("0", "");
            return ss;
        }
    }
}
