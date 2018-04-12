using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EntriesUI : MainScreensUI {
	private const int MAX_NUM_PICS = 30;//the maximum number of images this class will pull from the server per call

	private List<ImageForVoting> images;
	public Text themeText;
	public InputField search;
	public Transform contentBox;
	public GameObject panelPrefab;

	void Awake(){
		images = new List<ImageForVoting> ();
	}

	void Start(){
		themeText.text += " " + ContestInfo.GetWeekTheme();
	}

	public void SetThemeText(string themeText){
		this.themeText.text = themeText;
	}
		
	public string GetSearchContent(){
		return search.text;
	}

	public void AddImage(ImageForVoting entry){
		Debug.Log ("adding pic");
		images.Add (entry);
		GameObject panelToAdd = GameObject.Instantiate(panelPrefab);
		VoteableEntry singleEntry = panelToAdd.GetComponent<VoteableEntry> ();
		LayoutElement layoutElement = panelToAdd.GetComponent<LayoutElement> ();
		//Debug.Log ("the width is  " + singleEntry.entryPic.rectTransform.sizeDelta.x);
		//Vector2 newDimensions = adjustDimensions(entry.GetDimensions(),1080);
		//singleEntry.entryPic.SetNativeSize();//.rectTransform.sizeDelta = newDimensions;
		//layoutElement.minWidth = newDimensions.x;
		//layoutElement.minHeight = newDimensions.y;
		entry.AttachUI (singleEntry);
		//singleEntry.entryPic.SetNativeSize ();
		//singleEntry.entryPic.SetNativeSize ();

		panelToAdd.transform.SetParent (contentBox);
	}

	private Vector2 adjustDimensions(Vector2 currentDimensions, float newWidth){
		float width = currentDimensions.x;
		float height = currentDimensions.y;
		float newHeight = (newWidth * height) / width;

		return new Vector2 (newWidth, newHeight);


	}





















}
