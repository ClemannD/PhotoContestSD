using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for a single entry in the scrolling list of entries
/// </summary>
public class ImageForVoting : ImageEntry {

	public ImageForVoting(int userId, string imageURL,int contestId, string description):base(userId, imageURL, ImportantInfo.contestOfWeek.category,contestId, description){

	}

	public ImageForVoting(int userId, string imageURL,int contestId, string description, Texture t):base(userId, imageURL, ImportantInfo.contestOfWeek.category,contestId, description,t){

	}

	public SingleEntryUI entryUI;

	public void AttachUI(SingleEntryUI ui){
		entryUI = ui;
		entryUI.voteButton.onClick.AddListener (VotePressed);
		entryUI.reportButton.onClick.AddListener (ReportThis);
		entryUI.SetImage (entryImage);
		entryUI.SetDescription (description);
		entryUI.SetAuthorInfo (authorInfo);
	}

	public void VotePressed(){
		Debug.Log ("vote button was pressed");
	}

	public void ReportPressed(){
		Debug.Log ("report button pressed");
	}


}
