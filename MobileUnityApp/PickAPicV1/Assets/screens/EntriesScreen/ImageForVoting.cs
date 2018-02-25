using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for a single entry in the scrolling list of entries
/// </summary>
public class ImageForVoting : ImageEntry {

	public ImageForVoting(int userId, int imageId, string imageURL,int contestId, string description):base(userId, imageId, imageURL, ContestInfo.GetWeekTheme(),contestId, description){

	}

	public ImageForVoting(int userId, int imageId, string imageURL,int contestId, string description, Texture t):base(userId, imageId, imageURL, ContestInfo.GetWeekTheme(),contestId, description,t){

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

	public void RefreshImage(){
		entryUI.SetImage (entryImage);
	}
		

	//TODO
	public void VotePressed(){
		//have an if statement here to check vote status. if not voted on this, vote. otherwise, remove vote.
		//need different state animations
		NetworkAPI.VoteResponse response = NetworkAPI.SendVote(UserInfo.GetUserId(),UserInfo.GetUserPassword(),imageId);
		if (response.error.Length > 0) {
			Debug.Log (response.error);
			MessageForUser.OutputMessage ("Error!!");
		}
		//TODO have some dialogue to confirm the button press.
		entryUI.voteButton.interactable = false;//TODO what if t
		Debug.Log ("vote button was pressed");
	}

	public void ReportPressed(){
		Debug.Log ("report button pressed");
	}


}
