using Frosty.Core;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IronPythonPlugin.Python
{
    public static class Interpreter
    {
        private static ScriptRuntime Runtime;
        private static ScriptEngine Engine;

        private static StringBuilder commandLine = new StringBuilder();
        public static string CommandLine { get => commandLine.ToString(); }
        public static CommandLineModel CommandLineModel = new CommandLineModel();

        public static void Initialize()
        {
            Runtime = IronPython.Hosting.Python.CreateRuntime();
            Engine = Runtime.GetEngine("py");

            Engine.Runtime.Globals.SetVariable("App.AssetManager", Frosty.Core.App.AssetManager);
            CommandLineModel.OnPropertyChanged(CommandLine);
        }

        /// <summary>
        /// Execute script expression
        /// </summary>
        /// <param name="expression"></param>
        public static void ExecuteString(string expression, Microsoft.Scripting.SourceCodeKind sourceCodeKind = Microsoft.Scripting.SourceCodeKind.AutoDetect)
        {
            ScriptScope Scope = Runtime.CreateScope();
            ScriptSource Source = Engine.CreateScriptSourceFromString(expression, sourceCodeKind);
            object result = Source.Execute(Scope);
            //commandLine.AppendLine(Engine.Operations.Format(result));
            App.Logger.Log(Engine.Operations.Format(result));
            CommandLineModel.OnPropertyChanged(CommandLine);
        }

        /// <summary>
        /// Execute script file
        /// </summary>
        /// <param name="path">Full path to script file</param>
        public static void ExecuteFile(string path)
        {
            ScriptScope Scope = Runtime.CreateScope();
            ScriptSource Source = Engine.CreateScriptSourceFromFile(path);
            object result = Source.Execute(Scope);
            commandLine.AppendLine(Engine.Operations.Format(result));
            CommandLineModel.OnPropertyChanged(CommandLine);
        }
    }

    public class CommandLineModel : INotifyPropertyChanged
    {
        public string CommandLine
        {
            get => Interpreter.CommandLine;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
