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
            string scale_name="", scale_formula="",root,choice;
            Console.WriteLine("The available scales are : \n");
            string path = "C:\\Users\\admin.INL082\\source\\repos\\MusicalScales2\\Scales\\vector.txt";
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Hashtable scalehash = null;

            scalehash = (Hashtable)formatter.Deserialize(fs);
            fs.Close();
            foreach (string key in scalehash.Keys)
            {
                Console.WriteLine(String.Format("{0}: {1}", key, scalehash[key]));
            }
            Console.WriteLine();
            int q = 1;
            while (q ==1)
            {

                Console.WriteLine("Enter the scale/search : ");
                string input_scale = Console.ReadLine();
                if (scalehash.ContainsKey(input_scale))
                {
                    int q2 = 1;
                    while (q2 == 1)
                    {
                        Console.WriteLine("Enter the root : ");
                        root = Console.ReadLine();

                      //  Console.WriteLine(scalehash[input_scale]);
                        Scale s = new Scale(input_scale, scalehash[input_scale].ToString(),root);
                        s.Print();
                        Console.WriteLine("Change scale? y/n");
                        choice = Console.ReadLine();
                        if(choice=="y")
                        {
                            q2 = 0;
                        }
                        else if(choice == "n")
                        {
                            q = 1;
                        }
                    }
                  //  q = 0;
                    
                }
                else //if (!scalehash.ContainsKey(input_scale))
                {
                    Console.WriteLine("Key does not exist. Do you want to add? y/n");
                    choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        int q3 = 1;
                        while (q3 == 1)
                        {
                            fs = new FileStream(path, FileMode.Open);
                            Console.WriteLine("Enter the name : ");
                            scale_name = Console.ReadLine();
                            Console.WriteLine("Enter the formula : ");
                            scale_formula = Console.ReadLine();
                            scalehash.Add(scale_name, scale_formula);
                            formatter.Serialize(fs, scalehash);
                            fs.Close();
                            Console.WriteLine("Continue entering scales? y/n");
                        
                            choice = Console.ReadLine();
                            if (choice == "y")
                            {
                                //q = 0;
                                q3 = 1;
                            }
                            else if (choice == "n")
                            {
                              //  q = 1;
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
            // scalehash.Add("maihjirrs", "212221");

            //Scale s = new Scale();
            //s.name = "major";
            //s.formula = "2212221";

            fs.Close();
            //  fs = new FileStream(path, FileMode.Open);
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
