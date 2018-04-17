using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

//TODO 
public class ImageAddingHelper{
	IImageAdder imageAdder;
	MonoBehaviour forCoroutines;

	public ImageAddingHelper(IImageAdder imageAdder){
		this.imageAdder = imageAdder;
		this.forCoroutines = imageAdder.GetMyMonoBehavior ();
	}

	/// <summary>
	/// Takes the ImageEntry argument object and sets the texture (i.e. image) belonging to it. It then adds it to the screen.
	/// </summary>
	/// <returns>It's a coroutine</returns>
	/// <param name="entry">Entry.</param>

	public IEnumerator DownloadAndSetImages(List<IServerImage> listOfImages){
		foreach (IServerImage image in listOfImages) {
			UnityWebRequest request = UnityWebRequestTexture.GetTexture ("http://pick-apic.com/" + image.GetServerURL());Debug.Log ("the url is " + image.GetServerURL());
			request.SendWebRequest ();

			while (!request.isDone) {
				yield return null;
			}

			if (request.isDone) {
				Debug.Log ("Download done");
			}

			DownloadHandlerTexture textureHandler = (DownloadHandlerTexture)request.downloadHandler;
			//while (!textureHandler.isDone) {
			//	yield return null;
			//}



			image.SetTexture (textureHandler.texture);


			imageAdder.AddImage (image);

			//File.WriteAllBytes ("C:\\PicsStuff\\whatever.JPG", textureHandler.texture.EncodeToJPG());
		}
	}

	public void DownloadAndDisplayImage(IServerImage image){
		List<IServerImage> singleImage =  new List<IServerImage>();
		singleImage.Add(image);
		forCoroutines.StartCoroutine (DownloadAndSetImages(singleImage));
	}

	public void DownloadAndDisplayImages(List<IServerImage> listOfImages){
		forCoroutines.StartCoroutine (DownloadAndSetImages(listOfImages));
	}







}
