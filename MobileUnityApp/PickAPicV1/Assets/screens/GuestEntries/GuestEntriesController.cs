using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestEntriesController : MonoBehaviour, IImageAdder {

	public GuestEntriesUI ui;



	void Start(){
		
		ui.login.onClick.AddListener (Login);
		ui.register.onClick.AddListener (Register);
		Refresh ();
	}

	public MonoBehaviour GetMyMonoBehavior(){
		return this;
	}

	public void Refresh(){
		ImageAddingHelper addEntries = new ImageAddingHelper (this);
		NetworkAPI.RetrieveCurrentContestsResponse response = NetworkAPI.GetCurrentContestInfo ();
		int contestId = response.contest_id;
		ui.SetTheme (response.category);
		List<NetworkAPI.imageInfo> entries = NetworkAPI.RetrieveImages(contestId).allImages;
		List<IServerImage> imagesToDisplay = new List<IServerImage> ();
		foreach (NetworkAPI.imageInfo item in entries) {
			if (item.isFlagged == 1) {
				continue;
			}
			ImageForVoting voteable = new ImageForVoting (item);

			imagesToDisplay.Add (voteable);
		}

		addEntries.DownloadAndDisplayImages (imagesToDisplay);

	}

	public void AddImage(IServerImage entry){
		ui.AddImage((ImageForVoting)entry);
	}

	public void Login(){
		SceneTransitions.NextScene (SceneIndices.LOGIN_SCREEN);
	}

	public void Register(){
		SceneTransitions.NextScene (SceneIndices.CREATE_ACCOUNT);
	}






}
