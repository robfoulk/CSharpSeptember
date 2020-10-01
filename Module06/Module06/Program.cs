using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;


namespace Module06
{

    [Serializable]
    class ProgramSettings
    {
        public string Title { get; set; }
        public DateTime LastRan { get; set; }
        public string DbConfig { get; set; }
        public string LastScreen { get; set; }
        public string LastCustomerViewed { get; set; }
        public bool DarkMode { get; set; }


    }

    class TestSetting
    {
        public string BoardName { get; set; } = "Sample Board";
        public bool Debug { get; set; } = false;
        public string Configuration { get; set; } = "Release";
    }


    class Program
    {

        const string BaseFolder = @"c:\class\";



        static void Main(string[] args)
        {

            InsureBaseFolder();


            var ts = new TestSetting(); //has default values
            ts.BoardName = "Some other board";


            //Simple string
            var payload = JsonConvert.SerializeObject(ts);
            var newSettings = JsonConvert.DeserializeObject<TestSetting>(payload);


            var settingsPath = Path.Combine(BaseFolder, "test.settings.txt");
            using(var fs = new FileStream(settingsPath, FileMode.Create))
            using(var writer = new StreamWriter(fs))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, ts);
                Console.WriteLine("test setting written");
            }
            System.Diagnostics.Process.Start(settingsPath);


            var pc = new ProgramSettings();
            pc.Title = "Sample Program";
            pc.LastRan = DateTime.Today.AddDays(-2);
            pc.DbConfig = "SQLServer: Abc123";




            var configPath = Path.Combine(BaseFolder, "app.configuration.txt");
            using(var fs = new FileStream(configPath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, pc);

            }

            Console.WriteLine("Config written");
            System.Diagnostics.Process.Start(configPath);
        }


        private static void Demo1()
        {
            string[] messages = new string[] {
                "Four score and seven years ago",
                "The quick brown fox",
                "I need a data generator"
            };


            //string fullPath = BaseFolder;

            //if (!BaseFolder.EndsWith("\\"))
            //{
            //    fullPath += "\\";
            //}

            //fullPath += "messages.txt";
            //Simple Write
            //var fullPath = Path.Combine(BaseFolder, "messages.txt");

            //File.WriteAllLines(fullPath, messages);
            //Console.WriteLine("Data Written");




            //FYI
            //File.Move("source", "dest");
            //Same
            //FileInfo fi = new FileInfo("source");
            //fi.MoveTo("dest");

            var fullPath = Path.Combine(BaseFolder, "messages.txt");

            using (var outputFileStream = new FileStream(fullPath, FileMode.Create))
            using (var writer = new StreamWriter(outputFileStream))
            {


                int lineNumber = 1;
                foreach (var line in messages)
                {
                    writer.WriteLine($"{lineNumber++}\t{line}");
                }


            }

            Console.WriteLine("File Written");

            //System.Diagnostics.Process.Start(fullPath);


            //Read the contents of a file
            using (var inputFileStream = new FileStream(fullPath, FileMode.Open))
            using (var reader = new StreamReader(inputFileStream))
            {
                List<string> lines = new List<string>();
                while (!reader.EndOfStream)
                {
                    var wholeLine = reader.ReadLine();
                    var segments = wholeLine.Split('\t');
                    if (segments.Length > 1)
                    {
                        lines.Add(segments[1]);
                    }
                }


                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }



        }


        private static void InsureBaseFolder()
        {
            if (Directory.Exists(BaseFolder))
            {
                Console.WriteLine("Everything looks good");
            }
            else
            {
                Directory.CreateDirectory(BaseFolder);
                Console.WriteLine($"Created Base Folder: {BaseFolder}");
            }
        }

        private static void InsureBaseFolder2()
        {
            DirectoryInfo di = new DirectoryInfo(BaseFolder);
            if (di.Exists)
            {
                Console.WriteLine("Everything looks good");
            }
            else
            {
                di.Create();
                Console.WriteLine($"Created Base Folder: {BaseFolder}");
            }
        }

    }
}
