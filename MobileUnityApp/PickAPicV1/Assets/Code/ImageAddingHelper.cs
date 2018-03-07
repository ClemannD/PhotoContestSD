using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//TODO 
public class ImageAddingHelper{
	IImageAdder imageAdder;
	MonoBehaviour forCoroutines;

	public ImageAddingHelper(IImageAdder imageAdder){
		this.imageAdder = imageAdder;
		this.forCoroutines = imageAdder.GetMyMonoBehavior ();
	}

	public IEnumerator DonwloadAndAddContestImages(int contestID){
		NetworkAPI.RetrieveAllImagesResponse response = NetworkAPI.RetrieveImages(contestID);
		List<NetworkAPI.imageInfo> listOfEntries = response.allImages;


		NetworkAPI.RetrieveAllContestsResponse response2 = NetworkAPI.RetrieveAllContests(5,"donothackplz");
		List<NetworkAPI.contestInfo> contests = response2.allContests;
		string contestTheme = "";
		foreach (var item in contests) {
			if (item.contest_id == contestID) {
				contestTheme = item.category;
			}
		}

		foreach (NetworkAPI.imageInfo entry in listOfEntries) {
			UnityWebRequest request = UnityWebRequestTexture.GetTexture ("http://pick-apic.com/" + entry.image_url);
			request.SendWebRequest ();

			while (!request.isDone) {
				yield return null;
			}

			if (!request.isDone) {
				Debug.Log ("Download done");
			}

			DownloadHandlerTexture textureHandler = (DownloadHandlerTexture)request.downloadHandler;
			while (!textureHandler.isDone) {
				yield return null;
			}

			imageAdder.AddImage(new ImageEntry(entry.user_id,entry.image_id,entry.image_url,contestTheme,contestID,entry.description,textureHandler.texture));
		}
	}

	public void GetContestImagesCoroutine(int contestID){
		forCoroutines.StartCoroutine (DonwloadAndAddContestImages(contestID));
	}





}
