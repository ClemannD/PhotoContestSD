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

public partial class WebServices_Generic : System.Web.UI.Page
{

	public struct GenericRequest
	{
		public int id;
		public string userName, fullName, bio, email, password;
	}

	public struct GenericResponse
	{
		public int id;
		public string error;
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		GenericRequest req;
		GenericResponse res = new GenericResponse();
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
			
			string sql = String.Format("insert into Users (UserName,FullName,Email,Password,Bio) VALUES ('{0}','{1}','{2}','{3}','{4}')", 
				req.userName, req.fullName, req.email, req.password, req.bio );
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

	GenericRequest GetRequestInfo()
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
		GenericRequest req = JsonConvert.DeserializeObject<GenericRequest>(strJson);

		return (req);
	}

	void SendResultInfoAsJson(GenericResponse res)
	{
		string strJson = JsonConvert.SerializeObject(res);
		Response.ContentType = "application/json; charset=utf-8";
		Response.Write(strJson);
		Response.End();
	}

}