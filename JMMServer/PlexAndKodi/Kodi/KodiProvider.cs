﻿using System.IO;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;
using JMMContracts.PlexAndKodi;
using System;

namespace JMMServer.PlexAndKodi.Kodi
{
    public class KodiProvider : IProvider
    {
        //public const string MediaTagVersion = "1420942002";

        public string ServiceAddress => MainWindow.PathAddressKodi;
        public int ServicePort => int.Parse(ServerSettings.JMMServerPort);
        public bool UseBreadCrumbs => false; // turn off breadcrumbs navigation (plex)
        public int AddExtraItemForSearchButtonInGroupFilters => 0; // dont add item count for search (plex)
        public bool ConstructFakeIosParent => false; //turn off plex workaround for ios (plex)
        public bool AutoWatch => false; //turn off marking watched on stream side (plex)

        public bool EnableRolesInLists { get; } =true;
        public bool EnableAnimeTitlesInLists { get; } = true;
        public bool EnableGenresInLists { get; } = true;

        public string Proxyfy(string url)
        {
            return url;
        }

        public string ShortUrl(string url)
        {
			// Faster and More accurate than regex
			try
			{
				Uri uri = new Uri(url);
				return uri.PathAndQuery;
			}
			catch
			{
				// if this fails, then there is a problem
				return url;
			}
        }

        public MediaContainer NewMediaContainer(MediaContainerTypes type, string title = null, bool allowsync = false, bool nocache = false, BreadCrumbs info = null)
        {
            MediaContainer m = new MediaContainer();
            m.Title1 = m.Title2 = title;
            // not needed
            //m.AllowSync = allowsync ? "1" : "0";
            //m.NoCache = nocache ? "1" : "0";
            //m.ViewMode = "65592";
            //m.ViewGroup = "show";
            //m.MediaTagVersion = MediaTagVersion;
            m.Identifier = "plugin.video.nakamori";
            return m;
        }
    }
}