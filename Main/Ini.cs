using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Lab1.Exceptions;
using FileNotFoundException = Lab1.Exceptions.FileNotFoundException;
using KeyNotFoundException = Lab1.Exceptions.KeyNotFoundException;


namespace Lab1
{
    class IniFile
    {
        private Dictionary<string, Dictionary<string, string>> dict = 
            new Dictionary<string, Dictionary<string, string>>();

        public void Parse(string path)
        {
            if(!System.IO.File.Exists(path))
                throw new FileNotFoundException(path);
            
            if(path.Split('.')[1] != "ini")
                throw new WrongFileTypeException();
            
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string section = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(";"))
                        line = line.Substring(0, line.IndexOf(';'));

                    if (line.Contains("["))
                    {
                        section = line.Substring(1, line.IndexOf(']')-1);
                    }
                    else
                    {
                        if (line.Contains("="))
                        {
                            string key = line.Split('=')[0].Trim();
                            string value = line.Split('=')[1].Trim();
                            
                            Dictionary<string, string> inner;
                            if (section == null)
                                throw new ErrorInFileException();
                            else
                            {
                                if (!dict.TryGetValue(section, out inner))
                                    dict.Add(section, inner = new Dictionary<string, string>());
                                inner[key] = value;
                            }
                        }
                    }
                }
            }
        }

        public string getString(string section, string key)
        {
            if (!dict.ContainsKey(section))
                throw new SectionNotFoundException(section);
            
            if (!dict[section].ContainsKey(key))
                throw new KeyNotFoundException(key);
            
            return dict[section][key];
        }

        public int getInt(string section, string key)
        {
            var value = getString(section, key);
            if (int.TryParse(value, out var parsedValue))
                return parsedValue;
            throw new WrongVarTypeException("Int");
        }
        
        public double getDouble(string section, string key)
        {
            var value = getString(section, key);
            if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedValue))
                return parsedValue;
            throw new WrongVarTypeException("Double");
        }
    }
}