using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomlyn;

namespace Andtech.Wink
{

	internal class Config
	{
		public string Default { get; set; }
		public Dictionary<string, string> Alias { get; set; }

		public static bool TryRead(out Config config)
		{
			try
			{
				var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "wink.toml");
				var content = File.ReadAllText(path);

				config = Toml.ToModel<Config>(content, path);

				return true;
			}
			catch
			{
				config = default;
			}
			return false;
		}

		public string ExpandAliases(string input)
		{
			if (Alias.TryGetValue(input, out var value))
			{
				return value;
			}

			return input;
		}
	}
}
