using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HRBase
{
    public class FileHelperJSON<T> where T : new()
    {
        private string _filePath =
            Path.Combine(Environment.CurrentDirectory, "EmployeeDataBase.txt");

        public void SerializeToFile(T employees)
        {
            var json = JsonConvert.SerializeObject(employees);

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, json);
            else
            {
                File.Delete(_filePath);
                File.WriteAllText(_filePath, json);
            }
        }

        public T DeserializeFromFile()
        {
            var employee = JsonConvert.DeserializeObject<T>(File.ReadAllText(_filePath));
            return employee;
        }
    }
}
