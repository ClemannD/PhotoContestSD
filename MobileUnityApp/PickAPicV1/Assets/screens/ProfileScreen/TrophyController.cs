using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NetworkAPI.RetrieveUserResponse userStuff = NetworkAPI.DoRetrieveUserRequest (UserInfo.GetUserId (),UserInfo.GetUserPassword());
		//stuff TODO
	}
	

}
