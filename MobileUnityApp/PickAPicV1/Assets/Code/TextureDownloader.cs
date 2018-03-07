using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TextureDownloader{
	IServerImage image;
	MonoBehaviour forCoroutines;

	/// <summary>
	/// Initializes a new instance of the <see cref="TextureDownloader"/> class.
	/// </summary>
	/// <param name="image">Image you wish to download</param>
	/// <param name="m">Monobehavior object, preferably the class calling this constructor.</param>
	public TextureDownloader(IServerImage image, MonoBehaviour m){
		this.image = image;
		this.forCoroutines = m;
	}

	/// <summary>
	/// Gets the picture from the server and sets it to the texture
	/// </summary>
	public void DownloadImage(){
		forCoroutines.StartCoroutine (DownloadAndSet ());
	}

	private IEnumerator DownloadAndSet(){


		UnityWebRequest request = UnityWebRequestTexture.GetTexture ("http://pick-apic.com/" + image.GetServerURL());
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


		
		image.SetTexture (textureHandler.texture);

	}


}
