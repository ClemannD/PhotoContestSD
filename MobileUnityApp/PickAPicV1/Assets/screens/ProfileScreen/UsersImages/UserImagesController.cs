using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserImagesController : MainScreensController, IImageAdder {
	public UserImagesUI ui;

	private List<ImageUIConnector> imageConnections;

	private ConfirmDeletePopupControl deletePopupControl;

	// Use this for initialization
	void Start () {
		AddListeners (ui);
		imageConnections = new List<ImageUIConnector> ();
		NetworkAPI.RetrieveUserResponse response = NetworkAPI.DoRetrieveUserRequest (UserInfo.GetUserId (), UserInfo.GetUserPassword ());

		ui.SetUserInfo (UserInfo.GetUsername ());
		ui.SetTotalVotes (response.totalVotes);
		ui.SetNumberOfPics (response.totalPictures);
		ui.SetContestsWon (response.totalContests);

		RefreshPics ();
	}

	//TODO
	public void RefreshPics(){
		ImageAddingHelper addEntries = new ImageAddingHelper (this);
		NetworkAPI.RetrieveUserImagesResponse response = NetworkAPI.GetUserImages (UserInfo.GetUserId(), UserInfo.GetUserPassword ());
		List<IServerImage> imagesToDisplay = new List<IServerImage> ();
		foreach (NetworkAPI.GetUserImagesImageInfo.imageInfo item in response.userImages) {
			if (item.isFlagged == 1) {
				continue;
			}
			ImageForViewing pic = new ImageForViewing (item);

			imagesToDisplay.Add (pic);
		}

		addEntries.DownloadAndDisplayImages (imagesToDisplay);

	}
	public MonoBehaviour GetMyMonoBehavior(){
		return this;
	}

	public void AddImage(IServerImage pic){
		ImageUIConnector imageConnect = new ImageUIConnector ((ImageForViewing)pic,this);
		ui.PlaceUserImage (imageConnect);

	}

	public void DeletePic(ImageForViewing image){
		deletePopupControl = new ConfirmDeletePopupControl (image,ui);
		deletePopupControl.Show ();
		//ui.RemoveImage (image);
		//popup must manage this
	}

	public class ImageUIConnector{
		public ImageForViewing image;
		public UserImagesController controller;
		public UsersImagePrefabValues values;

		public ImageUIConnector(ImageForViewing image, UserImagesController controller){
			this.image = image;
			this.controller = controller;
		}

		public void GivePrefabValues(UsersImagePrefabValues values){
			this.values = values;
		}

		public void ActivateListener(){
			values.delete.onClick.AddListener (DeleteThis);
		}

		public void DeleteThis(){
			controller.DeletePic (image);
		}
	}


	private class ConfirmDeletePopupControl{

		private ConfirmDeletePopupValues values;
		private GeneralPopupController generalPopupControl;
		private UserImagesUI ui;

		public ImageForViewing entry;

		public ConfirmDeletePopupControl(ImageForViewing entry, UserImagesUI ui){
			this.values = ui.confirmDeletePopupValues;
			this.entry = entry;
			this.ui = ui;
			//todo entry
		}


		public void Show(){
			//ui.ShowPopup (false);
			ui.ShowDeletePopup(false);
			values.cancelButton.onClick.RemoveAllListeners();
			values.yesButton.onClick.RemoveAllListeners();
			values.cancelButton.onClick.AddListener(CancelPressed);
			values.yesButton.onClick.AddListener(YesPressed);
			ui.ShowDeletePopup (true);
		}

		public void CancelPressed(){
			ui.ShowDeletePopup (false);
		}

		public void YesPressed(){//Delete image
			NetworkAPI.DeleteImageResponse response =  NetworkAPI.DeleteUserImage(UserInfo.GetUserId(),UserInfo.GetUserPassword(),entry.GetContestID(),entry.GetImageId());//more

			if (response.error.Length == 0) {
				//use the ui to remove the thing TODO 	
				ui.RemoveImage(entry);
				ui.ShowDeletePopup (false);
			
			} else {

				//ui.ShowPopup (false);
				generalPopupControl = new GeneralPopupController (ui);
				generalPopupControl.SetMessage ("Unable to remove image");
				ui.ShowDeletePopup (false);
				generalPopupControl.Show ();
			
			}
		}
	}
	
}
