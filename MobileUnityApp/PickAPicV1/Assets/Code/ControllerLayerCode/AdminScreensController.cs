using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminScreensController:MonoBehaviour {


	protected void AddAdminListeners(AdminScreensUI adminUI){
		
	}

	public void AdminPressed(){

	}

	/// <summary>
	/// Activated when the entries button is pressed. Takes the user to the entries screen
	/// </summary>0
	protected virtual void EntriesPressed(){
		SceneTransitions.NextScene (SceneIndices.ADMIN_ENTRIES);
	}

	/// <summary>
	/// Activated when the profile button is pressed. Takes the user to the profile screen
	/// </summary>
	protected virtual void ProfilePressed(){
		SceneTransitions.NextScene (SceneIndices.ADMIN_PROFILE);
	}

	/// <summary>
	/// Called when the past contests button is pressed. Takes the user to the past contests screen
	/// </summary>
	protected virtual void PastContestsPressed(){
		SceneTransitions.NextScene (SceneIndices.PAST_CONTESTS);
	}
		

}
