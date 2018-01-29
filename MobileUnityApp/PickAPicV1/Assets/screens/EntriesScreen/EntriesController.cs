using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntriesController:MainScreensController{

	public static EntriesUI ui;


	void Start(){
		AddMainListeners (ui);
	}


	public void RefreshGUI(){
		//TODO something to fill up stuff
		//some api that will get me the images in a list.
	}

	protected override void EntriesPressed ()
	{
		RefreshGUI ();
	}

}
