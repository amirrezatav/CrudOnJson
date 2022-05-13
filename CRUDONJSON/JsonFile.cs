using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDONJSON
{
    public class JsonFile
    {
        private readonly string path; // Directory of storage
        // path is Directory not file !!
        public JsonFile(string root) // root is Directory 
        {
            path = root;
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public void Create<T> (T obj)
        {
            List<T> NewItems = new List<T>();
            NewItems.Add(obj);

            Type type = typeof (T); // get class information
            string className = type.Name; // get class name
            string filename = className + ".json";
            // path -> c:/Directory1/Directory2/Directory3
            // filename -> babaei.json
            // filepath -> c:/Directory1/Directory2/Directory3/filename
            //             c:/Directory1/Directory2/Directory3/babaei.json
            string filepath = Path.Combine(path, filename);
            
            if(!File.Exists(filepath))
            { // file is not exist
                // Convert Object To json
                string ObjectInJson = JsonConvert.SerializeObject(NewItems , Formatting.Indented);
                File.WriteAllText(filepath, ObjectInJson);
            }
            else
            { // File is exist

                string ObjectsJson = File.ReadAllText(filepath);

                List<T> ExistItem = JsonConvert.DeserializeObject<List<T>>(ObjectsJson);

                if(ExistItem != null)
                    NewItems.AddRange(ExistItem);

                string ObjectInJson = JsonConvert.SerializeObject(NewItems, Formatting.Indented);

                File.WriteAllText(filepath, ObjectInJson);
            }
        }
        public List<T> Read<T>()
        {
            Type type = typeof(T);
            string className = type.Name;
            string filename = className + ".json";
            string filepath = Path.Combine(path, filename);

            if (File.Exists(filepath))
            {
                string ObjectsJson = File.ReadAllText(filepath);

                List<T> ExistItem = JsonConvert.DeserializeObject<List<T>>(ObjectsJson);

                return ExistItem;
            }
            else
            {
                return null;
            }
        }
        public void Update<T>(T obj , Predicate<T> pre)
        {
            Type type = typeof(T);
            string className = type.Name;
            string filename = className + ".json";
            string filepath = Path.Combine(path, filename);

            if (File.Exists(filepath))
            {
                string ObjectsJson = File.ReadAllText(filepath);

                List<T> ExistItem = JsonConvert.DeserializeObject<List<T>>(ObjectsJson);

                ExistItem.RemoveAll(pre);

                ExistItem.Add(obj);

                string ObjectInJson = JsonConvert.SerializeObject(ExistItem, Formatting.Indented);

                File.WriteAllText(filepath, ObjectInJson);
            }
        }
        public void Delete<T>(Predicate<T> pre)
        {
            Type type = typeof(T); 
            string className = type.Name; 
            string filename = className + ".json";
            string filepath = Path.Combine(path, filename);

            if (File.Exists(filepath))
            {
                string ObjectsJson = File.ReadAllText(filepath);

                List<T> ExistItem = JsonConvert.DeserializeObject<List<T>>(ObjectsJson);

                ExistItem.RemoveAll(pre);

                string ObjectInJson = JsonConvert.SerializeObject(ExistItem, Formatting.Indented);

                File.WriteAllText(filepath, ObjectInJson);
            }
        }
    }
}
