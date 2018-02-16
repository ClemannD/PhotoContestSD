using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO change the name
public static class ContestInfo{


	//public static List<NetworkAPI.contestInfo> listOfContests;
	private static NetworkAPI.RetrieveCurrentContestsResponse contestOfWeek;



	public static void SetCurrentWeekData(){
		contestOfWeek = NetworkAPI.GetCurrentContestInfo ();
	}

	public static int GetWeekNumber(){
		return contestOfWeek.week;
	}

	public static string GetWeekTheme(){
		return contestOfWeek.category;
	}

	public static int GetContestID(){
		return contestOfWeek.contest_id;
	}

}
