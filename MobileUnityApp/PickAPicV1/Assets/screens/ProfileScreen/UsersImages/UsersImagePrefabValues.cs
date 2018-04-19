using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsersImagePrefabValues : MonoBehaviour {
	public RawImage photo;
	//public GameObject panelRectTransform;
	public RectTransform panel;
	public Text contestInfo;
	public Text description;
	public Button delete;
	public LayoutElement layoutElement;
	public Text votes;




	/// <summary>
	/// Adjusts the dimensions of the whole prefab
	/// </summary>
	public void AdjustPrefabDimensions(float x, float y){
		layoutElement.minWidth = x;
		layoutElement.minHeight = y;
	}

	/// <summary>
	/// Gets the height of the text panel (holds the description, author info, and buttons).
	/// </summary>
	/// <returns>The text panel height.</returns>
	public float GetTextPanelHeight(){
		Debug.Log ("The height of the panel is " + panel.sizeDelta.y);
		return panel.sizeDelta.y;
	}

	public void SetVotes(int votes){
		this.votes.text += votes.ToString();
	}


	public void AdjustRawImageDimensions(Vector2 dimensions){
		photo.rectTransform.sizeDelta = dimensions;
	}

	public void SetImageTexture(Texture t){
		this.photo.texture = t;
	}

	public void SetContestInfo(string contestInfo){
		this.contestInfo.text = contestInfo;
	}

	public void SetDescription(string description){
		this.description.text = description;
	}
}
