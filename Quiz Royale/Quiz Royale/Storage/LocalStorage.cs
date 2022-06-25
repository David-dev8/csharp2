using System.IO;
using System.Text.Json;

namespace Quiz_Royale.Storage
{
    public class LocalStorage
    {
        private const string FILE_NAME = "Settings.json";

        private static Settings s_settings;

        public static Settings Settings
        {
            get
            {
                if(s_settings == null)
                {
                    Read();
                }
                return s_settings;
            }
        }

        public static void Read()
        {
            if(File.Exists(FILE_NAME))
            {
                using(StreamReader reader = new StreamReader(FILE_NAME))
                {
                    s_settings = JsonSerializer.Deserialize<Settings>(reader.ReadToEnd());
                }
            }
            else
            {
                s_settings = new Settings();
            }
        }

        public static void Save()
        {
            using(StreamWriter sw = new StreamWriter(FILE_NAME))
            {
                sw.Write(JsonSerializer.Serialize<Settings>(s_settings));
            }
        }
    }
}
