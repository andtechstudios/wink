using System;
using WindowsInput;
using WindowsInput.Native;

public class Program
{

	public static void Main(string[] args)
	{
		VirtualKeyCode code;
		switch (args[0])
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
				throw new ArgumentException($"Unsupported key event: {args[0]}");
		}

		new InputSimulator()
			.Keyboard
			.KeyPress(code);
	}
}

