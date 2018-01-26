using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompeteController : MainScreensController {
	public CompeteUI ui;

	void Start(){
		AddMainListeners (ui);
		ui.saveButton.onClick.AddListener (SavePressed);
		ui.uploadSelectButton.onClick.AddListener (uploadSelectPressed);

	}
		

	private void RefreshGUI(){

	}

	private void SavePressed(){

	}

	private void uploadSelectPressed(){

	}


	protected override void CompetePressed ()
	{
		RefreshGUI ();
	}



}
