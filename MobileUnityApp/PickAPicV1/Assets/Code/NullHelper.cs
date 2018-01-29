using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Has method(s) to check for nulls and return something better if needed
/// </summary>
public class NullHelper{

	/// <summary>
	/// Gets the string in the input field passed in.
	/// </summary>
	/// <returns>The string in the input string or null if there is no string typed into the input field</returns>
	/// <param name="f">F.</param>
	public static string SafeInputStringReturn(InputField f){
		string s = "";
		try {
			s = f.text;
		} catch (System.Exception ex) {
			
		}

		return s;
	}
}
