using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System;
using System.Net;

public class NetworkAPI:MonoBehaviour{
	private const int RETRIES = 10;
	private const int RETRY_SLEEP = 10;
	public const string UPLOAD_URL = "http://INSERTDOMAIN/Webservices/";//TODO add pick a pic domain name??

	/*
	public struct InsertUserRequest
	{
		public string userName, fullName, bio, email, password;
	}

	public struct InsertUserResponse
	{
		public int id;
		public string error;
	}

	public static InsertUserResponse doUserInsert( string userName, string fullName, string bio, string email, string password, string domain )//TODO missing bio
	{
		InsertUserRequest req = new InsertUserRequest();
		req.userName = userName;
		req.fullName = fullName;
		req.email = email;
		req.password = password;
		req.bio = bio;
		InsertUserResponse res = new InsertUserResponse();
		res.error = String.Empty;

		string strURL = string.Format("http://{0}/Webservices/InsertUser.aspx", domain);
		string strJsonInput = JsonConvert.SerializeObject(req);
		WebClient wc = new WebClient();

		for (int i = 0; i < RETRIES; i++)
		{
			try
			{
				wc.Headers[HttpRequestHeader.ContentType] = "application/json";
				string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);
				res = JsonConvert.DeserializeObject<InsertUserResponse>(strJsonResult);
				return (res);
			}
			catch (System.Exception ex)
			{
				res.error = ex.Message.ToString();
			}
			Thread.Sleep(RETRY_SLEEP);
		}

		return (res);
	}

	public struct LoginUserRequest
	{
		public string username, password;
	}

	public struct LoginUserResponse
	{
		public int id;
		public string error;
	}

	public static LoginUserResponse doUserLogin( string userName, string password, string domain )
	{
		LoginUserRequest req = new LoginUserRequest();
		req.username = userName;
		req.password = password;
		LoginUserResponse res = new LoginUserResponse();
		res.error = String.Empty;

		string strURL = string.Format("http://{0}/Webservices/LoginUser.aspx", domain);
		string strJsonInput = JsonConvert.SerializeObject(req);
		WebClient wc = new WebClient();

		for (int i = 0; i < RETRIES; i++)
		{
			try
			{
				wc.Headers[HttpRequestHeader.ContentType] = "application/json";
				string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);
				res = JsonConvert.DeserializeObject<LoginUserResponse>(strJsonResult);
				return (res);
			}
			catch (System.Exception ex)
			{
				res.error = ex.Message.ToString();
			}
			Thread.Sleep(RETRY_SLEEP);
		}

		return (res);
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

	public struct GenericRequest{
		public int id;
		public string userName;
		public string fullName;
		public string bio;
		public string email;
		public string password;
	}

	public struct GenericResponse{
		public int id;
		public string error;
	}

	public static GenericResponse doGenericRequest(int id, string userName, string fullName, string bio, string email, string password){
		GenericRequest genRequest = new GenericRequest ();
		genRequest.id = id;
		genRequest.userName = userName;
		genRequest.fullName = fullName;
		genRequest.bio = bio;
		genRequest.email = email;
		genRequest.password = password;

		WebClient webClient = new WebClient ();
		string uploadJson = JsonConvert.SerializeObject(genRequest);

		GenericResponse genResponse = new GenericResponse ();


		for(int x=0;x<RETRIES;x++){

			try {
				webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
				string returnString = (string)webClient.UploadString(UPLOAD_URL + "Generic.aspx","POST",uploadJson);
				genResponse = JsonConvert.DeserializeObject<GenericResponse>(returnString);
				break;
			} catch (Exception ex) {
				genResponse.error = ex.Message;
			}
			Thread.Sleep (RETRY_SLEEP);
		}

		return genResponse;
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



*/




}
