using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyUI : MonoBehaviour {

	public Transform attachToThis;
	public GameObject firstPlace;
	public GameObject secondPlace;
	public GameObject thirdPlace;



	public void AddFirstPlace(string caption){
		AddTrophy (caption, firstPlace);
	}

	public void AddSecondPlace(string caption){
		AddTrophy (caption, secondPlace);
	}

	public void AddThirdPlace(string caption){
		AddTrophy (caption, thirdPlace);
	}

	private void AddTrophy(string caption, GameObject place){
		GameObject trophy = GameObject.Instantiate(place);
		TrophyPrefabValues values = trophy.GetComponent<TrophyPrefabValues>();
		values.SetTrophyCaption(caption);
		trophy.transform.SetParent (attachToThis);

	}

}
