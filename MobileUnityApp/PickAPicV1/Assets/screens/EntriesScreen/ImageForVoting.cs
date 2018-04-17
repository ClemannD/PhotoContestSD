using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for a single entry in the scrolling list of entries
/// </summary>
public class ImageForVoting : ImageEntry {
	

	public ImageForVoting(int userId, int imageId, string imageURL,int contestId, string description, string authorInfo, int votes, bool flagged):base(userId, imageId, imageURL, contestId, description, authorInfo, votes,flagged){

	}


	public ImageForVoting(NetworkAPI.imageInfo info):base(info.user_id,info.image_id,info.image_url,info.contest_id,info.description,info.username,info.votes,((info.isFlagged == 1) ? true : false)){

	}

	//public VoteableEntry entryUI;
	public VotableEntryPrefabValues entryUI;

	//public void AttachUI(VoteableEntry ui){
	//	entryUI = ui;
	//	entryUI.voteButton.onClick.AddListener (VotePressed);
	//	entryUI.reportButton.onClick.AddListener (ReportThis);
	//	entryUI.SetImage (entryImage);
	//	entryUI.SetDescription (description);
	//	entryUI.SetAuthorInfo (authorInfo);
	//}

	public void AttachUI(VotableEntryPrefabValues ui){
		entryUI = ui;
//		entryUI.vote.onClick.AddListener (VotePressed);
//		entryUI.report.onClick.AddListener (ReportThis);
		entryUI.SetImageTexture (entryImage);
		entryUI.SetDescription (description);
		entryUI.SetAuthorInfo (username);
		entryUI.SetVotes (votes);
	
	}




		/*

	//TODO move these to controller
	public void VotePressed(){
		
	}

	public void ReportPressed(){
		entryUI.report.interactable = false;
		//TODO!!!!!!!!!!!!
		Debug.Log ("report button pressed");
	}

	*/
}
