using Roslyn.Scripting.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace node.cs
{
    class NodeCS
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: node.cs <filepath>");
                return;
            }
            try
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    string code = sr.ReadToEnd();
                    var engine = new ScriptEngine();
                    engine.AddReference("System");

                    var session = engine.CreateSession();
                    session.Execute("using System;");

                    session.Execute(code);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

