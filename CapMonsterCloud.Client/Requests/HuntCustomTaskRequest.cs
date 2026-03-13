namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Hunt CustomTask recognition request.
    /// Hunt CAPTCHA is an anti-bot system used on betting platforms to detect automated activity.
    /// </summary>
    /// <remarks>
    /// For this task, use your own proxies.
    /// Our solving system has two operating modes: X-HD generation (fingerprint) and CAPTCHA solving.
    /// If you only want to generate X-HD, do not pass the data parameter.
    /// If you need to solve the CAPTCHA, pass the token that the target site provides during certain actions (for example, when requesting an SMS).
    /// </remarks>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/hunt-task
    /// </example>
    public sealed class HuntCustomTaskRequest : CustomTaskRequestBase
    {
        /// <inheritdoc/>
        public override string Class => "Hunt";

        /// <summary>
        /// Initializes Hunt task with required metadata for X-HD generation mode.
        /// </summary>
        /// 
        /// <param name="apiGetLib">
        /// <example>"https://example.com/hd-api/external/apps/a2157wab1045d68672a63557e0n2a77edbfd15ea/api.js"</example>
        /// The full link to the api.js file.
        /// You can find this link in DevTools (the Network or Elements tabs) on the page with the Hunt CAPTCHA.
        /// </param>
        public HuntCustomTaskRequest(string apiGetLib) => Metadata = new { apiGetLib };

        /// <summary>
        /// Initializes Hunt task with required metadata for CAPTCHA solving mode.
        /// </summary>
        /// 
        /// <param name="apiGetLib">
        /// <example>"https://example.com/hd-api/external/apps/a2157wab1045d68672a63557e0n2a77edbfd15ea/api.js"</example>
        /// The full link to the api.js file. You can find this link in DevTools (the Network or Elements tabs) on the page with the Hunt CAPTCHA.
        /// Use keyword search such as: hd-api or api.js.
        /// </param>
        /// 
        /// <param name="data">
        /// <example>"kufyHK/s/jTNU...AfwIW"</example>
        /// The data parameter must be specified when using CAPTCHA solving mode
        /// </param>
        public HuntCustomTaskRequest(string apiGetLib, string data) => Metadata = new { apiGetLib, data };
    }
}
