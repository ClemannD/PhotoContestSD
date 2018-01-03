using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreensController : MonoBehaviour {
	private MainScreensUI ui;

	public MainScreensController(MainScreensUI ui){
		this.ui = ui;
	}

	/// <summary>
	/// Activated when the compete button is pressed. Takes the user to the compete screen 
	/// </summary>
	public void CompetePressed(){
		SceneTransitions.NextScene (SceneIndices.COMPETE);
	}

	/// <summary>
	/// Activated when the entries button is pressed. Takes the user to the entries screen
	/// </summary>
	public void EntriesPressed(){
		SceneTransitions.NextScene (SceneIndices.ENTRIES);
	}

	/// <summary>
	/// Activated when the profile button is pressed. Takes the user to the profile screen
	/// </summary>
	public void ProfilePressed(){
		SceneTransitions.NextScene (SceneIndices.PROFILE);
	}

	/// <summary>
	/// Called when the past contests button is pressed. Takes the user to the past contests screen
	/// </summary>
	public void PastContestsPressed(){
		SceneTransitions.NextScene (SceneIndices.PAST_CONTESTS);
	}

}
