using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageTools : MonoBehaviour {
	/*
	public static Texture GetImageFromServer(string url){
		UnityWebRequest request = UnityWebRequestTexture.GetTexture ("http://pick-apic.com/" + url);
		request.SendWebRequest ();

		if (!request.isDone) {
			Debug.Log ("look " + request.downloadProgress);
		}
		
			
		DownloadHandlerTexture textureHandler = (DownloadHandlerTexture)request.downloadHandler;
		if (!textureHandler.isDone) {
			Debug.Log ("ugh");
		}
		

		return textureHandler.texture;
	}*/


	public static IEnumerator GetImageFromServer(Texture texture){
		UnityWebRequest request = UnityWebRequestTexture.GetTexture ("http://pick-apic.com/");
		request.SendWebRequest ();
		while (!request.isDone) {
			yield return null;
		}
		DownloadHandlerTexture textureHandler = (DownloadHandlerTexture)request.downloadHandler;
		texture = textureHandler.texture;
	}
	

}
