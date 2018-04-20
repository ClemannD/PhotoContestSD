using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EntriesController:MainScreensController, IImageAdder{
	public EntriesUI ui;
	private List<ImageEntryConnector> connectorLists;
	private PopupControl popupControl;
	private ReportPopupControl reportPopupControl;

	void Start(){
		AddListeners (ui);
		connectorLists = new List<ImageEntryConnector> ();
		RefreshPics ();
	}
		

	public void RefreshPics(){
		ImageAddingHelper addEntries = new ImageAddingHelper (this);
		ContestInfo.SetCurrentWeekData ();
		ui.SetTheme (ContestInfo.GetWeekTheme ());
		int contestId = ContestInfo.GetContestID();
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
		popupControl = new EntriesController.PopupControl (ui);

		NetworkAPI.VoteResponse response = NetworkAPI.SendVote(UserInfo.GetUserId(),UserInfo.GetUserPassword(),entry.GetImageId());
		if (response.error.Length == 0) {
			
			popupControl.SetMessage ("Vote sent");

		} else {
			//TODO ui message on whats wrong
			popupControl.SetMessage(response.error);
		}

		popupControl.Show ();
		//TODO have some dialogue to confirm the button press.

		Debug.Log ("vote button was pressed");
		//todo send the vote command to the ui, the ui then figures out what to do
	}

	public void Report(ImageForVoting entry){
		reportPopupControl = new ReportPopupControl (ui,entry);
		reportPopupControl.Show ();
	}



	private class PopupControl
	{
		
		EntriesUI ui;
		private string pendingMessage;

		public PopupControl(EntriesUI ui, string message){
			this.ui = ui;
			this.pendingMessage = message;
		}

		public PopupControl(EntriesUI ui){
			this.ui = ui;
			this.pendingMessage = "";
		}

		public void TappedOk(){
			ui.ShowPopup (false);
		}

		public void SetMessage(string message){
			this.pendingMessage = message;
		}

		public void Show(){
			//ui.ShowReportPopup (false);
			ui.ShowPopup (false);
			ui.popup.ok.onClick.RemoveAllListeners();
			ui.popup.ok.onClick.AddListener(TappedOk);
			ui.popup.SetMessage (pendingMessage);
			ui.ShowPopup (true);
		}


			
	}

	private class ReportPopupControl
	{
		
		private EntriesUI ui;
		private ImageForVoting entry;
		private PopupControl generalPopup;

		public ReportPopupControl(EntriesUI ui, ImageForVoting entry){
			this.ui = ui;
			this.entry = entry;
		}


		public void Show(){
			//ui.ShowPopup (false);
			ui.ShowReportPopup (false);
			this.ui.reportPopup.cancel.onClick.RemoveAllListeners();
			this.ui.reportPopup.yes.onClick.RemoveAllListeners();
			this.ui.reportPopup.cancel.onClick.AddListener(CancelPressed);
			this.ui.reportPopup.yes.onClick.AddListener(YesPressed);
			ui.reportPopup.SetMessage("Are you sure you want to report this photo by " + entry.GetUsername() + "?");
			ui.ShowReportPopup (true);
		}

		public void CancelPressed(){
			ui.ShowReportPopup (false);
		}

		public void YesPressed(){
			NetworkAPI.FlagResponse response = NetworkAPI.FlagImage (UserInfo.GetUserId (), UserInfo.GetUserPassword (), entry.GetImageId (), 0);
			//api stuff
			//TODO
			if (response.error.Length == 0) {
				//use the ui to remove the thing TODO
				ui.RemoveImage(entry);
				generalPopup = new PopupControl (ui);
				generalPopup.SetMessage ("Image reported.");
				ui.ShowReportPopup (false);
				generalPopup.Show ();
			} else {
				
				//ui.ShowPopup (false);
				generalPopup = new PopupControl (ui);
				generalPopup.SetMessage ("Could not report image");
				ui.ShowReportPopup (false);
				generalPopup.Show ();
			}

		}
	}

	//protected override void EntriesPressed ()
	//{
		//TODO RefreshGUI ();
	//}




}
