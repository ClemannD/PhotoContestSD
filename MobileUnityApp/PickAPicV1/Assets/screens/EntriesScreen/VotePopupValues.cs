using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VotePopupValues : MonoBehaviour {

	public Button ok;
	public Text message;
	//public EntriesController controller;

	public void SetMessage(string m){
		this.message.text = m;
	}


}
