namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// TSPD CustomTask recognition request.
    /// TSPD is a WAF (Web Application Firewall) protection designed to prevent
    /// automated attacks and suspicious activity on a website.
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/tspd-task
    /// </example>
    public sealed class TspdCustomTaskRequest : CustomTaskRequestBase
    {
        /// <inheritdoc/>
        public override string Class => "Tspd";

        /// <summary>
        /// Initializes TSPD task with required metadata.
        /// </summary>
        /// 
        /// <param name="tspdCookie">
        /// <example>"TS386a400d029=082670627aab2800722d179e73a60b575d00c96728a9f8dedd8be27a40f6a1aa5df467cebf7da7315a4e16675f010245; ....; ....;"</example>
        /// Cookies obtained on the TSPD challenge page.
        /// </param>
        /// 
        /// <param name="htmlPageBase64">
        /// <example>"PCFET0NUWVBFIGh0bWw+DQo8aHRtbD48aGVhZD4NCjxtZXRhIGh0dHAtZXF1aXY9IlByYWdtYSIgY29udGVudD0ibm8tY2FjaGUiLz4..."</example>
        /// The entire TSPD page encoded in base64.
        /// </param>
        public TspdCustomTaskRequest(string tspdCookie, string htmlPageBase64) => Metadata = new { tspdCookie, htmlPageBase64 };
    }
}
