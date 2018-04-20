using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestEntriesUI : MonoBehaviour {
	private const int MAX_NUM_PICS = 30;//the maximum number of images this class will pull from the server per call
	private static int PREFAB_WIDTH = DimensionValues.IMAGE_DISPLAY_WIDTH;//pixels wide

	private List<ImageForVoting> images;
	public Text themeText;
	public Transform contentBox;
	public GameObject panelPrefab;

	public Button login;
	public Button register;


	void Awake(){
		images = new List<ImageForVoting> ();
	}

	void Start(){
		themeText.text += ContestInfo.GetWeekTheme();
	}

	public void SetTheme(string themeText){
		this.themeText.text += themeText;
	}



	public void RemoveFromList(ImageForVoting removeThis){
		VotableEntryPrefabValues values = removeThis.entryUI;
		if (values != null) {
			values.gameObject.transform.SetParent (null);
		}

	}

	public void AddImage(ImageForVoting entry){
		Debug.Log ("adding pic");
		//images.Add (entry);
		GameObject panelToAdd = GameObject.Instantiate(panelPrefab);
		VotableEntryPrefabValues singleEntryPrefab = panelToAdd.GetComponent<VotableEntryPrefabValues> ();

		Texture photoTexture = entry.GetImageTexture ();
		Vector2 currentImageDimensions = new Vector2 (photoTexture.width, photoTexture.height);
		currentImageDimensions = adjustDimensions (currentImageDimensions,PREFAB_WIDTH);
		singleEntryPrefab.AdjustRawImageDimensions (currentImageDimensions);
		singleEntryPrefab.AdjustPrefabDimensions (currentImageDimensions.x, currentImageDimensions.y + singleEntryPrefab.GetTextPanelHeight ());
		entry.AttachUI (singleEntryPrefab);
		panelToAdd.transform.SetParent (contentBox);
	}

	//todo maybe make it so that there's no decimal places
	private Vector2 adjustDimensions(Vector2 currentDimensions, float newWidth){
		float width = currentDimensions.x;
		float height = currentDimensions.y;
		float newHeight = (newWidth * height) / width;

		return new Vector2 (newWidth, newHeight);
	}



	public void RemoveImage(ImageForVoting entry){
		GameObject.Destroy (entry.entryUI.gameObject);
	}



}
