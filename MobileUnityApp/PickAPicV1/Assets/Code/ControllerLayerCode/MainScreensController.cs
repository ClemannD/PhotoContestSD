using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreensController:MonoBehaviour{
	

	protected virtual void AddListeners(MainScreensUI userUI){
		userUI.competeButton.onClick.AddListener(CompetePressed);
		userUI.entriesButton.onClick.AddListener(EntriesPressed);
		userUI.profileButton.onClick.AddListener(ProfilePressed);
		userUI.pastContestsButton.onClick.AddListener(PastContestsPressed);
	}


	public virtual void CompetePressed(){
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
