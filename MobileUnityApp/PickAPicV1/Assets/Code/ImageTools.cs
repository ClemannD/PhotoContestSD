using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class ImageTools : MonoBehaviour {



		
	//////////////
	/// 
	/// 
	/// 


	private static IEnumerator DownloadAndSetPhoto(ImageEntry entry, B done){
		Debug.Log ("download starting");
		UnityWebRequest request = UnityWebRequestTexture.GetTexture ("http://pick-apic.com/" + entry.GetUrl());
			request.SendWebRequest ();
			Debug.Log ("here we go");
			while (!request.isDone) {
				yield return null;
			}
			
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

			entry.SetTexture(textureHandler.texture);
			done.SetValue (true);
	}

	public static void DownloadAndSetPhoto(ImageEntry entry,MonoBehaviour m){
		B done = new B (false);
		m.StartCoroutine (DownloadAndSetPhoto(entry,done));
		while (!done.GetValue()) {
			Thread.Sleep (1000);
			Debug.Log ("not done.....");
		}
	}


	private class B{
		bool value;
		public B(bool value){
			this.value = value;
		}

		public bool GetValue(){
			return this.value;
		}

		public void SetValue(bool setTo){
			this.value = setTo;
		}
	}


	 /// <summary>
	/// Retrieves the this week contest photos. Puts them in the provided list. Run this as a coroutine!
	/// </summary>
	/// <returns>The this week contest photos.</returns>
	/// <param name="contestID">Contest I.</param>
	/// <param name="listToFill">List to fill.</param>
	/*
	public static IEnumerator RetrieveThisWeekContestPhotos(int contestID,List<ImageForVoting> listToFill){
		NetworkAPI.RetrieveAllImagesResponse response = NetworkAPI.RetrieveImages (contestID);
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

			listToFill.Add (new ImageForVoting(UserInfo.GetUserId(),entry.image_id,"http://pick-apic.com/" + entry.image_url,ContestInfo.GetContestID(),entry.description,textureHandler.texture));
		}
	} 
	  
	 */



}
