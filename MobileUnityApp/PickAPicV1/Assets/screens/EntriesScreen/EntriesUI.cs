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
		entry.AttachUI (singleEntry);
		//singleEntry.entryPic.SetNativeSize ();
		panelToAdd.transform.SetParent (contentBox);
	}





















}
