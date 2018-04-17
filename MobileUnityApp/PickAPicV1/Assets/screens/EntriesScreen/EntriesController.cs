using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EntriesController:MainScreensController, IImageAdder{
	public EntriesUI ui;
	private List<ImageEntryConnector> connectorLists;
	private VotePopupControl votePopupControl;

	void Start(){
		AddListeners (ui);
		connectorLists = new List<ImageEntryConnector> ();
		RefreshPics ();
	}
		

	public void RefreshPics(){
		ImageAddingHelper addEntries = new ImageAddingHelper (this);
		int contestId = NetworkAPI.GetCurrentContestInfo ().contest_id;
		List<NetworkAPI.imageInfo> entries = NetworkAPI.RetrieveImages(contestId).allImages;
		List<IServerImage> imagesToDisplay = new List<IServerImage> ();
		foreach (NetworkAPI.imageInfo item in entries) {
			if (item.isFlagged == 1) {
				continue;
			}
			ImageForVoting voteable = new ImageForVoting (item);

			imagesToDisplay.Add (voteable);
		}

		addEntries.DownloadAndDisplayImages (imagesToDisplay);

	}

	public void AddImage(IServerImage entry){
		ImageEntryConnector c = new ImageEntryConnector ((ImageForVoting)entry, this);
		connectorLists.Add (c);
		ui.AddImage((ImageForVoting)entry,c);
	}


	public MonoBehaviour GetMyMonoBehavior(){
		return this;
	}


	public void Vote(ImageForVoting entry){
		votePopupControl = new EntriesController.VotePopupControl (ui);

		NetworkAPI.VoteResponse response = NetworkAPI.SendVote(UserInfo.GetUserId(),UserInfo.GetUserPassword(),entry.GetImageId());
		if (response.error.Length == 0) {
			
			votePopupControl.SetMessage ("Vote sent");

		} else {
			//TODO ui message on whats wrong
			votePopupControl.SetMessage(response.error);
		}

		votePopupControl.Show ();
		//TODO have some dialogue to confirm the button press.

		Debug.Log ("vote button was pressed");
		//todo send the vote command to the ui, the ui then figures out what to do
	}

	public void Report(ImageForVoting entry){
		Debug.Log ("report this!!!!");

	}


	private class VotePopupControl
	{
		
		EntriesUI ui;

		public VotePopupControl(EntriesUI ui){
			this.ui = ui;
			try {
				ui.votePopup.ok.onClick.AddListener(TappedOk);
			} catch (System.Exception ex) {
				
			}

		}

		public void TappedOk(){
			ui.ShowVotePopup (false);
		}

		public void Show(){
			ui.ShowVotePopup (true);
		}

		public void SetMessage(string message){
			ui.votePopup.SetMessage (message);
		}
			

	}

	private class ReportPopupControl
	{
		private ReportPopupValues values;
		private EntriesUI ui;

		public ReportPopupControl(EntriesUI ui){
			this.ui = ui;
		}

		public void Show(){
			ui.ShowReportPopup (true);
		}

		public void CancelPressed(){
			ui.ShowReportPopup (false);
		}

		public void YesPressed(){
			//api stuff
			//TODO

			ui.ShowReportPopup (false);
		}
	}

	//protected override void EntriesPressed ()
	//{
		//TODO RefreshGUI ();
	//}




}
