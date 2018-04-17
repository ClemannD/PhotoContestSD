using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//help connect listeners from entry to controller
public class ImageEntryConnector{
	public ImageForVoting entry;
	public EntriesController controller;
	public VotableEntryPrefabValues values;

	public ImageEntryConnector(ImageForVoting entry, EntriesController controller){
		this.entry = entry;
		this.controller = controller;
	}

	public void SetPrefabValues(VotableEntryPrefabValues values){
		this.values = values;
	}

	public void ActivateListeners(){
		if (values != null) {
			values.vote.onClick.AddListener (VotePressed);
			values.report.onClick.AddListener (ReportPressed);
		}
	}

	public void VotePressed(){
		controller.Vote (entry);
	}

	public void ReportPressed(){
		controller.Report (entry);
	}


}