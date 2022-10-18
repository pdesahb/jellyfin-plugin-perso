using System;
using Jellyfin.Plugin.Resolver.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.Resolver
{
	public class Plugin : BasePlugin<PluginConfiguration>
	{
		public override string Name => "Personal Resolvers Plugin";
		public override Guid Id => Guid.Parse("167ee128-f2e4-4c0c-bbe1-23c7adeb159d");
		
		public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer)
		{
		}
	}
}
