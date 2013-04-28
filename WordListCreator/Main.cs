using System;
using System.IO;

namespace WordListCreator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length != 2) {
				WriteUsage ();
				return;
			}

			string sourceFile = args [0];
			if (!File.Exists (sourceFile)) {
				WriteFileNotFound (sourceFile);
				return;
			}

			string outputFile = args [1];
			if (File.Exists (outputFile)) {
				WriteFileExists (outputFile);
				return;
			}

			Worker work = new Worker();
			work.Do (sourceFile, outputFile);
		}

		public static void WriteHeader()
		{
			Console.WriteLine ("WordListCreator");
			Console.WriteLine ("Copyright (c) 2013 by Graham Downs");
			Console.WriteLine ();
		}

		public static void WriteUsage()
		{
			WriteHeader();
			Console.WriteLine ("Usage:");
			Console.WriteLine ("\tWordListCreator <SourceFile> <OutputFile>");
			Console.WriteLine ();
			Console.WriteLine("Extracts all words from SourceFile, excludes non alphabetic characters, and writes all words with a minimum length of 3 letters to OutputFIle");
			Console.WriteLine();
		}

		public static void WriteFileExists(string fileName)
		{
			WriteHeader();
			Console.WriteLine(string.Format("File {0} already exists!", fileName));
			Console.WriteLine ();
		}

		public static void WriteFileNotFound(string fileName)
		{
			WriteHeader();
			Console.WriteLine(string.Format("File {0} does not exist!", fileName));
			Console.WriteLine ();
		}
	}
}
