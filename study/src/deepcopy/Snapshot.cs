using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace study
{
    public class Snapshot
    {
        private List<int> originals;

        private List<int> data;

        public Snapshot(List<int> data)
        {
            this.data = data;
            this.originals = CloneList(this.data);
        }

        public List<int> Restore()
        {
            return this.originals;
        }

        public static List<T> CloneList<T>(List<T> oldList)  
        {  
            BinaryFormatter formatter = new BinaryFormatter();  
            MemoryStream stream = new MemoryStream();  
            formatter.Serialize(stream, oldList);
            stream.Position = 0;  
            return (List<T>)formatter.Deserialize(stream);      
        }

        public static void Main(string[] args)
        {
            List<int> data = new List<int>();
            data.Add(1);
            data.Add(2);
            data.Add(3);
            Snapshot snapshot = new Snapshot(data);

            data = new List<int>();
            data.Add(5);
            data.Add(6);
            data.Add(7);

            data.ForEach((int obj) => {
                Console.WriteLine("Data : {0}", obj);
            });

            List<int> restores = snapshot.Restore();
            restores.ForEach((int obj) => {
                Console.WriteLine("Restore : {0}", obj);    
            });
        }
    }
}
