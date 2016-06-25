using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Past.Tools
{
    //Don't laugh :(
    class ParseProtocolEnums
    {
        static Dictionary<string, List<string>> _data = new Dictionary<string, List<string>>();

        public static void ParseEnums(string @source)
        {
            string _name;
            string _enum;
            foreach (string file in Directory.GetFiles(source, "*", SearchOption.AllDirectories).Where(x => x.Contains("as")))
            {
                _name = Path.GetFileName(file).Replace(".as", "");
                foreach (string line in File.ReadAllLines(file).Where(x => x.Contains("public static const")))
                {
                    _enum = line.Replace("public static const", "").Replace(":uint", "").Replace(":int", "").Replace(";", ",").Trim();
                    if (!_data.ContainsKey(Path.GetFileName(file).Replace(".as", "")))
                        _data.Add(_name, new List<string>());
                    _data[_name].Add(_enum);
                }
            }
            foreach (var shit in _data)
            {
                using (StreamWriter writer = new StreamWriter(String.Format("{0}/Enums/{1}", AppDomain.CurrentDomain.BaseDirectory, shit.Key + ".cs")))
                {
                    writer.WriteLine("namespace Past.Protocol.Enums");
                    writer.WriteLine("{");
                    writer.WriteLine("".PadLeft(4) + "public enum " + shit.Key);
                    writer.WriteLine("".PadLeft(4) + "{");
                    foreach (var shit2 in shit.Value)
                    {
                        writer.WriteLine("".PadLeft(8) + "{0}", shit2);

                    };
                    writer.WriteLine("".PadLeft(4) + "}");
                    writer.WriteLine("}");
                    writer.Close();
                }
            }
        }
    }
}
