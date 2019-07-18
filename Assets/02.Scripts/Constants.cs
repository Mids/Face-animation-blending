using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
	// TODO: dataPath is different on each platform. If you are in OSX, change it to "/../../"
	public static readonly string WaveFilePath = "file:///" + Application.dataPath + "/../";
	public static readonly string WaveFileName = "byte.wav";
}