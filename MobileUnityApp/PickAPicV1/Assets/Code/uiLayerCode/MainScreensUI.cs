using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Starting main screen superclass, to be used wuth UI classes that have the navigation buttons at the bottom of the screen
/// </summary>
public class MainScreensUI : MonoBehaviour {

	private MainScreensController controller;

	void Start(){
		controller = new MainScreensController ();
	}

	/// <summary>
	/// Responds to a press of the compete button. Calls the controller layer to take action.
	/// </summary>
	public void CompeteListener(){
		controller.CompetePressed ();
	}

	/// <summary>
	/// Responds to a press of the entries button. Calls the controller layer to take action.
	/// </summary>
	public void EntriesListener(){
		controller.EntriesPressed ();
	}

	/// <summary>
	/// Respods to a press of the profile button. Calls the controller layer to take action.
	/// </summary>
	public void ProfileListener(){
		controller.ProfilePressed ();
	}

	/// <summary>
	/// Responds to a press of the past contests button. Calls the controller layer to take action.
	/// </summary>
	public void PastContestsPressed(){
		controller.PastContestsPressed ();
	}
}
