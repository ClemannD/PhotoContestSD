using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileFileStructure {
	private MobileFolder currentFolder;
	private Stack<MobileFolder> folderHistory;
	private string[] imagePaths;

	private List<string> folders;

	public MobileFileStructure(string startFilePath){
		this.folderHistory = new Stack<MobileFolder> ();
		this.currentFolder = new MobileFolder (startFilePath);
		this.imagePaths = currentFolder.GetFilePaths ();

		this.folders = new List<string> ();

		//make hash table
		FillFolderList();

	}

	private void FillFolderList(){
		folders.Clear ();
		string[] folderPaths = currentFolder.GetFolderPaths ();
		for (int i = 0; i < folderPaths.Length; i++) {
			folders.Add(folderPaths [i]);
		}
	}






	//use real path
	public void EnterFolder(string folderPath){
		folderHistory.Push (currentFolder);
		currentFolder = currentFolder.GoToFolder (folderPath);//TODO possible error? what if its not there
		FillFolderList();
		imagePaths = currentFolder.GetFilePaths ();
	}

	public void GoBack(){
		//TODO
	}


	public string[] GetFolders(){
		string[] returnArray = new string[folders.Count];
		for (int i = 0; i < folders.Count; i++) {
			returnArray [i] = folders [i];
		}


		return returnArray;
	}

	public string[] GetImageFilePaths(){
		return imagePaths;
	}




}
