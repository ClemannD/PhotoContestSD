using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserImagesUI : MainScreensUI,IUsesGeneralPopup{
	public Text userInfo;
	//public PopupValues values;
	public ConfirmDeletePopupValues confirmDeletePopupValues;
	public PopupValues generalPopupVaulues;
	public Transform attachToThis;

	public Text totalVotes;
	public Text contestsWon;
	public Text numberOfPics;

	public GameObject imageForViewingPrefab;

	public void SetTotalVotes(int number){
		totalVotes.text += number;
	}

	public void SetContestsWon(int number){
		contestsWon.text += number;
	}

	public void SetNumberOfPics(int number){
		numberOfPics.text += number;
	}

	public void RemoveImage(ImageForViewing entry){
		GameObject.Destroy (entry.values.gameObject);
	}

	public void ShowDeletePopup(bool b){
		confirmDeletePopupValues.gameObject.SetActive (b);
	}

	public void SetUserInfo(string user){
		userInfo.text = user + "'s Images";
	}

	public PopupValues GetPopupValues(){
		return generalPopupVaulues;
	}
		

	public void PlaceUserImage(UserImagesController.ImageUIConnector imageConnector){
		GameObject attachThis = GameObject.Instantiate (imageForViewingPrefab);
		ImageForViewing pic = imageConnector.image;
		UsersImagePrefabValues prefabValues = attachThis.GetComponent<UsersImagePrefabValues> ();

		Texture photoTexture = pic.GetImageTexture ();
		Vector2 imageDimensions = new Vector2 (photoTexture.width, photoTexture.height);
		imageDimensions = adjustDimensions (imageDimensions, DimensionValues.IMAGE_DISPLAY_WIDTH);
		prefabValues.AdjustRawImageDimensions (imageDimensions);
		prefabValues.AdjustPrefabDimensions (imageDimensions.x, imageDimensions.y + prefabValues.GetTextPanelHeight());

		pic.AttachUI (prefabValues);

		imageConnector.GivePrefabValues (pic.values);
		imageConnector.ActivateListener ();
		attachThis.transform.SetParent (attachToThis);


	}

	private Vector2 adjustDimensions(Vector2 currentDimensions, float newWidth){
		float width = currentDimensions.x;
		float height = currentDimensions.y;
		float newHeight = (newWidth * height) / width;

		return new Vector2 (newWidth, newHeight);
	}
}
