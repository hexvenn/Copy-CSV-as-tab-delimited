using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

[assembly: CLSCompliant(true)]
namespace CopyCSV
{
	static class Program
	{
		// file type to register
		const string FileType = "Excel.CSV";

		// context menu name in the registry
		const string KeyName = "CSV to clipboard";

		// context menu text
		const string MenuText = "Copy tab-delimited";

		[STAThread]
		static void Main(string[] args)
		{
			// process register or unregister commands
			if (!ProcessCommand(args))
			{
                // invoked from shell, process the selected file
                CopyTabDelimited(args[0]);
			}
		}

		/// <summary>
		/// Process command line actions (register or unregister).
		/// </summary>
		/// <param name="args">Command line arguments.</param>
		/// <returns>True if processed an action in the command line.</returns>
		static bool ProcessCommand(string[] args)
		{
			// register
			if (args.Length == 0 || string.Compare(args[0], "-register", true) == 0)
			{
				// full path to self, %L is placeholder for selected file
				string menuCommand = string.Format(
					"\"{0}\" \"%L\"", Application.ExecutablePath);

				// register the context menu
				FileShellExtension.Register(Program.FileType,
					Program.KeyName, Program.MenuText,
					menuCommand);

				MessageBox.Show(string.Format(
					"Shell extension has been registered.",
					Program.KeyName), Program.KeyName);

				return true;
			}

			// unregister		
			if (string.Compare(args[0], "-unregister", true) == 0)
			{
				// unregister the context menu
				FileShellExtension.Unregister(Program.FileType, Program.KeyName);

				MessageBox.Show(string.Format(
					"The {0} shell extension was unregistered.",
					Program.KeyName), Program.KeyName);

				return true;
			}

			// command line did not contain an action
			return false;
		}


        static void CopyTabDelimited(string filePath)
        {
            try
            {
                string text = File.ReadAllText(filePath);
                text = text.Replace(",", "\t");
                Clipboard.SetText(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message), Program.KeyName);
                return;
            }
        }
    }
}
