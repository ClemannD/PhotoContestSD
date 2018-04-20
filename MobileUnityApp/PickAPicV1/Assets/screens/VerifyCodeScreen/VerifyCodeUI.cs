using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyCodeUI : MonoBehaviour, IUsesGeneralPopup {

	public Button later;
	public Button submit;
	public InputField code;

	public PopupValues popupValues;

	public string GetCode(){
		return code.text;
	}

	public PopupValues GetPopupValues(){
		return popupValues;
	}
}
