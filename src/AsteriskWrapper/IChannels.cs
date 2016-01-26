﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsteriskWrapper
{
    public interface IChannels
    {
        ChannelWrapper this[string channelId] { get; }
        Task AnswerAsync(string channelId);
        Task AnswerAsync(string channelId, CancellationToken cancellationToken);
        Task<IEnumerable<Channel>> GetActiveChannelsAsync();
        Task<IEnumerable<Channel>> GetActiveChannelsAsync(CancellationToken cancellationToken);
        Task<string> GetVariableAsync(string channelId, string variable);
        Task<string> GetVariableAsync(string channelId, string variable, CancellationToken cancellationToken);
        Task HangupAsync(string channelId);
        Task HangupAsync(string channelId, CancellationToken cancellationToken);
        Task SetVariableAsync(string channelId, string variable, string value);
        Task SetVariableAsync(string channelId, string variable, string value, CancellationToken cancellationToken);
        Task<Playback> StartPlaybackAsync(string channelId, string media);
        Task<Playback> StartPlaybackAsync(string channelId, string media, CancellationToken cancellationToken);
        Task<Channel> GetChannelAsync(string channelId);
        Task<Channel> GetChannelAsync(string channelId, CancellationToken cancellationToken);
        Task<string> CreateChannel(string endpoint, string extension, string context, string priority, string app, CallerId callerId, string label, string appArgs, int timeout, string channelId, string otherChannelId, string originator);
        Task<string> CreateChannel(string endpoint, string extension, string context, string priority, string app, CallerId callerId, string label, string appArgs, int timeout, string channelId, string otherChannelId, string originator, CancellationToken cancellationToken);
    }
}
