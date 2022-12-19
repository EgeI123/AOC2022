using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AOC2022
{
    internal class Program
    {
        static int D1(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string theText = File.ReadAllText(filename);
                string[] lines = theText.Split(new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            ); //splits whole file into a list seperated by the newlines
                int total = 0;
                int elf = 0;
                List<int> elves = new List<int>();
                foreach (string line in lines)
                {
                    if (line == "\n" || line == "")
                    {
                        elves.Add(elf);
                        elf = 0;
                    }
                    else
                    {
                        if (line != "")
                        {
                            int x = Convert.ToInt32(line);
                            elf = elf + x;
                        }
                        if (elf > total)
                        {
                            total = elf;
                        }
                    }
                }
                elves.Sort();
                return total;
            }
        }

        static int D2(string filename)
        {

            string theText = File.ReadAllText(filename);
            string[] lines = theText.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
        ); //splits whole file into a list seperated by the newlines
            int total = 0;
            foreach (string s in lines)
            {
                if (s.Contains("X"))
                {

                    if (s.Contains("A"))
                    {
                        total = total + 3;
                    }
                    if (s.Contains("B"))
                    {
                        total = total + 1;
                    }
                    if (s.Contains("C"))
                    {
                        total = total + 2;
                    }
                }
                if (s.Contains("Y"))
                {
                    total = total + 3;
                    if (s.Contains("B"))
                    {
                        total = total + 2;
                    }
                    if (s.Contains("A"))
                    {
                        total = total + 1;
                    }
                    if (s.StartsWith("C"))
                    {
                        total = total + 3;
                    }
                }
                if (s.Contains("Z"))
                {
                    total = total + 6;
                    if (s.Contains("A"))
                    {
                        total = total + 2;
                    }
                    if (s.Contains("C"))
                    {
                        total = total + 1;
                    }
                    if (s.Contains("B"))
                    {
                        total = total + 3;
                    }
                }
            }
            return total;
        }

        static int D4(string filename)
        {
            string theText = File.ReadAllText(filename);

            string[] lines = theText.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
        ); //splits whole file into a list seperated by the newlines
            int total = 0;
            foreach (string line in lines)
            {
                string[] snums = line.Split(new string[] { "\r\n", "\r", "\n", " ", "-", "," }, StringSplitOptions.None);
                int start1 = Convert.ToInt32(snums[0]);
                int end1 = Convert.ToInt32(snums[1]);
                int start2 = Convert.ToInt32(snums[2]);
                int end2 = Convert.ToInt32(snums[3]);
                if (start1 <= start2 && end1 >= end2)
                {
                    total++;
                    Console.WriteLine(line);
                }
                else
                {
                    if (start2 <= start1 && end2 >= end1)
                    {
                        total++;
                        Console.WriteLine(line);
                    }
                }
            }
            return total;
        }

        static int D3(string filename)
        {
            int total = 0;
            string theText = File.ReadAllText(filename);
            List<char> overlap = new List<char>();
            List<char> overlapline = new List<char>();
            string[] lines = theText.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
        ); //splits whole file into a list seperated by the newlines
            foreach (string line in lines)
            {
                overlapline.Clear();
                List<char> first = new List<char>();
                List<char> second = new List<char>();
                int length = line.Length;
                int i = 0;
                foreach (char c in line)
                {
                    if (i < length / 2)
                    {
                        first.Add(c);
                    }
                    else
                    {
                        second.Add(c);
                    }
                    i++;
                }
                foreach (char c in second)
                {
                    if (first.Contains(c))
                    {
                        overlapline.Add(c);
                    }
                }
                foreach (char c in overlapline.Distinct())
                {
                    overlap.Add(c);
                }
            }
            foreach (char c in overlap)
            {
                int x = 0;
                if (char.IsUpper(c))
                {
                    x = c - 38;
                }
                else
                {
                    x = c - 96;
                }
                total = total + x;
            }
            return total;
        }

        static int D3P2(string filename)
        {
            int total = 0;
            string theText = File.ReadAllText(filename);
            string[] lines = theText.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None);
            int l = lines.Count();
            int index = 0;
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                if (index > l - 1)
                {
                    foreach (char c in sb.ToString())
                    {
                        int x = 0;
                        if (char.IsUpper(c))
                        {
                            x = c - 38;
                        }
                        else
                        {
                            x = c - 96;
                        }
                        total = total + x;
                    }
                    return total;
                }
                string firstElf = lines[index];
                string secondElf = lines[index + 1];
                string thirdElf = lines[index + 2];

                foreach (char c in firstElf)
                {
                    if (secondElf.Contains(c) && thirdElf.Contains(c))
                    {
                        sb.Append(c);
                        secondElf = "";
                    }
                }
                index = index + 3;

            }
        }
        static int D7(string filename)
        {
            string theText = File.ReadAllText(filename);
            string[] lines = theText.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
        );
            Dictionary<string, int> Dirs = new Dictionary<string, int>(); //where int corresponds to size
            foreach (string line in lines)
            {
                if (line.Contains("dir "))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(line.Substring(4, line.Length - 4));
                    if (!Dirs.ContainsKey(sb.ToString()))
                    {
                        Dirs.Add(sb.ToString(), 0);
                    }
                }
            }
            int total = 0;
            for (int i = 0; i < 10; i++)
            {
                int size = GetDirSize(lines, Dirs.Keys.ElementAt(i));

                if (size < 100000)
                {
                    total = total + size;
                }
            }
            return total;

        }
        static int GetDirSize(string[] lines, string DirName)
        {

            List<string> contents = new List<string>();
            string command = "$ cd " + DirName;
            int index = Array.IndexOf(lines, command) + 2;
            while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
            {
                contents.Add(lines[index]);
                index++;
            }
            int size = 0;
            foreach (string item in contents)
            {
                if (item.Contains("dir"))
                {
                    string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                    size = size + GetDirSize(lines, l[1]);

                }
                else
                {
                    string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                    int x = Int32.Parse(l[0]);
                    size = size + x;
                }
            }
            //   Console.WriteLine("dir {0} has size {1}", DirName, size);

            return size;

        }

        static int D7T2(string filename)
        {
            string theText = File.ReadAllText(filename);
            string[] lines = theText.Split(new string[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
        );
            Dictionary<string, int> Dirs = new Dictionary<string, int>(); //where int corresponds to size
            Dictionary<string, int> DirsValues = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                if (line.Contains("dir "))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(line.Substring(4, line.Length - 4));
                    if (!Dirs.ContainsKey(sb.ToString()))
                    {
                        Dirs.Add(sb.ToString(), 0);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                int size = 0;
                List<string> contents = new List<string>();
                string command = "$ cd " + kvp.Key;
                int index = Array.IndexOf(lines, command) + 2;
                while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                {
                    contents.Add(lines[index]);
                    index++;
                }
                bool ContainsDirs = false;
                foreach (string item in contents)
                {
                    if (item.Contains("dir"))
                    {
                        ContainsDirs = true;
                    }
                    else
                    {
                        string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                        int x = Int32.Parse(l[0]);
                        size = size + x;
                    }
                }
                if (ContainsDirs)
                {
                    size = 0;
                }
                else
                {
                    DirsValues.Add(kvp.Key, size);
                }

            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            foreach (KeyValuePair<string, int> kvp in Dirs)
            {
                if (DirsValues.ContainsKey(kvp.Key))
                {
                    //skip since already done
                }
                else
                {
                    int size = 0;
                    List<string> contents = new List<string>();
                    string command = "$ cd " + kvp.Key;
                    int index = Array.IndexOf(lines, command) + 2;
                    while (!lines[index].Contains("$ cd") && index < lines.Count() - 1)
                    {
                        contents.Add(lines[index]);
                        index++;
                    }
                    bool ContainsDirs = false;

                    foreach (string item in contents)
                    {
                        if (item.Contains("dir"))
                        {
                            string[] splitItem = item.Split(' ');
                            if (DirsValues.ContainsKey(splitItem[1]))
                            {
                                size = size + DirsValues[splitItem[1]];
                            }
                            else
                            {
                                ContainsDirs = true;
                            }
                        }
                        else
                        {
                            string[] l = item.Split(new string[] { " " }, StringSplitOptions.None);
                            int x = Int32.Parse(l[0]);
                            size = size + x;
                        }
                    }
                    if (ContainsDirs)
                    {
                        size = 0;
                    }
                    else
                    {
                        DirsValues.Add(kvp.Key, size);
                    }
                }
            }
            int total = 0;
            foreach (KeyValuePair<string, int> kvp in DirsValues)
            {
                if (kvp.Value < 100000)
                {
                    total = total + kvp.Value;
                }
            }
            return total;
        }

        static int D6(string filename)
        {
            string TheText = File.ReadAllText(filename);
            int steps = 0;
            while (true)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = steps; i < steps + 14; i++)
                {
                    sb.Append(TheText[i]);
                }

                if (sb.ToString().Count() == sb.ToString().Distinct().Count())
                {
                    return steps + 14;
                }
                steps++;
            }
        }

        static int D4P2(string filename)
        {
            string TheText = File.ReadAllText(filename);
            int total = 0;
            string[] lines = TheText.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string[] x = line.Split(new string[] { "-", "," }, StringSplitOptions.None);
                int one = Int32.Parse(x[0]);
                int two = Int32.Parse(x[1]);
                int three = Int32.Parse(x[2]);
                int four = Int32.Parse(x[3]);
                List<int> firstElf = new List<int>();
                List<int> secondElf = new List<int>();
                for (int i = one; i < two + 1; i++)
                {
                    firstElf.Add(i);
                }
                for (int j = three; j < four + 1; j++)
                {
                    secondElf.Add(j);
                }
                foreach (int z in firstElf)
                {
                    if (secondElf.Contains(z))
                    {
                        secondElf.Clear();
                        total++;
                    }
                }
            }
            return total;
        }

        static int D5(string filename)
        {
            string TheText = File.ReadAllText(filename);
            string[] lines = TheText.Split(new string[] { "\n" }, StringSplitOptions.None);

            List<Stack<char>> stacks = new List<Stack<char>>();
            string input = "TPZCSLQN LPTVHCG DCZF GWTDLMVC PWC PFJDCTSZ VWGBD NJSQHN RCQFSLV";
            //    input = "ZN MCD P";
            string[] l = input.Split(new string[] { " " }, StringSplitOptions.None);
            for (int i = 0; i < l.Length; i++)
            {
                stacks.Add(new Stack<char>(l[i]));
            }

            foreach (string line in lines)
            {
                string[] words = line.Split(new string[] { " " }, StringSplitOptions.None);
                int num = Int32.Parse(words[1]);
                int from = Int32.Parse(words[3]);
                int to = Int32.Parse(words[5]);
                for (int i = 0; i < num; i++)
                {
                    stacks[to - 1].Push(stacks[from - 1].Pop());
                }
            }
            return 0;
        }
        static int D5P2(string filename)
        {
            string TheText = File.ReadAllText(filename);
            string[] lines = TheText.Split(new string[] { "\n" }, StringSplitOptions.None);

            List<Stack<char>> stacks = new List<Stack<char>>();
            string input = "TPZCSLQN LPTVHCG DCZF GWTDLMVC PWC PFJDCTSZ VWGBD NJSQHN RCQFSLV";
            //     input = "ZN MCD P";
            string[] l = input.Split(new string[] { " " }, StringSplitOptions.None);
            for (int i = 0; i < l.Length; i++)
            {
                stacks.Add(new Stack<char>(l[i]));
            }
            Stack<char> aux = new Stack<char>();
            foreach (string line in lines)
            {
                string[] words = line.Split(new string[] { " " }, StringSplitOptions.None);
                int num = Int32.Parse(words[1]);
                int from = Int32.Parse(words[3]);
                int to = Int32.Parse(words[5]);
                for (int i = 0; i < num; i++)
                {
                    aux.Push(stacks[from - 1].Pop());
                }
                foreach (char c in aux)
                {
                    stacks[to - 1].Push(c);
                }
                aux.Clear();
            }
            return 0;
        }

        static int D8(string filename)
        {
            string text = File.ReadAllText(filename);
            string[] lines = text.Split(new string[] { "\n" }, StringSplitOptions.None);
            List<List<int>> rows = new List<List<int>>();
            int total = 0;
            foreach (string line in lines)
            {
                List<int> row = new List<int>();
                foreach (char c in line)
                {
                    if (c - '0' != -35) { row.Add(c - '0'); }
                }
                rows.Add(row);
            }
            var columns = rows
            .SelectMany(inner => inner.Select((item, index) => new { item, index }))
            .GroupBy(i => i.index, i => i.item)
            .Select(g => g.ToList())
            .ToList(); //from stack overflow


            for (int x = 0; x < rows.Count; x++) {
                for(int y = 0; y < columns.Count; y++)
                {
                    if (x==0 || x==columns.Count-1 || y == 0 || y == columns.Count - 1)
                    {
                        total++;
                    }
                    else
                    {
                        var beforeRow = rows[y].ToArray().Take(x);
                        var afterRow = rows[y].ToArray().Skip(x+1);
                        var beforeColumn = columns[x].ToArray().Take(y);
                        var afterColumn = columns[x].ToArray().Skip(y+1);
                        int target = rows[y][x];
                        
                        if(beforeRow.Max() < rows[y][x] || afterRow.Max() < rows[y][x] || beforeColumn.Max() < rows[y][x] || afterColumn.Max() < rows[y][x])
                        {
                            total++;
                        }
                    }
                }

            }      


            return total;
        }

        static int D8P2(string filename)
        {
                string text = File.ReadAllText(filename);
                string[] lines = text.Split(new string[] { "\n" }, StringSplitOptions.None);
                List<List<int>> rows = new List<List<int>>();
                int max = 0;
                foreach (string line in lines)
                {
                    List<int> row = new List<int>();
                    foreach (char c in line)
                    {
                        if (c - '0' != -35) { row.Add(c - '0'); }
                    }
                    rows.Add(row);
                }
                var columns = rows
                .SelectMany(inner => inner.Select((item, index) => new { item, index }))
                .GroupBy(i => i.index, i => i.item)
                .Select(g => g.ToList())
                .ToList(); //from stack overflow


                for (int x = 0; x < rows.Count; x++)
                {
                    for (int y = 0; y < columns.Count; y++)
                    {
                    int SS = 1;
                                   
                      
                    
                    var beforeRow = rows[y].ToArray().Take(x).Reverse().ToList();
                    var afterRow = rows[y].ToArray().Skip(x + 1).ToList();
                    var beforeColumn = columns[x].ToArray().Take(y).Reverse().ToList();
                    var afterColumn = columns[x].ToArray().Skip(y + 1).ToList();

                    int current = rows[y][x];
                    int SeeLeft = SeenTrees(current,beforeRow);
                    int SeeRight = SeenTrees(current, afterRow);
                    int SeeDown = SeenTrees(current, afterColumn);
                    int SeeUp = SeenTrees(current, beforeColumn);

                    SS = SeeRight * SeeUp * SeeDown * SeeLeft;
                    if (SS > max)
                    {
                        max = SS;
                    }


                }

                }


                return max;
            } 

        static int SeenTrees(int current, List<int> line)
        {
            int seen = 0;
            int biggest = 0;
            foreach(int i in line)
            {
                if (i < current)
                {

                    seen++;
                }
                else
                {
                    if (i >= current)
                    {
                        seen++;
                        return seen;
                    }
                }
            }
            return seen;
        }

      
        class Point
        {
            public int X,Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public double DistanceTo(Point other)
            {
                int VD = this.X - other.X;
                int HD = this.Y - other.Y;
                return Math.Sqrt(VD * VD + HD * HD);
            }

            public string Code()
            {
                return X.ToString() + "|" + Y.ToString();
            }
        }

        static int D9(string filename)
        {
            string Text = File.ReadAllText(filename);
                     
            StreamWriter fileStr = File.CreateText("D9 answers.txt");
            fileStr.WriteLine("answers");
            fileStr.Close();

           
            string[] lines = Text.Split(new string[] { "\r\n"}, StringSplitOptions.None);
            Point Head = new Point(0,0);
            Point Tail = new Point(0, 0);

            List<string> visited = new List<string>();
            foreach (string line in lines)
            {
                string[] x = line.Split(new string[] { " " }, StringSplitOptions.None);
                int num = Convert.ToInt32(x[1]);
                for (int i = 0; i < num; i++)
                {
                    switch (x[0])
                    {
                        case "R": 
                            Head.X++;
                            break;
                        case "L":
                            Head.X--;
                            break;
                        case "U":
                            Head.Y++;
                            break;
                        case "D":
                            Head.Y--;
                            break;
                    }
                    double Dist = Head.DistanceTo(Tail);


                    if (Dist == 2)
                    {
                        Tail.X = Tail.X + (Head.X - Tail.X) / 2;
                        Tail.Y = Tail.Y + (Head.Y - Tail.Y) / 2;
                    }
                    if (Dist > 2.2 && Dist < 2.3) //checks for root 5
                    {
                         if(Math.Abs(Tail.X - Head.X)==1)
                         {
                            Tail.X = Head.X;
                            Tail.Y = Tail.Y + (Head.Y - Tail.Y) / 2;
                         }
                        else
                        {
                            Tail.X = Tail.X + (Head.X - Tail.X) / 2;
                            Tail.Y = Head.Y;
                        }
                    }
                     
                    visited.Add(Tail.Code());
                    //    Console.WriteLine("H at {0} {1}", Head.X, Head.Y);
                    Console.WriteLine("T at {0} {1}", Tail.X, Tail.Y);
                }
                
            }
            return visited.Distinct().Count();

            
        }
        static int D9P2(string filename)
        {
            string Text = File.ReadAllText(filename);

            

            string[] lines = Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            

            List<Point> rope = new List<Point>();
            for (int i= 0; i<10; i++)
            {
                rope.Add(new Point(0, 0));
            }

            List<string> visited = new List<string>();
            foreach (string line in lines)
            {
                string[] x = line.Split(new string[] { " " }, StringSplitOptions.None);
                int num = Convert.ToInt32(x[1]);
                for (int i = 0; i < num; i++)
                {
                    switch (x[0])
                    {
                        case "R":
                            rope[0].X++;
                            break;
                        case "L":
                            rope[0].X--;
                            break;
                        case "U":
                            rope[0].Y++;
                            break;
                        case "D":
                            rope[0].Y--;
                            break;
                    }

                    for(int knot = 0; knot < 9; knot++)
                    {
                        rope[knot + 1] = SimStep(rope[knot], rope[knot + 1]);
                    }

                    visited.Add(rope[9].Code());
                    //    Console.WriteLine("H at {0} {1}", Head.X, Head.Y);
                    Console.WriteLine(rope[9].Code());
                }

            }
            return visited.Distinct().Count();


        
    }
        static Point SimStep(Point Head, Point Tail)
        {
            double Dist = Head.DistanceTo(Tail);


            if (Dist == 2)
            {
                Tail.X = Tail.X + (Head.X - Tail.X) / 2;
                Tail.Y = Tail.Y + (Head.Y - Tail.Y) / 2;
            }
            if (Dist > 2.2 && Dist < 2.3) //checks for root 5
            {
                if (Math.Abs(Tail.X - Head.X) == 1)
                {
                    Tail.X = Head.X;
                    Tail.Y = Tail.Y + (Head.Y - Tail.Y) / 2;
                }
                else
                {
                    Tail.X = Tail.X + (Head.X - Tail.X) / 2;
                    Tail.Y = Head.Y;
                }
            }
            if (Dist > 2.3)
            {
                Tail.X = Tail.X + (Head.X - Tail.X) / 2;
                Tail.Y = Tail.Y + (Head.Y - Tail.Y) / 2;
            }
            return Tail;
        }

        static int D10(string filename)
        {
            string text = File.ReadAllText(filename);
            string[] lines = text.Split(new string[] { "\n", "\r", "\r\n" }, StringSplitOptions.None);
            int cycle = 1;
            int sum = 1;
            int[] interesting = new int[] { 20, 60, 100, 140, 180, 220};
            int[] adjacent = new int[] { -1, 0, 1 };
            List<int> pixels = new List<int>();
            foreach (string line in lines)
            {   
                if (line.Contains("addx"))
                {
                    //draws pixel
                    if(adjacent.Contains(((cycle-1)%40)-sum))
                    {
                        Console.WriteLine(cycle);
                        pixels.Add(cycle);
                    }
                    cycle++;
                    if (adjacent.Contains(((cycle - 1) % 40) - sum))
                    {
                        Console.WriteLine(cycle);
                        pixels.Add(cycle);
                    }
                    //draws pixel
                    cycle++;                 
                    string[] x = line.Split(new string[] {" "}, StringSplitOptions.None);
                    int y = Convert.ToInt32(x[1]);
                    sum = sum + y;
                  

                }
                if (line.Contains("noop"))
                {
                    if (adjacent.Contains(((cycle - 1) % 40) - sum))
                    {
                        Console.WriteLine(cycle);
                        pixels.Add(cycle);
                    }
                    cycle++;                

                }
                
            }
            // 1,2,5,6,9,10,13,14,17,18
            for (int i = 1; i < 240; i++)
            {
                if (pixels.Contains(i))
                {
                    Console.Write('#');
                }
                else  Console.Write('.') ;
                if ((i % 40 == 0))
                {
                    Console.WriteLine();
                }
            }
            return 0;
        }//contains both parts

        static double D11Sample(string filename) //works on sample input, extend for actual
        {
            List<double> M0 = new List<double>() { 79,98 };
            List<double> M1 = new List<double>() { 54,65,75,74 };
            List<double> M2 = new List<double>() { 79,60,97 };
            List<double> M3 = new List<double>() { 74 };
            List<double> MB=  new List<double>() { 0, 0, 0, 0 };
            for (double i = 0; i < 20; i++)
            {
                List<List<double>> master = RoundsOnSample(M0, M1, M2, M3, MB);
                M0 = master[0];
                M1 = master[1];
                M2 = master[2];
                M3 = master[3];                
                
                MB[0] = master[4][0];
                MB[1] = master[4][1];
                MB[2] = master[4][2];
                MB[3] = master[4][3];
                


            }
            return 0;
        }
        static List<List<double>> RoundsOnSample(List<double> M0, List<double> M1, List<double> M2, List<double> M3, List<double> MB)
        {
            double c0 = MB[0];
            double c1 = MB[1];
            double c2 = MB[2];
            double c3 = MB[3];
            

            foreach (double i in M0)
            {
                c0++;
                double newWorry = i * 19;
            
                if (newWorry % 23 == 0) { M2.Add(newWorry); }
                else { M3.Add(newWorry); }
            }
            M0.Clear();
            foreach (double i in M1)
            {
                c1++;
                double NewWorry = i + 6;
          
                if (NewWorry % 19 == 0) { M2.Add(NewWorry); }
                else { M0.Add(NewWorry); }
            }
            M1.Clear();
            foreach (double i in M2)
            {
                c2++;
                double NewWorry = i * i;
             
                if (NewWorry % 13 == 0) { M1.Add(NewWorry); }
                else { M3.Add(NewWorry); }
            }
            M2.Clear();
            foreach (double i in M3)
            {
                c3++;
                double NewWorry = i + 3;
      
                if (NewWorry % 17 == 0) { M0.Add(NewWorry); }
                else { M1.Add(NewWorry); }
            }
            M3.Clear();

           



            List<List<double>> MasterMonkey = new List<List<double>>();
            MasterMonkey.Add(M0);
            MasterMonkey.Add(M1);
            MasterMonkey.Add(M2);
            MasterMonkey.Add(M3);
  
            List<double> MonkeyBusiness = new List<double>();
            MonkeyBusiness.Add(c0);
            MonkeyBusiness.Add(c1);
            MonkeyBusiness.Add(c2);
            MonkeyBusiness.Add(c3);

            MasterMonkey.Add(MonkeyBusiness);
            return MasterMonkey;
        }
        static int D11(string filename) //works on sample input, extend for actual
        {
            List<int> M0 = new List<int>() { 64, 89, 65, 95 };
            List<int> M1 = new List<int>() { 76, 66, 74, 87, 70, 56, 51, 66 };
            List<int> M2 = new List<int>() { 91, 60, 63 };
            List<int> M3 = new List<int>() { 92, 61, 79, 97, 79 };
            List<int> M4 = new List<int>() { 93, 54 };
            List<int> M5 = new List<int>() { 60, 79, 92, 69, 88, 82, 70 };
            List<int> M6 = new List<int>() { 64, 57, 73, 89, 55, 53 };
            List<int> M7 = new List<int>() { 62 };
            List<int> MB = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0};
            for(int i = 0; i < 20; i++)
            {
                List<List<int>> master = Rounds(M0, M1, M2, M3, M4, M5, M6, M7, MB);
                M0 = master[0];
                M1 = master[1];
                M2 = master[2];
                M3 = master[3];
                M4 = master[4];
                M5 = master[5];
                M6 = master[6];
                M7 = master[7];
                MB[0] = master[8][0];
                MB[1] = master[8][1];
                MB[2] = master[8][2];   
                MB[3] = master[8][3];
                MB[4] = master[8][4];
                MB[5] = master[8][5];
                MB[6] = master[8][6];
                MB[7] = master[8][7];        


            }
            return 0;
        }
        static List<List<int>> Rounds(List<int> M0, List<int> M1, List<int> M2, List<int> M3, List<int> M4, List<int> M5, List<int> M6, List<int> M7, List<int> MB)
        {
            int c0 = MB[0];
            int c1 = MB[1];
            int c2 = MB[2];
            int c3 = MB[3];
            int c4 = MB[4];
            int c5 = MB[5];
            int c6 = MB[6];
            int c7 = MB[7];

            foreach(int i in M0)
            {
                c0++;
                int newWorry = i * 7;
                newWorry = newWorry / 3;
                if(newWorry % 3 == 0) {M4.Add(newWorry);}
                else { M1.Add(newWorry);}
            }
            M0.Clear();

            foreach(int i in M1)
            {
                c1++;
                int NewWorry = i + 5;
                NewWorry = NewWorry / 3;
                if (NewWorry % 13 == 0) { M7.Add(NewWorry); }
                else { M3.Add(NewWorry); }
            }
            M1.Clear();

            foreach (int i in M2)
            {
                c2++;
                int NewWorry = i * i;
                NewWorry = NewWorry / 3;
                if (NewWorry % 2 == 0) { M6.Add(NewWorry); }
                else { M5.Add(NewWorry); }
            }
            M2.Clear();
            foreach (int i in M3)
            {
                c3++;
                int NewWorry = i + 6;
                NewWorry = NewWorry / 3;
                if (NewWorry % 11 == 0) { M2.Add(NewWorry); }
                else { M6.Add(NewWorry); }
            }
            M3.Clear();

            foreach (int i in M4)
            {
                c4++;
                int newWorry = i * 11;
                newWorry = newWorry / 3;
                if (newWorry % 5 == 0) { M1.Add(newWorry); }
                else { M7.Add(newWorry); }
            }
            M4.Clear();
            foreach (int i in M5)
            {
                c5++;
                int NewWorry = i + 8;
                NewWorry = NewWorry / 3;
                if (NewWorry % 17 == 0) { M4.Add(NewWorry); }
                else { M0.Add(NewWorry); }
            }
            M5.Clear();
            foreach (int i in M6)
            {
                c6++;
                int NewWorry = i + 1;
                NewWorry = NewWorry / 3;
                if (NewWorry % 19 == 0) { M0.Add(NewWorry); }
                else { M5.Add(NewWorry); }
            }
            M6.Clear();
            foreach (int i in M7)
            {
                c7++;
                int NewWorry = i + 4;
                NewWorry = NewWorry / 3;
                if (NewWorry % 7 == 0) { M3.Add(NewWorry); }
                else { M2.Add(NewWorry); }
            }
            M7.Clear();



            List<List<int>> MasterMonkey = new List<List<int>>();
            MasterMonkey.Add(M0);
            MasterMonkey.Add(M1);
            MasterMonkey.Add(M2);
            MasterMonkey.Add(M3);
            MasterMonkey.Add(M4);
            MasterMonkey.Add(M5);
            MasterMonkey.Add(M6);
            MasterMonkey.Add(M7);
            List<int> MonkeyBusiness = new List<int>();
            MonkeyBusiness.Add(c0);
            MonkeyBusiness.Add(c1);
            MonkeyBusiness.Add(c2);
            MonkeyBusiness.Add(c3);
            MonkeyBusiness.Add(c4);
            MonkeyBusiness.Add(c5);
            MonkeyBusiness.Add(c6);
            MonkeyBusiness.Add(c7);
            MasterMonkey.Add(MonkeyBusiness);
            return MasterMonkey;
        }
     
        class SampleItem 
        {
            private const int divisorCount = 4;
            private static int[] divisors = new int[divisorCount] { 23, 19, 13, 17 };

            private int[] remainders;

            public SampleItem(int num)
            {
                remainders = new int[divisorCount];
                for(int i = 0; i< divisorCount; i++)
                {
                    remainders[i] = num % divisors[i];
                }
            }
            public SampleItem(int[] remainders)
            {
                this.remainders = remainders;
            }

            public SampleItem Add (int num)
            {
                int[] newRemainders = new int[divisorCount];
                for(int i = 0; i< divisorCount; i++)
                {
                    newRemainders[i] = (remainders[i]+num) % divisors[i];
                }
                return new SampleItem(newRemainders);
            }
            public SampleItem Multiply(int num)
            {
                int[] newRemainders = new int[divisorCount];
                for (int i = 0; i < divisorCount; i++)
                {
                    newRemainders[i] = (remainders[i] * num) % divisors[i];
                }
                return new SampleItem(newRemainders);
            }
            public SampleItem Square()
            {
                int[] newRemainders = new int[divisorCount];
                for (int i = 0; i < divisorCount; i++)
                {
                    newRemainders[i] = (remainders[i] * remainders[i]) % divisors[i];
                }
                return new SampleItem(newRemainders);
            }


        }

        static int D11P2Sample(string filename)
        {
            List<SampleItem> M0 = new List<SampleItem>();
            List<SampleItem> M1 = new List<SampleItem>();
            List<SampleItem> M2 = new List<SampleItem>();
            List<SampleItem> M3 = new List<SampleItem>();

            List<int> M0c = new List<int>() { 79, 98 };
            List<int> M1c = new List<int>() { 54, 65, 75, 74 };
            List<int> M2c = new List<int>() { 79, 60, 97 };
            List<int> M3c = new List<int>() { 74 };

            foreach(int i in M0c)
            {
                M0.Add(new SampleItem(i));
            }
            foreach (int i in M1c)
            {
                M1.Add(new SampleItem(i));
            }
            foreach (int i in M2c)
            {
                M2.Add(new SampleItem(i));
            }
            foreach (int i in M3c)
            {
                M3.Add(new SampleItem(i));
            }

            return 0;
        }

        static (List<List<SampleItem>>, List<int>) RoundsSampleP2 (List<SampleItem> M0, List<SampleItem> M1, List<SampleItem> M2, List<SampleItem> M3, List<int> MB)
        {
            int c0 = MB[0];
            int c1 = MB[1];
            int c2 = MB[2];
            int c3 = MB[3];
            foreach (SampleItem item in M0)
            {
                c0++;
                SampleItem newWorry = item.Multiply(23);
            }
            M0.Clear();

            foreach (SampleItem item in M1)
            {
                c1++;
                SampleItem newWorry = item.Add(6);
            }
            M1.Clear();

            foreach (SampleItem item in M2)
            {
                c2++;
                SampleItem newWorry = item.Square();
            }
            M2.Clear();

            foreach (SampleItem item in M3)
            {
                c3++;
                SampleItem newWorry = item.Add(6);
            }
            M3.Clear();
            List<List<SampleItem>> list = new List<List<SampleItem>>();
            list.Add(M0);
            list.Add(M1);
            list.Add(M2);
            list.Add(M3);
            List<int> MonkeBusiness = new List<int>();
            MonkeBusiness.Add(c0);
            MonkeBusiness.Add(c1);
            MonkeBusiness.Add(c2);
            MonkeBusiness.Add(c3);

            (List<List<SampleItem>>, List<int>) rv = (list, MonkeBusiness);
            return rv;
        }

        static void Main(string[] args)
        {

            string input = "Day 11 small";
            
            Console.WriteLine(D11P2Sample(input));
            Console.ReadKey();
            }
        }
    } 
