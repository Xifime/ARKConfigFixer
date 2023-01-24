using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.IO;

namespace ArkConfigFix
{
    class Program
    {
        public static List<Option> options;

        public static bool initialized = false;

        static void Main(string[] args)
        {


            // Create options that you want your menu to have
            options = new List<Option>
            {
                new Option("Fix my INI", () => FixINI()),
                new Option("Clear my INI", () => ClearINI()),
                new Option("Do that color thing again", () => ColorInit()),
                new Option("Exit", () => Environment.Exit(0)),
            };

            Console.CursorVisible = false;
            Console.Title = "ARK Config Fix";
            int index = 0;
            WriteMenu(options, options[index]);
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                }
            }
            while (keyinfo.Key != ConsoleKey.X);
        }

        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        static void Initialize()
        {
            Console.WriteLine("  ______   _______   __    __        ______  __    __  ______        ________  ______  __    __ ");
            Console.WriteLine(" /      \\ /       \\ /  |  /  |      /      |/  \\  /  |/      |      /        |/      |/  |  /  |" + "       By SR#0003");
            Console.WriteLine("/$$$$$$  |$$$$$$$  |$$ | /$$/       $$$$$$/ $$  \\ $$ |$$$$$$/       $$$$$$$$/ $$$$$$/ $$ |  $$ |" + "   Use at your own risk.");
            Console.WriteLine("$$ |__$$ |$$ |__$$ |$$ |/$$/          $$ |  $$$  \\$$ |  $$ |        $$ |__      $$ |  $$  \\/$$/ ");
            Console.WriteLine("$$    $$ |$$    $$< $$  $$<           $$ |  $$$$  $$ |  $$ |        $$    |     $$ |   $$  $$<  ");
            Console.WriteLine("$$$$$$$$ |$$$$$$$  |$$$$$  \\          $$ |  $$ $$ $$ |  $$ |        $$$$$/      $$ |    $$$$  \\ ");
            Console.WriteLine("$$ |  $$ |$$ |  $$ |$$ |$$  \\        _$$ |_ $$ |$$$$ | _$$ |_       $$ |       _$$ |_  $$ /$$  |");
            Console.WriteLine("$$ |  $$ |$$ |  $$ |$$ | $$  |      / $$   |$$ | $$$ |/ $$   |      $$ |      / $$   |$$ |  $$ |");
            Console.WriteLine("$$/   $$/ $$/   $$/ $$/   $$/       $$$$$$/ $$/   $$/ $$$$$$/       $$/       $$$$$$/ $$/   $$/ ");
        }

        static void wly(string y, int pos)
        {
            int wt = 100;
            ConsoleColor c = GetRandomConsoleColor();
            while (c == ConsoleColor.Black)
            {
                c = GetRandomConsoleColor();
            }
            Console.ForegroundColor = c;
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, pos);
            Console.WriteLine(y);
            Console.SetCursorPosition(0, currentLineCursor);
            Thread.Sleep(wt);
        }

        static void ColorInit()
        {
            wly("  ______   _______   __    __        ______  __    __  ______        ________  ______  __    __ ", 0);
            wly(" /      \\ /       \\ /  |  /  |      /      |/  \\  /  |/      |      /        |/      |/  |  /  |" + "       By SR#0003", 1);
            wly("/$$$$$$  |$$$$$$$  |$$ | /$$/       $$$$$$/ $$  \\ $$ |$$$$$$/       $$$$$$$$/ $$$$$$/ $$ |  $$ |" + "   Use at your own risk.", 2);
            wly("$$ |__$$ |$$ |__$$ |$$ |/$$/          $$ |  $$$  \\$$ |  $$ |        $$ |__      $$ |  $$  \\/$$/ ", 3);
            wly("$$    $$ |$$    $$< $$  $$<           $$ |  $$$$  $$ |  $$ |        $$    |     $$ |   $$  $$<  ", 4);
            wly("$$$$$$$$ |$$$$$$$  |$$$$$  \\          $$ |  $$ $$ $$ |  $$ |        $$$$$/      $$ |    $$$$  \\ ", 5);
            wly("$$ |  $$ |$$ |  $$ |$$ |$$  \\        _$$ |_ $$ |$$$$ | _$$ |_       $$ |       _$$ |_  $$ /$$  |", 6);
            wly("$$ |  $$ |$$ |  $$ |$$ | $$  |      / $$   |$$ | $$$ |/ $$   |      $$ |      / $$   |$$ |  $$ |", 7);
            wly("$$/   $$/ $$/   $$/ $$/   $$/       $$$$$$/ $$/   $$/ $$$$$$/       $$/       $$$$$$/ $$/   $$/ ", 8);
            Program.initialized = true;
        }

        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            if (!Program.initialized)
            {
                ColorInit();

                Thread.Sleep(100);

                ColorInit();

                Thread.Sleep(100);

                ColorInit();

                Thread.Sleep(100);
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Initialize();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Write("> ");
                    Console.WriteLine(option.Name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write(" ");
                    Console.WriteLine(option.Name);
                }
            }
        }
        static void FixINI()
        {
            bool rt = false;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string cdrive = drive.ToString().Replace("\\", "/");
                string pat = "Steam/steamapps/common/ARK/Engine/Config";
                string pat2 = "SteamLibrary/steamapps/common/ARK/Engine/Config";
                if (File.Exists(cdrive + pat + "/BaseEngine.ini"))
                {
                    rt = Return(cdrive + pat);
                }
                if (File.Exists(cdrive + pat2 + "/BaseEngine.ini"))
                {
                    rt = Return(cdrive + pat2);
                }
            }
            if (!rt)
            {
                if (File.Exists("C:/Program Files/Steam/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return("C:/Program Files/Steam/steamapps/common/ARK/Engine/Config");
                }
                if (File.Exists("C:/Program Files (x86)/Steam/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return("C:/Program Files (x86)/Steam/steamapps/common/ARK/Engine/Config");
                }
                if (File.Exists("C:/Program Files/SteamLibrary/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return("C:/Program Files/SteamLibrary/steamapps/common/ARK/Engine/Config");
                }
                if (File.Exists("C:/Program Files (x86)/SteamLibrary/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return("C:/Program Files (x86)/SteamLibrary/steamapps/common/ARK/Engine/Config");
                }
            }
            if (!rt)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to fix ini.");
            }
        }

        private static void ClearINI()
        {
            bool rt = false;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                string cdrive = drive.ToString().Replace("\\", "/");
                string pat = "Steam/steamapps/common/ARK/Engine/Config";
                string pat2 = "SteamLibrary/steamapps/common/ARK/Engine/Config";
                if (File.Exists(cdrive + pat + "/BaseEngine.ini"))
                {
                    rt = Return2(cdrive + pat);
                }
                if (File.Exists(cdrive + pat2 + "/BaseEngine.ini"))
                {
                    rt = Return2(cdrive + pat2);
                }
            }
            if (!rt)
            {
                if (File.Exists("C:/Program Files/Steam/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return2("C:/Program Files/Steam/steamapps/common/ARK/Engine/Config");
                }
                if (File.Exists("C:/Program Files (x86)/Steam/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return("C:/Program Files (x86)/Steam/steamapps/common/ARK/Engine/Config");
                }
                if (File.Exists("C:/Program Files/SteamLibrary/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return2("C:/Program Files/SteamLibrary/steamapps/common/ARK/Engine/Config");
                }
                if (File.Exists("C:/Program Files (x86)/SteamLibrary/steamapps/common/ARK/Engine/Config/BaseEngine.ini"))
                {
                    rt = Return2("C:/Program Files (x86)/SteamLibrary/steamapps/common/ARK/Engine/Config");
                }
            }
            if (!rt)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to clear ini.");
            }
        }

        static bool Return(string path)
        {
            if (!File.Exists(path + "/BaseDeviceProfiles.ini") || !File.Exists(path + "/ConsoleVariables.ini")) return false;
            string[] casesr = File.ReadAllLines("Reader.txt");
            File.WriteAllText(path + "/BaseDeviceProfiles.ini", "");
            foreach (string line in casesr)
            {
                File.AppendAllText(path + "/BaseDeviceProfiles.ini", Environment.NewLine + line);
            }
            File.AppendAllText(path + "/BaseDeviceProfiles.ini", Environment.NewLine + "; /// Built in ARK INI FIX ///" + Environment.NewLine + Environment.NewLine + "[Windows DeviceProfile]" + Environment.NewLine);
            string[] case2 = File.ReadAllLines(path + "/ConsoleVariables.ini");
            foreach (string line in case2)
            {
                if (line.StartsWith(";") || line.StartsWith("/") || line.StartsWith("[") || line.Length < 1)
                {

                }
                else
                {
                    File.AppendAllText(path + "/BaseDeviceProfiles.ini", Environment.NewLine + "+CVars=" + line);
                }
            }
            ColorInit();
            ColorInit();
            ColorInit();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your INI was successfully fixed.");
            Thread.Sleep(5000);
            return true;
        }

        static bool Return2(string path)
        {
            if (!File.Exists(path + "/BaseDeviceProfiles.ini")) return false;
            string[] casesr = File.ReadAllLines("Reader.txt");
            File.WriteAllText(path + "/BaseDeviceProfiles.ini", "");
            foreach (string line in casesr)
            {
                File.AppendAllText(path + "/BaseDeviceProfiles.ini", Environment.NewLine + line);
            }
            ColorInit();
            ColorInit();
            ColorInit();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your INI was successfully cleared.");
            Thread.Sleep(5000);
            return true;
        }
    }

    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }

}
