using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JBP.ExplorerUtilities {

	internal static class Program {

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(string[] args) {
			string opt = args.Length > 0 ? args[0] : string.Empty;

			if (!string.IsNullOrEmpty(opt)) {
				string file = args.Length > 1 ? args[1] : string.Empty;
				switch (opt.ToLower()) {
					case "createfolder":
						CreateFolder();
						break;

					case "copyfilepath":
						Clipboard.SetText(Path.GetFileName(file));
						break;

					case "copyfullpath":
						Clipboard.SetText(Path.GetFullPath(file));
						break;

					case "copyfolderpath":
						Clipboard.SetText(Path.GetDirectoryName(file));
						break;
				}
			}
		}

		private static void CreateFolder() {
			string folder = string.Empty;
			if (InputBox.Show("Create Folder", "Enter folder to create:", ref folder) == DialogResult.OK) {
				if (!string.IsNullOrEmpty(folder)) {
					Directory.CreateDirectory(folder);
				}
				else {
					MessageBox.Show("No folder entered.");
				}
			}
		}
	}
}