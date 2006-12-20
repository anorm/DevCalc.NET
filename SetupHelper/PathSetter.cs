using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace SetupHelper
{
    [RunInstaller(true)]
    public partial class PathSetter : Installer
    {
        public PathSetter()
        {
            InitializeComponent();
        }

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string loc = Context.Parameters["loc"];
            string oldPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User);
            if(oldPath == null) oldPath = "";
            if(!oldPath.EndsWith(";"))
            {
                oldPath += ";";
            }

            Environment.SetEnvironmentVariable("path", oldPath + loc, EnvironmentVariableTarget.User);
        }

        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            string loc = Context.Parameters["loc"];
            string oldPath = Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User);
            if(oldPath == null) oldPath = "";
            string newPath = oldPath.Replace(";" + loc, "");

            if(newPath != oldPath)
            {
                Environment.SetEnvironmentVariable("path", newPath, EnvironmentVariableTarget.User);
            }

            base.Uninstall(savedState);
        }
    }
}