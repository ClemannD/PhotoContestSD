using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntriesController:MainScreensController{

	EntriesUI ui;

	void Start(){
		AddMainListeners (ui);
	}


	public void RefreshGUI(){
		//TODO something to fill up stuff
	}

	protected override void EntriesPressed ()
	{
		
	}

}
