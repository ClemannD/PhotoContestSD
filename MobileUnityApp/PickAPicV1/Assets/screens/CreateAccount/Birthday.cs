using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Birthday{

	public int day;
	public int month;
	public int year;


	public Birthday(int day, int month, int year){
		this.day = day;
		this.month = month;
		this.year = year;
	}

	//TODO
	public bool OlderThan(int ageInYears){
		DateTime currDate = DateTime.Now;
		DateTime testDate = new DateTime (currDate.Year - ageInYears, currDate.Month, currDate.Day);


		DateTime person = new DateTime (this.year, this.month, this.day);

		if (person.CompareTo (testDate) <= 0) {
			return true;
		} else {
			return false;
		}

	}


}
