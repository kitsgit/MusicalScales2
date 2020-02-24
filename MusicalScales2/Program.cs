using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MusicalScales2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path=(Directory.GetCurrentDirectory());
            path=path.Replace("\\MusicalScales2\\bin\\Debug","");
            path = path + "\\Scales\\vector.txt";
            string[] notes = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
            string scale_name ="", scale_formula="",root,choice;
            Console.WriteLine("The available scales are : \n");
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Hashtable scalehash = null;
            scalehash = (Hashtable)formatter.Deserialize(fs);
            fs.Close();
            foreach (string key in scalehash.Keys)
            {
                Console.WriteLine(String.Format("{0} : {1}", key, scalehash[key]));
            }
            Console.WriteLine();
            int q = 1;
            while (q ==1)
            {
                string input_scale = Scale.Ask("Enter the scale / search : ");
                if (scalehash.ContainsKey(input_scale))
                {
                    int q2 = 1;
                    while (q2 == 1)
                    {
                        root = Scale.Ask("Enter the root : ");
                        if (root == "all")
                        {
                            Scale s = new Scale(input_scale, scalehash[input_scale].ToString());
                            s.PrintAll();
                        }
                        else if(notes.Contains(root))
                        {
                            Scale s = new Scale(input_scale, scalehash[input_scale].ToString(), root);
                            s.Print();
                        }
                        else if(root=="exit")
                        {
                            q = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not Valid");
                        }
                        choice = Scale.Ask("Change scale? y/n");
                        if (choice=="y")
                        {
                            q2 = 0;
                        }
                        else if(choice == "n")
                        {
                            q = 1;
                        }
                    }
                }
                else if(input_scale=="exit")
                {
                    q = 0;
                    break;
                }
                else 
                {
                    choice = Scale.Ask("Key does not exist. Do you want to add? y/n");
                    if (choice == "y")
                    {
                        int q3 = 1;
                        while (q3 == 1)
                        {
                            fs = new FileStream(path, FileMode.Open);
                            scale_name = Scale.Ask("Enter the name : ");
                            scale_formula = Scale.Ask("Enter the formula : ");
                            scalehash.Add(scale_name, scale_formula);
                            formatter.Serialize(fs, scalehash);
                            fs.Close();
                            choice = Scale.Ask("Continue entering scales? y/n");
                            if (choice == "y")
                            {
                                q3 = 1;
                            }
                            else if (choice == "n")
                            {
                                q3 = 0;
                            }
                            
                        }
                    }
                    else if(choice=="n")
                    {
                        q = 1;
                    }
                    fs.Close();
                }
            }
            fs.Close();
            System.IO.File.WriteAllText(path, "");
            fs = new FileStream(path, FileMode.Open);
            formatter.Serialize(fs, scalehash);
            foreach (string key in scalehash.Keys)
            {
                Console.WriteLine(String.Format("{0}: {1}", key, scalehash[key]));
            }
            fs.Close();
            Console.Read();
        }
    }
}
