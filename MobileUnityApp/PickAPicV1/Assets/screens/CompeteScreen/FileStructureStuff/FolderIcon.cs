using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderIcon {

	public string folderPath;
	//public string folderName;
	public FileSelectController controller;

	public FolderIcon(string folderPath, FileSelectController controller){
		this.folderPath = folderPath;
		this.controller = controller;
		//maybe do path as well TODO
	}

	public void AttatchGUI(EnterFolderPrefabValues prefabValues){
		prefabValues.folderButton.onClick.AddListener (FolderSelected);
		prefabValues.folderName.text = ShortFileName(this.folderPath);
		//TODO prefabValues.folderPic.texture = ???
	}

	public void FolderSelected(){
		controller.FolderClicked (this);
	}

	private string ShortFileName(string filepath){
		char[] slash = new char[1];
		slash [0] = '/';

		return filepath.Split (slash) [slash.Length - 1];
	}
}
