#region

// -----------------------------------------------------
// MIT License
// Copyright (C) 2012 John M. Baughman (jbaughmanphoto.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial
// portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// -----------------------------------------------------

#endregion

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