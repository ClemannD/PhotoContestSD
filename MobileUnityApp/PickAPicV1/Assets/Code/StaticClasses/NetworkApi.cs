using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using System.Net;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class NetworkAPI:MonoBehaviour{
	private const int RETRIES = 10;
	private const int RETRY_SLEEP = 10;
	public const string UPLOAD_URL = "http://pick-apic.com/webservices/";


	public struct InsertUserRequest{
		public string userName;
		public string fullName;
		public string email;
		public string password;
		public string birthday;
	}

	public struct InsertUserResponse{
		public int id;
		public string error;
	}

	public static InsertUserResponse InsertNewUser(string username, string fullName, string email, string password, string birthday){
		InsertUserRequest request = new InsertUserRequest ();
		request.userName = username;
		request.fullName = fullName;
		request.birthday = birthday;
		request.email = email;
		request.password = password;

		InsertUserResponse response = new InsertUserResponse();

		response = ApiCall<InsertUserRequest,InsertUserResponse> (request,response,"InsertUser.aspx");

		if (response.error == null) {
			Debug.Log ("failed call");
		}

		if (response.error.Length > 0) {
			Debug.Log (response.error);
		}
		return response;
	}


	/// /////////////



	public struct LoginUserRequest
	{
		public string username;
		public string password;
	}

	public struct LoginUserResponse
	{
		public int id;
		public string ApiKey;
		public string error;
	}

	public static LoginUserResponse DoUserLogin(string username, string password)
	{
		LoginUserRequest req = new LoginUserRequest();
		req.username = username;
		req.password = password;
		LoginUserResponse res = new LoginUserResponse();

		res = ApiCall<LoginUserRequest,LoginUserResponse>(req,res,"LoginUser.aspx");

		return res;
	}

	public struct RemoveUserRequest{
		public int user_id;
	}

	public struct RemoveUserResponse{
		public string error;
	}

	public static RemoveUserResponse DoRemoveUser(int userId){
		RemoveUserRequest removeUserRequest = new RemoveUserRequest ();
		removeUserRequest.user_id = userId;

		WebClient webClient = new WebClient ();
		string uploadJson = JsonConvert.SerializeObject(removeUserRequest);

		RemoveUserResponse removeUserResponse = new RemoveUserResponse ();


		for(int x=0;x<RETRIES;x++){

			try {
				webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
				string returnString = (string)webClient.UploadString(UPLOAD_URL + "RemoveUser.aspx","POST",uploadJson);
				removeUserResponse = JsonConvert.DeserializeObject<RemoveUserResponse>(returnString);
				break;
			} catch (Exception ex) {
				removeUserResponse.error = ex.Message;
			}
			Thread.Sleep (RETRY_SLEEP);
		}

		return removeUserResponse;
	}



	public struct InsertContestRequest{
		public int contest_id;
		public int week;
		public string category;
	}

	public struct InsertContestResponse{
		public int contest_id;
		public string error;
	}

	public InsertContestResponse DoContestRequest(int contestId, int week, string category){
		InsertContestRequest insertContestRequest = new InsertContestRequest ();
		//insertContestRequest.contest_id = contestId;
		insertContestRequest.week = week;
		insertContestRequest.category = category;


		WebClient webClient = new WebClient ();
		string uploadJson = JsonConvert.SerializeObject(insertContestRequest);

		InsertContestResponse insertContestResponse = new InsertContestResponse ();


		for(int x=0;x<RETRIES;x++){

			try {
				webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
				string returnString = (string)webClient.UploadString(UPLOAD_URL + "InsertContest.aspx","POST",uploadJson);
				insertContestResponse = JsonConvert.DeserializeObject<InsertContestResponse>(returnString);
				break;
			} catch (Exception ex) {
				insertContestResponse.error = ex.Message;
			}
			Thread.Sleep (RETRY_SLEEP);
		}

		return insertContestResponse;
	}


	public struct RetrieveUserRequest{
		public int user_id;
		public string password;
	}

	public struct RetrieveUserResponse{
		public int id;
		public string userName;
		public string fullName;
		public string bio;
		public string error;
		public int totalVotes;
		public int totalPictures;
		public int totalContests;
	}

	public static RetrieveUserResponse DoRetrieveUserRequest(int userId, string password){
		RetrieveUserRequest retrieveUserRequest = new RetrieveUserRequest();
		retrieveUserRequest.user_id = userId;
		retrieveUserRequest.password = password;

		WebClient webClient = new WebClient ();
		string uploadJson = JsonConvert.SerializeObject(retrieveUserRequest);

		RetrieveUserResponse retrieveUserResponse = new RetrieveUserResponse();

		for(int x=0;x<RETRIES;x++){

			try {
				webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
				string returnString = (string)webClient.UploadString(UPLOAD_URL + "RetrieveUser.aspx","POST",uploadJson);
				retrieveUserResponse = JsonConvert.DeserializeObject<RetrieveUserResponse>(returnString);
				break;
			} catch (Exception ex) {
				retrieveUserResponse.error = ex.Message;
			}
			Thread.Sleep (RETRY_SLEEP);
		}

		return retrieveUserResponse;
	}

	public struct RetrieveAllContestsRequest
	{
		public int adminID;
		public string adminPassword;
	}

	public struct contestInfo{
		public int contest_id;
		public string category;
		public int week;
	}

	public struct RetrieveAllContestsResponse
	{
		public int id;
		public List<contestInfo> allContests;
		public string error;
	}

	public static RetrieveAllContestsResponse RetrieveAllContests(int adminId, string adminPassword){
		RetrieveAllContestsRequest request = new RetrieveAllContestsRequest();
		request.adminID = adminId;
		request.adminPassword = adminPassword;
		RetrieveAllContestsResponse response = new RetrieveAllContestsResponse();
		response = ApiCall<RetrieveAllContestsRequest,RetrieveAllContestsResponse>(request,response,"RetrieveAllContests.aspx");
		return response;
	}
		

	private static responseStructType ApiCall<sendStructType,responseStructType>(sendStructType send, responseStructType response, string aspxFilename){
		

		WebClient webClient = new WebClient ();
		string uploadJson = JsonConvert.SerializeObject(send);


		for(int x=0;x<RETRIES;x++){

			try {
				webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
				string returnString = (string)webClient.UploadString(UPLOAD_URL + aspxFilename,"POST",uploadJson);
				Debug.Log("the returned string after the api call is: " + returnString);
				response = JsonConvert.DeserializeObject<responseStructType>(returnString);
				break;
			} catch (Exception ex) {
				Debug.Log ("something bad happened");
				Debug.Log (ex);
			}
			Thread.Sleep (RETRY_SLEEP);
		}
		return response;
	}



	private static responseStructType ApiCallUpload<sendStructType,responseStructType>(sendStructType send, responseStructType response, string aspxFilename){


		WebClient webClient = new WebClient ();

		string uploadJson = JsonConvert.SerializeObject(send);


		for(int x=0;x<RETRIES;x++){

			try {
				webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
				string returnString = (string)webClient.UploadString(UPLOAD_URL + aspxFilename,"POST",uploadJson);
				Debug.Log("the returned string after the api call is: " + returnString);
				response = JsonConvert.DeserializeObject<responseStructType>(returnString);
				break;
			} catch (Exception ex) {
				Debug.Log ("something bad happened");
				Debug.Log (ex);
			}
			Thread.Sleep (RETRY_SLEEP);
		}
		return response;
	}


	public struct RetrieveAllImagesRequest{
		public int contest_id;
	}

	public struct imageInfo{
		public int image_id;
		public string image_url;
		public string description;
		public int user_id;
		public string username;
		public int votes;
		public int isFlagged;
		public int contest_id;
	}

	public struct RetrieveAllImagesResponse{
		public int id;
		public List<imageInfo> allImages;
		public string error;
	}

	public static RetrieveAllImagesResponse RetrieveImages(int contestId){
		RetrieveAllImagesRequest request = new RetrieveAllImagesRequest ();
		request.contest_id = contestId;
		RetrieveAllImagesResponse response = new RetrieveAllImagesResponse ();

		response = ApiCall<RetrieveAllImagesRequest,RetrieveAllImagesResponse> (request, response, "RetrieveAllImages.aspx");
		return response;
	}


	public struct RetrieveCurrentContestsRequest{

	}

	public struct RetrieveCurrentContestsResponse{
		public int contest_id;
		public string category;
		public int week;
		public string error;
	}

	public static RetrieveCurrentContestsResponse GetCurrentContestInfo(){
		RetrieveCurrentContestsRequest request = new RetrieveCurrentContestsRequest ();
		RetrieveCurrentContestsResponse response = new RetrieveCurrentContestsResponse ();

		response = ApiCall<RetrieveCurrentContestsRequest,RetrieveCurrentContestsResponse> (request, response, "RetrieveCurrentContests.aspx");

		return response;
	}


	public struct VoteRequest{
		public int user_id;
		public string password;
		public int image_id;
	}

	public struct VoteResponse{
		public int id;
		public int votes;
		public string error;
	}

	public static VoteResponse SendVote(int userId, string password, int image_id){
		VoteRequest request = new VoteRequest ();
		request.user_id = userId;
		request.password = password;
		request.image_id = image_id;
		VoteResponse response = new VoteResponse ();

		response = ApiCall<VoteRequest,VoteResponse> (request, response, "Vote.aspx");
		return response;
	}

	public struct UpdatePassRequest{
		public string user_id;
		public string password;
		public string newpassword;
	}

	public struct UpdatePassResponse{
		public int id;
		public string error;
	}

	public static UpdatePassResponse NewPassword(string ID, string oldOne, string newOne){
		UpdatePassRequest request = new UpdatePassRequest ();
		request.user_id = ID;
		request.password = oldOne;
		request.newpassword = newOne;

		UpdatePassResponse response = new UpdatePassResponse ();
	
		response = ApiCall<UpdatePassRequest,UpdatePassResponse> (request, response, "UpdatePass.aspx");
		return response;
	}




	public struct RetrieveUserImagesRequest{
		public int user_id;
		public string password;
	}


	public struct RetrieveUserImagesResponse{
		public int id;
		public List<imageInfo> userInfo;
		public string error;
	}

	public RetrieveUserImagesResponse GetUserImages(int userId, string password){

		RetrieveUserImagesRequest request = new RetrieveUserImagesRequest();
		request.user_id = userId;
		request.password = password;

		RetrieveUserImagesResponse response = new RetrieveUserImagesResponse();
		response = ApiCall<RetrieveUserImagesRequest,RetrieveUserImagesResponse>(request,response,"RetrieveUserImages.aspx");
		return response;

	}



	public struct ForgotPassRequest{
		public string username;
		public string verifyCode;
		public string password;
	}

	public struct ForgotPassResponse{
		public int id;
		public string error;
	}

	public ForgotPassResponse ForgotPassword(string userName, string password, string code){
		ForgotPassRequest request = new ForgotPassRequest ();
		request.username = userName;
		request.password = password;
		request.verifyCode = code;

		ForgotPassResponse response = new ForgotPassResponse ();

		response = ApiCall<ForgotPassRequest,ForgotPassResponse> (request, response, "ForgotPass.aspx");
		return response;
	}



	public struct FlagRequest{
		public int user_id;
		public string password;
		public int image_id;
		public int flagAction;
	}

	public struct FlagResponse{
		public int id;
		public string error;
	}

	public static FlagResponse FlagImage(int userId, string password, int imageId, int flagValue){
		FlagRequest request = new FlagRequest ();
		request.user_id = userId;
		request.password = password;
		request.image_id = imageId;
		request.flagAction = flagValue;
		FlagResponse response = new FlagResponse ();

		response = ApiCall<FlagRequest,FlagResponse> (request, response, "Flag.aspx");

		return response;
	}


	public class ContestWinners{
		public struct contestInfo{
			public int contest_id;
			public string category;
			public int week;
			public int image1;
			public int image2;
			public int image3;
		}

		public struct RetrievePastContestsRequest{
		}

		public struct RetrievePastContestsResponse{
			public List<contestInfo> PastContests;
			public List<imageInfo> ContestImages;
			public string error;
		}

		public static RetrievePastContestsResponse GetPastContestInfo(){
			RetrievePastContestsRequest request = new RetrievePastContestsRequest ();
			RetrievePastContestsResponse response = new RetrievePastContestsResponse ();
			response = ApiCall<RetrievePastContestsRequest,RetrievePastContestsResponse> (request, response, "RetrievePastContests.aspx");


			return response;

		}
		

	}















	//Reference: https://docs.unity3d.com/ScriptReference/WWWForm.html
	//Reference: https://docs.unity3d.com/Manual/UnityWebRequest-SendingForm.html
	//Reference: https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Complete_list_of_MIME_types

	public struct InsertImageResponse{
		public string imgUrl;
		public string error;
	}

	public static InsertImageResponse ResponseFromInsertImageCall(UnityWebRequest r){
		string jsonReturned = r.downloadHandler.text;
		InsertImageResponse response = JsonConvert.DeserializeObject<InsertImageResponse> (jsonReturned);
		return response;
	}

	//Reference: https://docs.unity3d.com/ScriptReference/WWWForm.html
	//Reference: https://docs.unity3d.com/Manual/UnityWebRequest-SendingForm.html
	//Reference: https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Complete_list_of_MIME_types

	/// <summary>
	/// For pics from the device
	/// </summary>
	/// <param name="forUpload">For upload.</param>
	/// <param name="callingClass">Calling class.</param>
	public static void UploadEntryCoroutine(UploadImage forUpload, MonoBehaviour callingClass){
		callingClass.StartCoroutine (UploadEntry (forUpload));


	}

	private static IEnumerator UploadEntry(UploadImage forUpload){
		//System.Drawing.Image a = System.Drawing.Image.FromFile(forUpload.url);
		//Texture2D b = new Texture2D (a.Width, a.Height 	 );

		byte[] forUploading= System.IO.File.ReadAllBytes (forUpload.url);
		//ImageConversion.LoadImage (b, forUploading1);

		//byte[] forUploading2 = b.EncodeToPNG ();



		WWWForm send = new WWWForm ();
		send.AddField ("user_id", "" + forUpload.userId);
		send.AddField ("username", forUpload.username);
		Debug.Log ("the images contest id is " + forUpload.contestId);
		send.AddField ("contest_id", "" +  forUpload.contestId);
		send.AddField ("description", forUpload.description);
		send.AddBinaryData ("?",forUploading,"whatever","image/" + forUpload.ContentType());
		UnityWebRequest sendIt = UnityWebRequest.Post ("http://pick-apic.com/webservices/InsertImage.aspx",send);

		Debug.Log ("some info: " + sendIt.uploadHandler.contentType);

		yield return sendIt.SendWebRequest ();


		IDictionaryEnumerator bla = sendIt.GetResponseHeaders().GetEnumerator();
		while (bla.MoveNext ()) {
			KeyValuePair<string,string> stuff = (KeyValuePair<string,string>)bla.Current;
			Debug.Log (" " + stuff.Key + ", " + stuff.Value );

		}
		//NetworkAPI.InsertImageResponse response = NetworkAPI.ResponseFromInsertImageCall (sendImages);

		Debug.Log("hopefully this isnt gibberish: " + sendIt.downloadHandler.text);


		Debug.Log ("ok it worked hopefully");


	}

	/// <summary>
	/// For pics taken by the in app camera
	/// </summary>
	/// <param name="forUpload">For upload.</param>
	/// <param name="callingClass">Calling class.</param>
	public static void UploadCapturedEntry(CapturedImage forUpload, MonoBehaviour callingClass){
		callingClass.StartCoroutine (UploadCapturedEntry (forUpload));
	}




	private static IEnumerator UploadCapturedEntry(CapturedImage forUpload){
		//System.Drawing.Image a = System.Drawing.Image.FromFile(forUpload.url);
		//Texture2D b = new Texture2D (a.Width, a.Height 	 );

		byte[] forUploading= forUpload.texture.EncodeToPNG();
		//ImageConversion.LoadImage (b, forUploading1);

		//byte[] forUploading2 = b.EncodeToPNG ();



		WWWForm send = new WWWForm ();
		send.AddField ("user_id", "" + forUpload.userId);
		send.AddField ("username", forUpload.username);
		Debug.Log ("the images contest id is " + forUpload.contestId);
		send.AddField ("contest_id", "" +  forUpload.contestId);
		send.AddField ("description", forUpload.description);
		send.AddBinaryData ("?",forUploading,"whatever","image/png");
		UnityWebRequest sendIt = UnityWebRequest.Post ("http://pick-apic.com/webservices/InsertImage.aspx",send);

		Debug.Log ("some info: " + sendIt.uploadHandler.contentType);

		yield return sendIt.SendWebRequest ();


		IDictionaryEnumerator bla = sendIt.GetResponseHeaders().GetEnumerator();
		while (bla.MoveNext ()) {
			KeyValuePair<string,string> stuff = (KeyValuePair<string,string>)bla.Current;
			Debug.Log (" " + stuff.Key + ", " + stuff.Value );

		}
		//NetworkAPI.InsertImageResponse response = NetworkAPI.ResponseFromInsertImageCall (sendImages);

		Debug.Log("hopefully this isnt gibberish: " + sendIt.downloadHandler.text);


		Debug.Log ("ok it worked hopefully");


	}





}
