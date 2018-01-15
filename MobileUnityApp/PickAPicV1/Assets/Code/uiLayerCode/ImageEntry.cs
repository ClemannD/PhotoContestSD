using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageEntry{
	private int userId;
	private string imageURL;
	private string weekTheme;
	private string contestId;
	private string description;



	//What do i do for the image???
	public Text authorText;
	public Text authorCaption;//need this in GUI dont forget

	public ImageEntry(/*???????*/){
		
	}

	public void SetAuthorText(string author){
		this.authorText.text = author;
	}

	public void SetAuthorCaption(string caption){
		this.authorCaption.text = caption;
	}


}
