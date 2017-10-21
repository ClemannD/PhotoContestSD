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

public partial class WebServices_LoginUser : System.Web.UI.Page
{

	public struct LoginUserRequest
	{
		public string username, password;
	}

	public struct LoginUserResponse
	{
		public int user_id;
		public string error;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		LoginUserRequest req;
		LoginUserResponse res = new LoginUserResponse();
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

			string sql = String.Format("SELECT user_id FROM Users WHERE UserName='{0}' AND Password='{1}'", req.username, req.password);
			SqlCommand command = new SqlCommand( sql, connection );
			SqlDataReader reader = command.ExecuteReader();
			if( reader.Read() )
			{
				res.user_id = Convert.ToInt32(reader["user_id"]);
			}
			reader.Close();
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

	LoginUserRequest GetRequestInfo()
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
		LoginUserRequest req = JsonConvert.DeserializeObject<LoginUserRequest>(strJson);

		return (req);
	}

	void SendResultInfoAsJson(LoginUserResponse res)
	{
		string strJson = JsonConvert.SerializeObject(res);
		Response.ContentType = "application/json; charset=utf-8";
		Response.Write(strJson);
		Response.End();
	}

}
