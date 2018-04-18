using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastContestsUI : MainScreensUI {
	public const int PLACES = 3;
	private const int PREFAB_WIDTH = 900;

	public Text theme;//get this onto the ui

	public GameObject imagePrefab;
	public GameObject weekButton;

	public GameObject firstPlaceSymbol;//prefab
	public GameObject secondPlaceSymbol;//prefab
	public GameObject thirdPlaceSymbol;//prefab
	public GameObject[] placeSymbols;


	private List<GameObject> winners;
//	private Dictionary<int,List<GameObject>> imageTable;


	public Transform attachPhotoToThis;
	public Transform attachWeekButtonToThis;
	public Transform attachTrophySymbolsToThis;

	private int place;

	public Button next;
	public Button previous;

	public GameObject trophyInfoDisplayed;



	void Awake(){
		winners = new List<GameObject>();//delete this??s
		//imageTable = new Dictionary<int, List<GameObject>> ();
		place = 0;
		placeSymbols = new GameObject[3];
		placeSymbols [0] = GameObject.Instantiate (firstPlaceSymbol);
		placeSymbols [1] = GameObject.Instantiate (secondPlaceSymbol);
		placeSymbols [2] = GameObject.Instantiate (thirdPlaceSymbol);


	}

	public void SetTheme(string theme){
		this.theme.text += theme;
	}

	public void NextPicPressed(){
		place = (place + 1) % winners.Count;
		DisplayImage (place);
	}

	public void PrevPicPressed(){
		if (place == 0) {
			place = (winners.Count - 1);
		} else {
			place--;
		}

		DisplayImage (place);
	}

	public void DisplayImage(int p){
		if (!trophyInfoDisplayed.activeInHierarchy) {
			trophyInfoDisplayed.SetActive (true);
		}

		attachPhotoToThis.DetachChildren ();
		//TODO deal with existing pics
		winners [p].transform.SetParent (attachPhotoToThis);//TODO

		TrophySymbolPrefabValues valuesToChange = trophyInfoDisplayed.GetComponent<TrophySymbolPrefabValues> ();
		TrophySymbolPrefabValues useTheseValues = placeSymbols [p].GetComponent<TrophySymbolPrefabValues> ();

		valuesToChange.SetImage (useTheseValues.GetImageSprite ());
		valuesToChange.SetLabel (useTheseValues.GetLabel ());
	

	}


	public void RemovePresentContest(){
		attachPhotoToThis.DetachChildren ();
		foreach (var item in winners) {
			GameObject.Destroy (item);
		}
		winners.Clear ();
	}



	public void AddWinningEntry(WinningImageEntry entry){

		//if(!imageTable.ContainsKey(entry.GetContestID())){
		//	imageTable.Add (entry.GetContestID(),new List<GameObject>());
		//}

		Debug.Log ("adding pic" + entry.GetVotes());
		//images.Add (entry);
		GameObject panelToAdd = GameObject.Instantiate(imagePrefab);
		WinningImagePrefabValues values = panelToAdd.GetComponent<WinningImagePrefabValues> ();

		Texture photoTexture = entry.GetImageTexture ();
		Vector2 currentImageDimensions = new Vector2 (photoTexture.width, photoTexture.height);Debug.Log ("pic is currently " + photoTexture.width + " by " + photoTexture.height);
		currentImageDimensions = adjustDimensions (currentImageDimensions,PREFAB_WIDTH);
		values.AdjustRawImageDimensions (currentImageDimensions);
		values.AdjustPrefabDimensions (currentImageDimensions.x, currentImageDimensions.y + values.GetTextPanelHeight ());
		entry.AttachUI (values);



		//winners.Add (panelToAdd);
		//List<GameObject> singleContestWinners = imageTable[entry.GetContestID()];
		//singleContestWinners.Add(panelToAdd);
		//winners = singleContestWinners;

		winners.Add(panelToAdd);
		if (winners.Count == 1) {
			DisplayImage (0);
		}

		Debug.Log ("winners size is " + winners.Count);
		//panelToAdd.transform.SetParent (attachPhotoToThis);


	}



	private Vector2 adjustDimensions(Vector2 currentDimensions, float newWidth){
		float width = currentDimensions.x;
		float height = currentDimensions.y;
		float newHeight = (newWidth * height) / width;

		return new Vector2 (newWidth, newHeight);
	}




	public void AddWeekButton(GameObject button){
		button.transform.SetParent (attachWeekButtonToThis);
	}

	public GameObject GenerateWeekButton(){
		GameObject button = GameObject.Instantiate (weekButton);
		return button;
	}







}
