using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MobileFolder {
	private string[] folderPaths;
	private string[] imageFilesPaths;

	//private string folderPath;
	/// <summary>
	/// Should be the folder that holds all the images the user might want to access.
	/// Make sure that it is correct depending on if it is android/iphone!!! 
	/// </summary>
	/// <param name="folderpath">Folderpath.</param>
	public MobileFolder(string folderPath){
		//this.folderPath = folderPath;
		this.folderPaths = Directory.GetDirectories (folderPath);
		this.imageFilesPaths = GetImageFiles (folderPath);
	}

	private string[] GetImageFiles(string path){
		string[] files = Directory.GetFiles (path);
		List<string> allowed = new List<string> ();
		for (int x = 0; x < files.Length; x++) {
			string name = files [x];
			if (AllowedType(name)) {
				allowed.Add (name);
			}
		}

		string[] returnArray = new string[allowed.Count];

		for (int f = 0; f < allowed.Count; f++) {
			returnArray [f] = allowed [f];
		}

		return returnArray;
	}

	public MobileFolder GoToFolder(string folderOfChoicePath){
		for (int f = 0; f < folderPaths.Length; f++) {
			if (folderPaths[f] == folderOfChoicePath) {
				return new MobileFolder (folderOfChoicePath);
			}
		}
		return null;
	}

	public string[] GetFilePaths(){
		return imageFilesPaths;
	}

	public string[] GetFolderPaths(){
		return folderPaths;
	}

	private bool AllowedType(string file){
		if (file.EndsWith ("jpg") || file.EndsWith ("png") || file.EndsWith ("JPG") || file.EndsWith ("PNG")) {
			return true;
		} else {
			return false;
		}
	}

}
