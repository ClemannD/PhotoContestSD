﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceInfo {

	public const int ANDROID = 0;
	public const int IOS = 1;
	public const int WINDOWS = 2;



	public static int thisDeviceOS = 0;//set this somewhere



//	public const string ANDROID_START_PATH = "";

	public static string GetStartPath(){
		if (thisDeviceOS == ANDROID) {
			return "/sdcard/DCIM";
		} else if (thisDeviceOS == WINDOWS) {
			return "C:\\PicsStuff";//dont need this later
		} else if (thisDeviceOS == IOS) {
			return "/private/var/mobile/Media/DCIM/";
		} else {
			return "";
		}
	}



}
