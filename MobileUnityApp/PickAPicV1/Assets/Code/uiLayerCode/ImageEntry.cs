using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageEntry: IServerImage{
	protected int userId;
	protected string imageURL;
	protected string weekTheme;
	protected int contestId;
	protected string description;
	protected Texture entryImage;
	protected bool flagged;
	protected int imageId;
	protected int votes;

	//What do i do for the image???
	protected string authorInfo;

	public ImageEntry(int userId, int imageId, string imageURL, int contestId, string description, string authorInfo, int votes, bool flagged){
		this.flagged = flagged;
		this.userId = userId;
		this.imageURL = imageURL;
		this.weekTheme = weekTheme;
		this.contestId = contestId;
		this.description = description;
		this.imageId = imageId;
		this.authorInfo = authorInfo;
		this.votes = votes;
		this.flagged = flagged;

	}






	public int GetImageId(){
		return imageId;
	}

	public Texture GetImageTexture(){
		return this.entryImage;
	}

	public string GetServerURL(){
		return imageURL;
	}

	public void SetTexture(Texture t){
		this.entryImage = t;
	}

	/// <summary>
	/// Array holding width and height in that order
	/// </summary>
	/// <returns>The dimensions.</returns>
	public Vector2 GetDimensions(){
		//int[] arrayOfDimensions= { this.entryImage.width, this.entryImage.height };
		//return arrayOfDimensions;
		Debug.Log("width is " + this.entryImage.width);
		return new Vector2(this.entryImage.width, this.entryImage.height);
	}

	public void ReportThis(){
		flagged = true;
		//something else?
	}



}
