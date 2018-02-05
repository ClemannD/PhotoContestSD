using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO change the name
public static class ImportantInfo{

	public static int userId;
	//public static List<NetworkAPI.contestInfo> listOfContests;
	public static NetworkAPI.contestInfo contestOfWeek;



	public static void SetCurrentWeekData(){
		//Debug.Log ("hi " + (37 / 7));
		//Debug.Log ("hi " + (41 / 7));
		NetworkAPI.RetrieveAllContestsResponse response = NetworkAPI.RetrieveAllContests (5, "donothackplz");
		Debug.Log ("it says day is " + DateTime.Now.DayOfYear);
		int currentWeek = (DateTime.Now.DayOfYear / 7) - 4;
		foreach (NetworkAPI.contestInfo contest in response.allContests) {
			if (contest.week == currentWeek) {
				contestOfWeek = contest;
			}
		}
		Debug.Log ("week is " + contestOfWeek.week);
	}
}
