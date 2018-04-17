using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EntriesUI : MainScreensUI {
	private const int MAX_NUM_PICS = 30;//the maximum number of images this class will pull from the server per call
	private const int PREFAB_WIDTH = 1000;//pixels wide

	private List<ImageForVoting> images;
	public Text themeText;
	public InputField search;
	public Transform contentBox;
	public GameObject panelPrefab;
	public VotePopupValues votePopup;
	public ReportPopupValues reportPopup;

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

	public void RemoveFromList(ImageForVoting removeThis){
		VotableEntryPrefabValues values = removeThis.entryUI;
		if (values != null) {
			values.gameObject.transform.SetParent (null);
		}

	}

	public void AddImage(ImageForVoting entry, ImageEntryConnector c){
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
		//entry.ConnectToImageEntryConnector (c);
		c.SetPrefabValues(entry.entryUI);
		c.ActivateListeners ();
		panelToAdd.transform.SetParent (contentBox);
	}

	//todo maybe make it so that there's no decimal places
	private Vector2 adjustDimensions(Vector2 currentDimensions, float newWidth){
		float width = currentDimensions.x;
		float height = currentDimensions.y;
		float newHeight = (newWidth * height) / width;

		return new Vector2 (newWidth, newHeight);
	}

	public void ShowVotePopup(bool b){
		votePopup.gameObject.SetActive (b);
	}

	public void ShowReportPopup(bool b){
		reportPopup.gameObject.SetActive (b);
	}























}
