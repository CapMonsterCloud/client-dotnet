using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Castle CustomTask recognition request.
    /// </summary>
    /// <remarks>
    /// Castle is a website protection system that blocks automated attacks and
    /// suspicious activity. It monitors user behavior and requests in real time,
    /// remaining almost invisible to regular visitors and only becoming noticeable
    /// during unusual or high-volume traffic.
    /// </remarks>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/castle-task
    /// </example>
    public sealed class CastleCustomTaskRequest : CustomTaskRequestBase
    {
        /// <inheritdoc/>
        public override string Class => "Castle";

        /// <summary>
        /// Publishable Key, the Castle identifier. It can be found on the page/in the site scripts.
        /// </summary>
        /// <example>pk_1Tk5Yzr1WFzxrJCh7WzMZzY1rHpaOtdK</example>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Initializes Castle task with required metadata.
        /// </summary>
        /// 
        /// <param name="wUrl">
        /// <example>"https://s.rsg.sc/auth/js/20251234bgef/build/cw.js"</example>
        /// Link to cw.js file. You can find it in Developer Tools on the Network tab.
        /// </param>
        /// 
        /// <param name="swUrl">
        /// <example>"https://s.rsg.sc/auth/js/20251234bgef/build/csw.js"</example>
        /// Link to csw.js file. You can find it in Developer Tools on the Network tab.
        /// </param>
        /// 
        /// <param name="count">
        /// <example>1</example>
        /// Number of tokens to generate — default is 1.
        /// Generation of 1 to 49 Castle tokens bound to the same browser session (with the same __cuid identifier).
        /// If a value greater than 49 is specified, the maximum allowed number of tokens — 49 — will be returned, and the cost will be calculated based on this amount.
        /// </param>
        public CastleCustomTaskRequest(string wUrl, string swUrl, int count = 1) =>
            Metadata = new { wUrl, swUrl, count };
    }
}
