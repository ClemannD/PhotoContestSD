using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EntriesController:NormalUserScreensController{
	public EntriesUI ui;

	void Start(){
		AddListeners (ui);
		StartCoroutine (RefreshPics ());
	}
		






	private IEnumerator RefreshPics(){



		Debug.Log ("week is: " + ContestInfo.GetWeekNumber());




		NetworkAPI.RetrieveAllImagesResponse response = NetworkAPI.RetrieveImages (21);//(ContestInfo.GetContestID());//TODO
		List<NetworkAPI.imageInfo> listOfEntries = response.allImages;


		List<ImageForVoting> readyImages = new List<ImageForVoting> ();
		Debug.Log ("num images from server: " + listOfEntries.Count);
		foreach (NetworkAPI.imageInfo entry in listOfEntries) {
			
			
			UnityWebRequest request = UnityWebRequestTexture.GetTexture ("http://pick-apic.com/" + entry.image_url);
			request.SendWebRequest ();
			Debug.Log ("here we go");
				while (!request.isDone) {
					yield return null;
				}
			Debug.Log ("done");
				if (request.isDone) {
					Debug.Log ("Download done");
				}
				DownloadHandlerTexture textureHandler = (DownloadHandlerTexture)request.downloadHandler;
			while (!textureHandler.isDone) {
				yield return null;
			}
				if (textureHandler.isDone) {
					Debug.Log ("download handler is done");
				}
			
			//readyImages.Add(new ImageForVoting(UserInfo.userId,"http://pick-apic.com/" + entry.image_url,UserInfo.contestOfWeek.contest_id,entry.description,textureHandler.texture));
			ui.AddImage (new ImageForVoting(entry.user_id,entry.image_id,"http://pick-apic.com/" + entry.image_url,ContestInfo.GetContestID(),entry.description,textureHandler.texture));

		}


	}


	protected override void EntriesPressed ()
	{
		//TODO RefreshGUI ();
	}


}
