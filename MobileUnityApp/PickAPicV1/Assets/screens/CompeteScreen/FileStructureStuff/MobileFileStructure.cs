using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileFileStructure : MonoBehaviour {
	public MobileFolder currentFolder;
	public Stack<MobileFolder> folderHistory;
	public string[] imagePaths;
	public Dictionary<string,string> availableFolders;

	public MobileFileStructure(string startFilePath){
		this.folderHistory = new Stack<MobileFolder> ();
		this.currentFolder = new MobileFolder (startFilePath);
		this.imagePaths = currentFolder.GetFilePaths ();

		this.availableFolders = new Dictionary<string, string> ();

		//make hash table
		FillDictionary();

	}

	private void FillDictionary(){
		availableFolders.Clear ();
		string[] folderPaths = currentFolder.GetFolderPaths ();
		for (int i = 0; i < folderPaths.Length; i++) {
			string longer = folderPaths [i];
			string shorter = ShortFileName (longer);

			availableFolders.Add (shorter, longer);
		}
	}



	private string ShortFileName(string filepath){
		char[] slash = new char[1];
		slash [0] = '/';

		return filepath.Split (slash) [slash.Length - 1];
	}

	public void EnterFolder(string folderName){
		folderHistory.Push (currentFolder);
		currentFolder = currentFolder.GoToFolder (availableFolders[folderName]);//TODO possible error? what if its not there
		FillDictionary ();
		imagePaths = currentFolder.GetFilePaths ();
	}

	public void GoBack(){
		//TODO
	}


	public string[] GetFolders(){
		string[] returnArray = new string[availableFolders.Count];
		IDictionaryEnumerator s = availableFolders.GetEnumerator ();
		int index = 0;
		while (s.MoveNext()) {
			KeyValuePair<string,string> contents = (KeyValuePair<string,string>)s.Current;
			returnArray [index] = contents.Key;
			index++;
		}
		return returnArray;
	}

	public string[] GetImageFilePaths(){
		return imagePaths;
	}




}
