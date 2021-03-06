﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsteriskWrapper
{
    public class AriClient : IAriClient
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual Uri BaseUri { get; set; }

        public AriClient(Uri baseUri, string username, string password)
        {
            Username = username;
            Password = password;
            BaseUri = baseUri;

            Channels = new Channels(this);
            Bridges = new Bridges(this);
            Playbacks = new Playbacks(this);
        }

        public virtual HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler, true);

            handler.Credentials = new NetworkCredential(Username, Password);
            client.BaseAddress = BaseUri;

            return client;
        }

        public virtual IChannels Channels { get; protected set; }

        public virtual IBridges Bridges { get; protected set; }

        public virtual IPlaybacks Playbacks { get; protected set; }
    }
}
