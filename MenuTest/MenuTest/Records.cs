using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SeaWars
{
    class RecordsWriter
    {

        public static string nickname = "Player"; // Ник игрока для записи - меняем его в главном меню

        public static string numsFileName; // Имя файла для открытия
        public static string namesFileName; // В одном файле хрянтся имена игроков, в другом - рекорды 
        public const int maxRecordsAmount = 5; // Максимальное количество рекордов


        static List<string> names = new List<string>(); // Список имён
        public static List<int> records = new List<int>(); // Список рекордов
        public static void OpenNewFile(string fileName)
        {
            names.Clear();
            records.Clear();
            numsFileName = fileName + "Nums";
            namesFileName = fileName + "Names";
            if (!File.Exists(numsFileName = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName + "\\" + numsFileName + ".dat"))
                File.Create(numsFileName).Close();

            if (!File.Exists(namesFileName = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName + "\\" + namesFileName + ".dat"))
                File.Create(namesFileName).Close();


            foreach (string record in File.ReadAllLines(numsFileName))
            {
                string[] lines = record.Split(';');
                records.Add(Int32.Parse(lines[0]));
            }

            foreach (string record in File.ReadAllLines(namesFileName))
            {
                string[] lines = record.Split(';');
                names.Add(lines[0]);
            }

            if (names.Count == 0)
            {
                for (int i = 0; i < maxRecordsAmount; i++)
                {
                    names.Add(" ");
                    records.Add(999999999);
                }
            }
        }

        public static void SetNewRecord(int score)
        {
            for (int i = 0; i < maxRecordsAmount; i++)
            {
                if (score <= records[i])
                {
                    for (int j = maxRecordsAmount - 1; j > i; j--)
                    {
                        names[j] = names[j - 1];
                        records[j] = records[j - 1];
                    }
                    names[i] = nickname;
                    records[i] = score;
                    break;
                }
            }

            List<string> linesNames = new List<string>();
            List<string> linesRecords = new List<string>();

            for (int i = 0; i < maxRecordsAmount; i++)
            {
                linesNames.Add(names[i]);
                linesRecords.Add(records[i].ToString());
            }

            File.WriteAllLines(numsFileName, linesRecords);

            File.WriteAllLines(namesFileName, linesNames);

        }
        public static void Clear()
        {
            File.WriteAllLines(numsFileName, new List<string>());
            File.WriteAllLines(namesFileName, new List<string>());
        }

        public static string GetRecordString(int index)
        {
            if (names.Count > index)
                return "" + records[index];
            else
                return "Err";
        }

        public static string GetNameRecordString(int index)
        {
            if (names.Count > index)
                return names[index];
            else
                return "Err";
        }

    }
}

