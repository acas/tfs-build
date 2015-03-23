using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace TfsBuild.Controllers
{
	[RoutePrefix("Builds")]
	public class BuildsController : ApiController
	{				
		[Route("")]
		public void Post([FromBody] JObject data)
		{
			try
			{
				Models.BuildController.QueueBuild(data["buildName"].ToString());
			}
			catch
			{
				//do nothing for now, just swallow it
			}
		}
	}
}
