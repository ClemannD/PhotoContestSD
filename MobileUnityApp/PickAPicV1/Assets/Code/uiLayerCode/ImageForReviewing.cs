using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageForReviewing:ImageEntry {
	public Button reportButton;

	public ImageForReviewing(int userId, int imageId, string imageURL, string weekTheme, int contestId, string description):base(userId, imageId, imageURL, weekTheme, contestId, description){
		reportButton.onClick.AddListener (ReportThis);
	}

	public ImageForReviewing(int userId, int imageId, string imageURL, string weekTheme, int contestId, string description,Texture t):base(userId, imageId, imageURL, weekTheme, contestId, description,t){
		reportButton.onClick.AddListener (ReportThis);
	}
	

}
