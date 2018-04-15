using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastContestsController : MainScreensController, IImageAdder {

	List<WeekButtonConnector> buttonConnections;
	public PastContestsUI ui;
	NetworkAPI.ContestWinners.RetrievePastContestsResponse contests;

	NetworkAPI.ContestWinners.contestInfo desiredContest;

	void Start(){
		AddListeners (ui);
		buttonConnections = new List<WeekButtonConnector> ();
		contests = NetworkAPI.ContestWinners.GetPastContestInfo ();
		foreach (NetworkAPI.ContestWinners.contestInfo item in contests.PastContests) {
			GameObject button = ui.GenerateWeekButton ();
			WeekButtonPrefabValues values = button.GetComponent<WeekButtonPrefabValues> ();
			WeekButtonConnector connection = new WeekButtonConnector (values, item, this);
			buttonConnections.Add (connection);
			ui.AddWeekButton (button);
		}




		ui.previous.onClick.AddListener (Previous);
		ui.next.onClick.AddListener (Next);
	}

	public void Next(){
		ui.NextPicPressed ();
	}

	public void Previous(){
		ui.PrevPicPressed ();
	}

	private void SetContest(int contestID){
		desiredContest.image1 = int.MinValue;desiredContest.image2 = int.MinValue;desiredContest.image3 = int.MinValue;//stop it from complaining
		foreach (var contest in contests.PastContests) {
			if (contest.contest_id == contestID) {
				desiredContest = contest;
				break;
			}
		}
	}

	private NetworkAPI.imageInfo[] GetWinners(int contestID){
		/*

		NetworkAPI.ContestWinners.contestInfo desiredContest;
		desiredContest.image1 = int.MinValue;desiredContest.image2 = int.MinValue;desiredContest.image3 = int.MinValue;//stop it from complaining
		foreach (var contest in contests.PastContests) {
			if (contest.contest_id == contestID) {
				desiredContest = contest;
				break;
			}
		}

		*/


		List<NetworkAPI.imageInfo> imagesFromContests = contests.ContestImages;
		NetworkAPI.imageInfo[] winners = new NetworkAPI.imageInfo[3];
		Debug.Log ("plz work");
		foreach (NetworkAPI.imageInfo item in imagesFromContests) {
			if (item.image_id == desiredContest.image1) {
				winners [0] = item;
				Debug.Log ("found first place" + winners[0].votes);
			} else if (item.image_id == desiredContest.image2) {
				winners [1] = item;Debug.Log ("found 2ne place" + winners[1].votes);
			} else if (item.image_id == desiredContest.image3) {
				winners [2] = item;Debug.Log ("found third place" + winners[2].votes);
			}

		}

		return winners;
	}

	public void AddImage(IServerImage entry){
		Debug.Log ("will this add the image " + ((WinningImageEntry)entry).GetVotes());
		ui.AddWinningEntry((WinningImageEntry)entry);
	}


	public void ChooseWeekToDisplay(int contestID){
		Debug.Log ("week " + contestID);
		SetContest (contestID);
		ui.SetTheme (desiredContest.category);
		ui.RemovePresentContest ();



		NetworkAPI.imageInfo[] winners = GetWinners (contestID);


		List<IServerImage> winningImages = new List<IServerImage> ();

		for (int i = 0; i < winners.Length; i++) {
			winningImages.Add (new WinningImageEntry (winners [i]));
		}
		Debug.Log ("winningImages has: " + ((WinningImageEntry)winningImages[2]).GetVotes());

		ImageAddingHelper helper = new ImageAddingHelper (this);
		helper.DownloadAndDisplayImages (winningImages);


	}



	public MonoBehaviour GetMyMonoBehavior(){
		return this;
	}

	private class WeekButtonConnector{
		private WeekButtonPrefabValues values;
		private NetworkAPI.ContestWinners.contestInfo info;
		private PastContestsController controller;

		public WeekButtonConnector(WeekButtonPrefabValues values,  NetworkAPI.ContestWinners.contestInfo info, PastContestsController controller){
			this.values = values;
			this.info = info;
			this.controller = controller;
			this.values.weekButton.onClick.AddListener(WeekSelected);

			values.SetButtonText(info.category);

		}

		public void WeekSelected(){
			controller.ChooseWeekToDisplay (info.contest_id);
		}



	}
}
