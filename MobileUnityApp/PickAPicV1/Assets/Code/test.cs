using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Debug.Log ("first say " + deleteThisInfo.constantbla);
		deleteThisInfo.constantbla = "new string muhahaaha";
		Debug.Log ("second say " + deleteThisInfo.constantbla);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
