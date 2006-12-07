using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DevCalcNET
{

	/// <summary>
	/// Summary description for ApplicationInstanceLimiter.
	/// </summary>
	public class ApplicationInstanceLimiter
	{
		[DllImport("user32.dll")] private static extern  bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("user32.dll")] private static extern  bool OpenIcon(IntPtr hWnd);

		private ApplicationInstanceLimiter()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//Add this code in the form_load event.. (the form which loaded and shown
		//as the first form)
		//This works well with an MDI form or a non-MDI form

		public static bool Limit()
		{
			string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
			Process[] processes = System.Diagnostics.Process.GetProcessesByName(name);
			if(processes.Length > 1)
			{
				//Send opening form's TEXT property as a parameter to the function "ActivatePrevInstance"
				//This works well with an MDI form or a non-MDI form
				//It is advised that you give a Unique name to your Form so that it doe
				//not conflict with other applications
				ActivatePrevInstance();
				return true;
			}
			return false;
		}

		private static void ActivatePrevInstance()
		{
			IntPtr PrevHndl = IntPtr.Zero;

			Process[] objProcesses;

			objProcesses = Process.GetProcesses();

			foreach(Process objProcess in objProcesses)
			{
				if(objProcess.Equals(System.Diagnostics.Process.GetCurrentProcess()))
				{
					continue;
				}
				if(objProcess.ProcessName == System.Diagnostics.Process.GetCurrentProcess().ProcessName)
				{
					PrevHndl = objProcess.MainWindowHandle;
					if(PrevHndl != IntPtr.Zero)
					{
						break;
					}
				}
			}
			if(PrevHndl == IntPtr.Zero)
			{
				return;
			}

			OpenIcon(PrevHndl);
			SetForegroundWindow(PrevHndl);
		}
}
}
