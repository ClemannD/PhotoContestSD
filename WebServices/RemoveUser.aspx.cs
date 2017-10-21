using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class WebServices_RemoveUser : System.Web.UI.Page
{

	public struct RemoveUserRequest
	{
		public int user_id;
	}

	public struct RemoveUserResponse
	{
		public string error;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		RemoveUserRequest req;
		RemoveUserResponse res = new RemoveUserResponse();
		res.error = String.Empty;

		// Need passed in store id and number of requested results.
		// 1. Deserialize the incoming Json.
		try
		{
			req = GetRequestInfo();
		}
		catch(Exception ex)
		{
			res.error = ex.Message.ToString();

			// Return the results as Json.
			SendResultInfoAsJson(res);

			return;
		}

		// Now do what you need to do.

		SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
		try
		{
			connection.Open();

			string sql = String.Format("DELETE FROM Users WHERE user_id='{0}'", req.user_id);
			SqlCommand command = new SqlCommand( sql, connection );
			command.ExecuteNonQuery();
		}
		catch(Exception ex)
		{
			res.error = ex.Message.ToString();
		}
		finally
		{
			if( connection.State == ConnectionState.Open )
			{
				connection.Close();
			}
		}

		// Return the results as Json.
		SendResultInfoAsJson(res);
	}

	RemoveUserRequest GetRequestInfo()
	{
		// Get the Json from the POST.
		string strJson = String.Empty;
		HttpContext context = HttpContext.Current;
		context.Request.InputStream.Position = 0;
		using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
		{
			strJson = inputStream.ReadToEnd();
		}

		// Deserialize the Json.
		RemoveUserRequest req = JsonConvert.DeserializeObject<RemoveUserRequest>(strJson);

		return (req);
	}

	void SendResultInfoAsJson(RemoveUserResponse res)
	{
		string strJson = JsonConvert.SerializeObject(res);
		Response.ContentType = "application/json; charset=utf-8";
		Response.Write(strJson);
		Response.End();
	}

}
