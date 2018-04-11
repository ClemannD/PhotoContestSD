using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderIcon {

	public string folderPath;
	public string folderName;
	public FileSelectController controller;

	public FolderIcon(string name, FileSelectController controller){
		this.folderName = name;
		this.controller = controller;
		//maybe do path as well TODO
	}

	public void AttatchGUI(EnterFolderPrefabValues prefabValues){
		prefabValues.folderButton.onClick.AddListener (FolderSelected);
		prefabValues.folderName.text = this.folderName;
		//TODO prefabValues.folderPic.texture = ???
	}

	public void FolderSelected(){
		controller.FolderClicked (this);
	}
}
