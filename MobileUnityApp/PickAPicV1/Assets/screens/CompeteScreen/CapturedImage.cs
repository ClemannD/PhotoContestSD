using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedImage{
	public int userId;
	public int contestId;
	public string description;
	public string username;
	public Texture2D texture;
	private FileSelectController controller;

	//TODO some method that helps adjust the size

	public CapturedImage(int userId, string username, int contestId, Texture2D texture){
		this.controller = controller;
		this.username = username;
		this.userId = userId;
		this.contestId = contestId;
		this.texture = texture;
	}

	public void  SetDescription(string description){
		this.description = description;
	}

}
