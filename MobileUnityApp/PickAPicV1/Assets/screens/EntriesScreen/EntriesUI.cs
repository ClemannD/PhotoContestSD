using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntriesUI : MainScreensUI {
	private const int MAX_NUM_PICS = 30;//the maximum number of images this class will pull from the server per call

	private List<ImageForVoting> images;
	public Text themeText;
	InputField search;


	public void SetThemeText(string themeText){
		this.themeText.text = themeText;
	}

	public ImageForVoting GetEntry(int index){
		return images[index];
	}

	public string GetSearchContent(){
		return search.text;
	}

	public void RefreshGUI(){
		//some api call that will get me a list of 
	}











}
