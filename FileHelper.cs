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

    public static class FileHelper
    {
        private static string _filePath =
    Path.Combine(Environment.CurrentDirectory, "EmployeesDataBase.txt");

        public static void SerializeToFile(List<Employee> employees)
        {
            var serializer = new XmlSerializer(typeof(List<Employee>));

            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, employees);
                streamWriter.Close();
            }
        }

        public static List<Employee> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Employee>();

            var serializer = new XmlSerializer(typeof(List<Employee>));

            using (var streamReader = new StreamReader(_filePath))
            {
                var employees = (List<Employee>)serializer.Deserialize(streamReader);
                streamReader.Close();
                return employees;
            }
        }

        public static void SerializeToFileJson(List<Employee> employees)
        {
            var json = JsonConvert.SerializeObject(employees);
            File.WriteAllText(_filePath, json);
        }

        public static List<Employee> DeserializeFromFileJson()
        {
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Employee>>(json);
        }
    }
}

