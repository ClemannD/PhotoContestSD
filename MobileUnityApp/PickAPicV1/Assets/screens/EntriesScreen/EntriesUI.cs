using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntriesUI : MonoBehaviour {

	private EntriesController controller;


	// Use this for initialization
	void Start () {
		this.controller = new EntriesController (this);
	}



}
