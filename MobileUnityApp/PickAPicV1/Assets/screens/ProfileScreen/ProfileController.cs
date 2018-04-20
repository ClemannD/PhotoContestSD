using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileController : MainScreensController {
	public ProfileUI ui;
	private DeletePopupController deletePopupControl;


	// Use this for initialization
	void Start () {
		AddListeners (ui);
		ui.changePasswordButton.onClick.AddListener (ChangePasswordListener);
		ui.myPicturesButton.onClick.AddListener (MyPicturesListener);
		ui.deleteProfileButton.onClick.AddListener (DeleteProfileListener);
		ui.changeEmailButton.onClick.AddListener (ChangeEmailListener);
	}

	public void ChangePasswordListener(){
		SceneTransitions.NextScene (SceneIndices.CHANGE_PASSWORD);
	}

	public void MyPicturesListener(){
		SceneTransitions.NextScene (SceneIndices.MY_PICTURES);

	}

	public void DeleteProfileListener(){
		
		deletePopupControl = new DeletePopupController (ui);
		deletePopupControl.Show ();
	}

	public void ChangeEmailListener(){
		SceneTransitions.NextScene (SceneIndices.CHANGE_EMAIL);
	}

	public class DeletePopupController{
		DeleteProfilePopupValues values;
		ProfileUI ui;
		GeneralPopupController generalPopupControl;

		public DeletePopupController(ProfileUI ui){
			this.values = ui.deletePopupValues;
			this.ui = ui;
		}

		public void Show(){
			ui.ShowDeletePopup (false);
			values.confirmDelete.onClick.RemoveAllListeners ();
			values.cancel.onClick.RemoveAllListeners ();
			values.confirmDelete.onClick.AddListener (ConfirmDelete);
			values.cancel.onClick.AddListener (Cancel);
			ui.ShowDeletePopup (true);
		}


		public void ConfirmDelete(){
			//go to guest screen
			//delete UserInfo stuff
			NetworkAPI.DeleteUserResponse response = NetworkAPI.DeleteUser(UserInfo.GetUserId(),UserInfo.GetUserPassword());
			if (response.error.Length == 0) {
				UserInfo.ClearUserData ();
				SceneTransitions.NextScene (SceneIndices.GUEST_ENTRIES);
			} else {
				generalPopupControl = new GeneralPopupController (ui);
				generalPopupControl.SetMessage ("error");
				ui.ShowDeletePopup (false);
				generalPopupControl.Show ();
			}
		}

		public void Cancel(){
			ui.ShowDeletePopup (false);
		}

	}
}
