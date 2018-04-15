using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyPrefabValues : MonoBehaviour {

	public Text trophyCaption;

	public void SetTrophyCaption(string caption){
		this.trophyCaption.text = caption;
	}
}
