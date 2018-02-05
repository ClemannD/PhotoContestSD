using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using System.Net;
using Newtonsoft.Json;

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
	}

	public struct RetrieveUserResponse{
		public string userName;
		public string fullName;
		public string bio;
		public string email;
		public string error;
	}

	public static RetrieveUserResponse DoRetrieveUserRequest(int userId){
		RetrieveUserRequest retrieveUserRequest = new RetrieveUserRequest();
		retrieveUserRequest.user_id = userId;

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

	public struct RetrieveAllImagesRequest{
		public int contest_id;
	}

	public struct imageInfo{
		public int image_id;
		public string image_url;
		public string description;
		public int user_id;
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







}
