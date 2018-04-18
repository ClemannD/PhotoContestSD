using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCamera : MonoBehaviour {

	//References: 
	//https://answers.unity.com/questions/550729/how-to-access-device-iphoneandroid-native-camera.html
	//https://docs.unity3d.com/ScriptReference/WebCamTexture-ctor.html
	//https://stackoverflow.com/questions/24496438/can-i-take-a-photo-in-unity-using-the-devices-camera

	public RawImage screen;
	public Button switchCam;
	public Button takePic;
	public Button exitCam;
	public Texture2D storeImage;

	private WebCamTexture cam;
	private WebCamDevice[] cameraOptions;
	private string front;
	private string back;
	public CompeteController controller;

	private bool frontOn;

	// Use this for initialization
	void Awake () {
		switchCam.onClick.AddListener (SwitchCam);

		takePic.onClick.AddListener (TakePic);
		exitCam.onClick.AddListener (ExitCam);
	}

	public void AutoFindCams(){
		cameraOptions = WebCamTexture.devices;
		Debug.Log("This gadget seems to have " + cameraOptions.Length);
		for (int i = 0; i < cameraOptions.Length; i++) {
			WebCamDevice device = cameraOptions[i];
			if(device.isFrontFacing){
				front = device.name;
			}else{
				back = device.name;
			}
		}
		if (cameraOptions.Length == 1) {
			switchCam.interactable = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="frontFaceName">name for the front facing camera</param>
	/// <param name="backName">name for the camera on the back of the phone</param>
	public void OpenCam(string frontFaceName, string backName){
		if (cam != null) {
			cam.Stop ();
		}
		this.front = frontFaceName;
		this.back = backName;



		this.frontOn = true;
		cam = new WebCamTexture (front);
		
		screen.gameObject.SetActive (true);
		cam.Play ();
	}
		

	public void SwitchCam(){
		if (cam == null) {
			return;
		}
		cam.Stop ();
		if (frontOn) {
			cam = new WebCamTexture (back);
			frontOn = false;
		} else {
			cam = new WebCamTexture (front);
			frontOn = true;
		}
		cam.Play ();
		Debug.Log ("it is " + cam.width + " by " + cam.height);
	}

	public void ExitCam(){
		if (cam != null) {
			cam.Stop ();
		}
		screen.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		screen.texture = cam;
	}

	public void TakePic(){
		cam.Pause ();
		Texture2D photo = null;
		StartCoroutine (Capture (photo));
		photo = new Texture2D (cam.width, cam.height);
		photo.SetPixels (cam.GetPixels ());
		photo.Apply ();
		//call method to send photo
		controller.SetPicFromCamera(photo);
		ExitCam ();

	}

	public void SetAllButtonUsability(bool b){
		exitCam.interactable = b;
		switchCam.interactable = b;
		takePic.interactable = b;
	}

	public IEnumerator Capture(Texture2D photo){
		yield return new WaitForEndOfFrame ();
		//photo = new Texture2D (cam.width, cam.height);
		//photo.SetPixels (cam.GetPixels ());
		//photo.Apply ();
	}

	public void AdjustDimensions(float width, float height){

	}
}
