using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageEntry{
	protected int userId;
	protected string imageURL;
	protected string weekTheme;
	protected int contestId;
	protected string description;
	protected Texture entryImage;
	protected bool flagged;

	//What do i do for the image???
	protected string authorInfo;

	public ImageEntry(int userId, string imageURL, string weekTheme, int contestId, string description){
		flagged = false;
		this.userId = userId;
		this.imageURL = imageURL;
		this.weekTheme = weekTheme;
		this.contestId = contestId;
		this.description = description;
	}

	public ImageEntry(int userId, string imageURL, string weekTheme, int contestId, string description, Texture t){
		flagged = false;
		this.userId = userId;
		this.imageURL = imageURL;
		this.weekTheme = weekTheme;
		this.contestId = contestId;
		this.description = description;
		this.entryImage = t;
	}

	public Texture GetImage(){
		return this.entryImage;
	}

	public string GetUrl(){
		return imageURL;
	}

	public void SetTexture(Texture t){
		this.entryImage = t;
	}

	public void ReportThis(){
		flagged = true;
		//something else?
	}



}
