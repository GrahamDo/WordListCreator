using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WordListCreator
{
	public class Worker
	{
		private const byte MINIMUM_WORD_LENGTH = 3;

		public void Do(string sourceFile, string outputFile)
		{
			string allText = File.ReadAllText(sourceFile);
			Regex rgx = new Regex("[^a-zA-Z]");
			allText = rgx.Replace(allText, " ");

			string[] words = allText.Split(new string[] { "\r\n", "\n", " ", "-" }, StringSplitOptions.None);
			StringBuilder wordList = BuildWordList(words);
			File.WriteAllText(outputFile, wordList.ToString ());
		}

		private StringBuilder BuildWordList (string[] words)
		{
			StringBuilder results = new StringBuilder ();
			List<string> duplicateCheck=new List<string>();

			foreach (string word in words) {
				if (word.Length >= MINIMUM_WORD_LENGTH && !duplicateCheck.Contains (word)){
					results.AppendLine(word);
					duplicateCheck.Add (word);
				}
			}
			return results;
		}
	}
}

