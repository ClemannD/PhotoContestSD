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

public partial class WebServices_RetrieveUser : System.Web.UI.Page
{

	public struct RetrieveUserRequest
	{
		public int user_id;
	}

	public struct RetrieveUserResponse
	{
		public string userName, fullName, bio, email, password;
		public string error;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		RetrieveUserRequest req;
		RetrieveUserResponse res = new RetrieveUserResponse();
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

			// Build SQL Query
			string sql = String.Format("select * from Users where user_id={0}", req.user_id);
			SqlCommand command = new SqlCommand( sql, connection );
			SqlDataReader reader = command.ExecuteReader();
			if( reader.Read() )
			{
				res.userName = Convert.ToString(reader["UserName"]);
				res.fullName = Convert.ToString(reader["FullName"]);
				res.password = Convert.ToString(reader["Password"]);
				res.email = Convert.ToString(reader["Email"]);
				res.bio = Convert.ToString(reader["Bio"]);
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

	RetrieveUserRequest GetRequestInfo()
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
		RetrieveUserRequest req = JsonConvert.DeserializeObject<RetrieveUserRequest>(strJson);

		return (req);
	}

	void SendResultInfoAsJson(RetrieveUserResponse res)
	{
		string strJson = JsonConvert.SerializeObject(res);
		Response.ContentType = "application/json; charset=utf-8";
		Response.Write(strJson);
		Response.End();
	}

}
