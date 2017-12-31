using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class anothertest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Debug.Log ("hopefully this worked: " + deleteThisInfo.constantbla);
		deleteThisInfo.constantbla = "this has been mutated";
	}
	

}
