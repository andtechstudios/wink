using Andtech.Common;
using Andtech.Wink;
using System;
using WindowsInput;
using WindowsInput.Native;

public class Program
{

	public static void Main(string[] args)
	{
		Config.TryRead(out var config);

		var input = args.Length > 0 ? args[0] : null;
		var command = input ?? config?.Default;
		command = config?.ExpandAliases(command) ?? command;
		var code = GetKeyCode(command);

		Log.WriteLine(code, ConsoleColor.Green);

		new InputSimulator()
			.Keyboard
			.KeyPress(code);
	}

	static VirtualKeyCode GetKeyCode(string command)
	{
		VirtualKeyCode code = default;
		switch (command)
		{
			case "play":
				code = VirtualKeyCode.PLAY;
				break;
			case "pause":
				code = VirtualKeyCode.PAUSE;
				break;
			case "playpause":
				code = VirtualKeyCode.MEDIA_PLAY_PAUSE;
				break;
			case "previous":
				code = VirtualKeyCode.MEDIA_PREV_TRACK;
				break;
			case "next":
				code = VirtualKeyCode.MEDIA_NEXT_TRACK;
				break;
			case "stop":
				code = VirtualKeyCode.MEDIA_STOP;
				break;
			case "mute":
				code = VirtualKeyCode.VOLUME_MUTE;
				break;
			default:
				Log.Error.WriteLine($"Unsupported key event '{command}'.", ConsoleColor.Red);
				Environment.Exit(-1);
				break;
		}

		return code;
	}
}

