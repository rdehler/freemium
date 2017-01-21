using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {
	public static int DEMO_TIMER = 3000; // milliseconds
	public static double DEMO_MULTIPLIER = 1.3;
	// for testing purposes
	public static int MAX_LEVELS = 9;

	public static int MAX_POINTS = 10000; // 10000 seconds is just over 2.5 hours

	public static int TEXT_TIMEOUT_SECONDS = 3;

	public static int BORED_TIMEOUT = 5;

	public static int NUM_BORED = 5;
	public static Dictionary<string, string> DIALOG = new Dictionary<string, string> () {
		{"BORED_0", "Gosh I wonder what my family is up to..."},
		{"BORED_1", "I can't remember the last time I slept..."},
		{"BORED_2", "Just one more level..."},
		{"BORED_3", "I'm pretty sure it's impossible to beat this game..."},
		{"BORED_4", "I wonder if it's sunny outside..."}
	};

}
