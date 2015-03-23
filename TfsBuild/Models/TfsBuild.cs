using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TfsBuild.Models
{
	public static class BuildController
	{
		public static void QueueBuild(string buildName)
		{		
			string buildDefinitionInfo = System.Configuration.ConfigurationManager.AppSettings[buildName].ToString();
			string projectCollectionUrl = System.Configuration.ConfigurationManager.AppSettings["projectCollectionUrl"];
			TfsTeamProjectCollection teamProjectCollection = new TfsTeamProjectCollection(new Uri(projectCollectionUrl));
			IBuildServer buildServer = (IBuildServer)teamProjectCollection.GetService(typeof(IBuildServer));
			string projectName = buildDefinitionInfo.Split(';')[0];
			string definitionName = buildDefinitionInfo.Split(';')[1];
			IBuildDefinition buildDefinition = buildServer.GetBuildDefinition(projectName, definitionName, QueryOptions.Definitions);
			buildServer.QueueBuild(buildDefinition);
		}
	}
}

