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





            //Console.WriteLine("Enter the scale : ");
            //string scale = Console.ReadLine();

            Hashtable scalehash = new Hashtable();
            scalehash.Add("mijor", "212221");

            //Scale s = new Scale();
            //s.name = "major";
            //s.formula = "2212221";

            //var binformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //using (var fs = File.AppendText("C:\\Users\\admin.INL082\\source\\repos\\MusicalScales2\\Scales\\vector.txt"))
            //{
            //    binformatter.Serialize(fs, scalehash);
            //}
            string path = "C:\\Users\\admin.INL082\\source\\repos\\MusicalScales2\\Scales\\vector.txt";
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, scalehash);
            fs.Close();


            //// read the data from the file
            //Hashtable vectorDeserialized = null;
            //using (var fs = File.Open("C:\\Users\\admin.INL082\\source\\repos\\MusicalScales2\\Scales\\vector.txt", FileMode.Open))
            //{
            //    vectorDeserialized = (Hashtable)binformatter.Deserialize(fs);
            //}

            //// show the result
            //foreach (DictionaryEntry entry in vectorDeserialized)
            //{
            //    Console.WriteLine("{0}={1}", entry.Key, entry.Value);
            //}


            Hashtable temphash = null;

            // Open the file containing the data that you want to deserialize.
            FileStream ffs = new FileStream(path, FileMode.Open);
           // try
            
                BinaryFormatter fformatter = new BinaryFormatter();

            // Deserialize the hashtable from the file and 
            // assign the reference to the local variable.
            temphash = (Hashtable)formatter.Deserialize(ffs);
            
            //catch (SerializationException e)
            //{
            //    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            //    throw;
            //}
            //finally
            {
                fs.Close();
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs.
            //foreach (DictionaryEntry de in addresses)
            //{
            //    Console.WriteLine("{0} scale is {1}.", de.Key, de.Value);
            //}

            foreach (string key in temphash.Keys)
            {
                Console.WriteLine(String.Format("{0}: {1}", key, temphash[key]));
            }

            Console.Read();
        }
    }
}
