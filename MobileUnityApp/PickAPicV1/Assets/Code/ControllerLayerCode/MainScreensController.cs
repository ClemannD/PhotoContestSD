using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreensController:MonoBehaviour{
	
	protected void AddMainListeners(MainScreensUI mainUI){
		mainUI.competeButton.onClick.AddListener(CompetePressed);
		mainUI.entriesButton.onClick.AddListener(EntriesPressed);
		mainUI.profileButton.onClick.AddListener(EntriesPressed);
		mainUI.pastContestsButton.onClick.AddListener(PastContestsPressed);
	}
		

	/// <summary>
	/// Activated when the compete button is pressed. Takes the user to the compete screen 
	/// </summary>
	protected virtual void CompetePressed(){
		SceneTransitions.NextScene (SceneIndices.COMPETE);
	}

	/// <summary>
	/// Activated when the entries button is pressed. Takes the user to the entries screen
	/// </summary>
	protected virtual void EntriesPressed(){
		SceneTransitions.NextScene (SceneIndices.ENTRIES);
	}

	/// <summary>
	/// Activated when the profile button is pressed. Takes the user to the profile screen
	/// </summary>
	protected virtual void ProfilePressed(){
		SceneTransitions.NextScene (SceneIndices.PROFILE);
	}

	/// <summary>
	/// Called when the past contests button is pressed. Takes the user to the past contests screen
	/// </summary>
	protected virtual void PastContestsPressed(){
		SceneTransitions.NextScene (SceneIndices.PAST_CONTESTS);
	}

}
