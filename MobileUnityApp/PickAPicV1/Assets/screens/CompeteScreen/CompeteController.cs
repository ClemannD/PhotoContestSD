using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompeteController : NormalUserScreensController {
	public CompeteUI ui;

	void Start(){
		AddListeners (ui);
		ui.saveButton.onClick.AddListener (SavePressed);
		ui.uploadSelectButton.onClick.AddListener (uploadSelectPressed);

	}
		

	private void RefreshGUI(){

	}

	private void SavePressed(){

	}

	private void uploadSelectPressed(){

	}


	public override void CompetePressed ()
	{
		RefreshGUI ();
	}



}
