using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Jellyfin.Plugin.Resolver.Api;
using Emby.Naming.Common;
using Emby.Server.Implementations.Library.Resolvers.Movies
using Emby.Server.Implementations.Library.Resolvers.TV
using Microsoft.Extensions.Logging;


namespace Jellyfin.Plugin.Resolver.Resolver
{
	public class PersonalNamingOptions : NamingOptions
	{
		public PersonalNamingOptions()
		{
			CleanStrings = new[]
            {
                @"^\s*(?:[^\-]+) - (?:[^\-]+)?[0-9]+ - (?<cleaned>.+?)(?: \[[0-9-\.]+\](?: \[.+\])?)?$",
                @"^\s*(?<cleaned>.+?)(?: \((?:The|Le|La|Les|L\')\))(?: \[[0-9-]+\](?: \[.+\])?)?$",
            };

			EpisodeExpressions = new[]
            {
                new EpisodeExpression(@".*(\\|\/)\(TV\) • (?:(?:[^\-]+) - (?:[^\-]+)?[0-9]+ - )?(?<seriesname>.+?)(?: \((?:The|Le|La)\))? - S(?<seasonnumber>[0-9]+) - (?<epnumber>[0-9]+) - [^\\\/]+$")
                {
                    IsNamed = true
                },
            };
		}
	}

	public class PersonalMovieResolver: MovieResolver
	{
		public override ResolverPriority Priority => ResolverPriority.Plugin;

        public PersonalMovieResolver(IImageProcessor imageProcessor, ILogger<MovieResolver> logger, NamingOptions namingOptions)
            : base(logger, new PersonalNamingOptions())
        {
            _imageProcessor = imageProcessor;
        }
	}


	public class PersonalEpisodeResolver: EpisodeResolver
	{
		public override ResolverPriority Priority => ResolverPriority.Plugin;

        public PersonalEpisodeResolver(IImageProcessor imageProcessor, ILogger<MovieResolver> logger, NamingOptions namingOptions)
            : base(logger, new PersonalNamingOptions())
        {
            _imageProcessor = imageProcessor;
        }
	}

}
