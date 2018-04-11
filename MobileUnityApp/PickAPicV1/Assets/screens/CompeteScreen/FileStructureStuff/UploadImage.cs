using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadImage{
	public int userId;
	public int contestId;
	public string description;
	public string url;
	public Texture2D texture;
	private FileSelectController controller;

	//TODO some method that helps adjust the size

	public UploadImage(string url, int userId, int contestId, Texture2D texture, FileSelectController controller){
		this.controller = controller;
		this.userId = userId;
		this.contestId = contestId;
		this.texture = texture;
		this.url = url;
	}




	public void SetDescription(string description){
		this.description = description;
	}

	public void AttatchToGUI(ClickImagePrefabValues prefab){
		prefab.picButton.onClick.AddListener (Selected);
		prefab.thumbnail.texture = texture;
	}


	public void Selected(){
		controller.ImageClicked (this);
	}



	//Reference : https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Complete_list_of_MIME_types
	/// <summary>
	/// for the "content type header" when uploading through html form
	/// </summary>
	/// <returns>The content type.</returns>
	public string ContentType(){
		if (url.EndsWith ("png") || url.EndsWith ("PNG")) {
			return "png";
		} else if (url.EndsWith ("JPG") || url.EndsWith ("jpg") || url.EndsWith ("JPEG") || url.EndsWith ("jpeg")) {
			return "jpeg";
		} else {
			return "????";
		}
	}






}
