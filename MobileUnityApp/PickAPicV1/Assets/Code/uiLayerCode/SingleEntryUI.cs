using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SingleEntryUI : MonoBehaviour {
	public RawImage entryPic;
	public Text authorInfo;

	public Text description;

	public void SetAuthorInfo(string authorInfo){
		this.authorInfo.text = authorInfo;
	}

	public void SetImage(Texture pic){
		entryPic.texture = pic;
	}

	public void SetDescription(string description){
		this.description.text = description;
	}
}
