using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPopupController{

	private PopupValues values;
	private string pendingMessage;

	public GeneralPopupController(IUsesGeneralPopup values, string message){
		this.values = values.GetPopupValues();
		this.pendingMessage = message;

	}

	public GeneralPopupController(IUsesGeneralPopup values){
		this.values = values.GetPopupValues();
		this.pendingMessage = "";
	}

	public void TappedOk(){
		values.gameObject.SetActive (false);
	}

	public void SetMessage(string message){
		this.pendingMessage = message;
	}

	public void Show(){
		//ui.ShowReportPopup (false);
		values.gameObject.SetActive(false);
		values.ok.onClick.RemoveAllListeners();
		values.ok.onClick.AddListener(TappedOk);
		values.SetMessage (pendingMessage);
		values.gameObject.SetActive (true);
	}

}
