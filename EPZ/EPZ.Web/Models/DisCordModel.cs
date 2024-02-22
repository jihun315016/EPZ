using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace EPZ.Web.Models
{
    public class DisCordModel
    {
        private string? token;

        public string Token { get { return token; } set { token = value; } }
        /// <summary>
        ///     Returns the base Discord CDN URL.
        /// </summary>
        /// <returns>
        ///     The base Discord Content Delivery Network (CDN) URL.
        /// </returns>
        public const string CDNUrl = "https://cdn.discordapp.com/";
        /// <summary>
        ///     Returns the base Discord invite URL.
        /// </summary>
        /// <returns>
        ///     The base Discord invite URL.
        /// </returns>
        public const string InviteUrl = "https://discord.gg/";

        /// <summary>
        ///     Returns the default timeout for requests.
        /// </summary>
        /// <returns>
        ///     The amount of time it takes in milliseconds before a request is timed out.
        /// </returns>
        public const int DefaultRequestTimeout = 15000;
        /// <summary>
        ///     Returns the max length for a Discord message.
        /// </summary>
        /// <returns>
        ///     The maximum length of a message allowed by Discord.
        /// </returns>
        public const int MaxMessageSize = 2000;
        /// <summary>
        ///     Returns the max messages allowed to be in a request.
        /// </summary>
        /// <returns>
        ///     The maximum number of messages that can be gotten per-batch.
        /// </returns>
        public const int MaxMessagesPerBatch = 100;
        /// <summary>
        ///     Returns the max users allowed to be in a request.
        /// </summary>
        /// <returns>
        ///     The maximum number of users that can be gotten per-batch.
        /// </returns>
        public const int MaxUsersPerBatch = 1000;
        /// <summary>
        ///     Returns the max bans allowed to be in a request.
        /// </summary>
        /// <returns>
        ///     The maximum number of bans that can be gotten per-batch.
        /// </returns>
        public const int MaxBansPerBatch = 1000;
        /// <summary>
        ///     Returns the max users allowed to be in a request for guild event users.
        /// </summary>
        /// <returns>
        ///     The maximum number of users that can be gotten per-batch.
        /// </returns>
        public const int MaxGuildEventUsersPerBatch = 100;
        /// <summary>
        ///     Returns the max guilds allowed to be in a request.
        /// </summary>
        /// <returns>
        ///     The maximum number of guilds that can be gotten per-batch.
        /// </returns>
        public const int MaxGuildsPerBatch = 100;
        /// <summary>
        ///     Returns the max user reactions allowed to be in a request.
        /// </summary>
        /// <returns>
        ///     The maximum number of user reactions that can be gotten per-batch.
        /// </returns>
        public const int MaxUserReactionsPerBatch = 100;
        /// <summary>
        ///     Returns the max audit log entries allowed to be in a request.
        /// </summary>
        /// <returns>
        ///     The maximum number of audit log entries that can be gotten per-batch.
        /// </returns>
        public const int MaxAuditLogEntriesPerBatch = 100;

        /// <summary>
        ///     Returns the max number of stickers that can be sent with a message.
        /// </summary>
        public const int MaxStickersPerMessage = 3;

        /// <summary>
        ///     Returns the max number of embeds that can be sent with a message.
        /// </summary>
        public const int MaxEmbedsPerMessage = 10;

        /// <summary>
        ///     Gets or sets how a request should act in the case of an error, by default.
        /// </summary>
        /// <returns>
        ///     The currently set <see cref="RetryMode"/>.
        /// </returns>
        public RetryMode DefaultRetryMode { get; set; } = RetryMode.AlwaysRetry;

        /// <summary>
        ///     Gets or sets the default callback for ratelimits.
        /// </summary>
        /// <remarks>
        ///     This property is mutually exclusive with <see cref="RequestOptions.RatelimitCallback"/>.
        /// </remarks>
        public Func<IRateLimitInfo, Task> DefaultRatelimitCallback { get; set; }

        /// <summary>
        ///     Gets or sets the minimum log level severity that will be sent to the Log event.
        /// </summary>
        /// <returns>
        ///     The currently set <see cref="LogSeverity"/> for logging level.
        /// </returns>
        public LogSeverity LogLevel { get; set; } = LogSeverity.Info;

        /// <summary>
        ///     Gets or sets whether the initial log entry should be printed.
        /// </summary>
        /// <remarks>
        ///     If set to <see langword="true" />, the library will attempt to print the current version of the library, as well as
        ///     the API version it uses on startup.
        /// </remarks>
        internal bool DisplayInitialLog { get; set; } = true;

        /// <summary>
        /// 	Gets or sets whether or not rate-limits should use the system clock.
        /// </summary>
        /// <remarks>
        ///		If set to <see langword="false" />, we will use the X-RateLimit-Reset-After header
        ///		to determine when a rate-limit expires, rather than comparing the
        ///		X-RateLimit-Reset timestamp to the system time.
        ///
        ///		This should only be changed to false if the system is known to have
        /// 	a clock that is out of sync. Relying on the Reset-After header will
        ///		incur network lag.
        ///
        ///		Regardless of this property, we still rely on the system's wall-clock
        ///		to determine if a bucket is rate-limited; we do not use any monotonic
        ///		clock. Your system will still need a stable clock.
        /// </remarks>
        public bool UseSystemClock { get; set; } = true;

        /// <summary>
        ///     Gets or sets whether or not the internal expiration check uses the system date
        ///     + snowflake date to check if an interaction can be responded to.
        /// </summary>
        /// <remarks>
        ///     If set to <see langword="false"/> then the CreatedAt property in an interaction
        ///     will be set to when it was received instead of the snowflakes date.
        ///     <br/>
        ///     <b>This will still require a stable clock on your system.</b>
        /// </remarks>
        public bool UseInteractionSnowflakeDate { get; set; } = true;

        /// <summary>
        ///     Gets or sets if the Rest/Socket user <see cref="object.ToString"/> override formats the string in respect to bidirectional unicode.
        /// </summary>
        /// <remarks>
        ///     By default, the returned value will be "?Discord?#1234", to work with bidirectional usernames.
        ///     <br/>
        ///     If set to <see langword="false"/>, this value will be "Discord#1234".
        /// </remarks>
        public bool FormatUsersInBidirectionalUnicode { get; set; } = true;

        /// <summary>
        ///     Returns the max thread members allowed to be in a request.
        /// </summary>
        /// <returns>
        ///     The maximum number of thread members that can be gotten per-batch.
        /// </returns>
        public const int MaxThreadMembersPerBatch = 100;

        /// <summary>
        ///     Returns the max length of an application tag.
        /// </summary>
        public const int MaxApplicationTagLength = 20;

        /// <summary>
        ///     Returns the max length of an application description.
        /// </summary>
        public const int MaxApplicationDescriptionLength = 400;

        /// <summary>
        ///     Returns the max amount of tags applied to an application.
        /// </summary>
        public const int MaxApplicationTagCount = 5;

        /// <summary>
        ///     Returns the factor to reduce the heartbeat interval.
        /// </summary>
        /// <remarks>
        ///     If a heartbeat takes longer than the interval estimated by Discord, the connection will be closed.
        ///     This factor is used to reduce the interval and ensure that Discord will get the heartbeat within the estimated interval.
        /// </remarks>
        internal const double HeartbeatIntervalFactor = 0.9;

        /// <summary>
        ///     Returns the maximum length of a voice channel status.
        /// </summary>
        public const int MaxVoiceChannelStatusLength = 500;

        /// <summary>
        ///     Returns the maximum number of entitlements that can be gotten per-batch.
        /// </summary>
        public const int MaxEntitlementsPerBatch = 100;


    }
}
