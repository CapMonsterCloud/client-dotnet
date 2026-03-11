using System;
using System.Collections.Generic;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud;

public partial class CapMonsterCloudClient
{
    private struct GetResultTimeouts
    {
        public TimeSpan FirstRequestDelay { get; set; }
        public TimeSpan? FirstRequestNoCacheDelay { get; set; }
        public TimeSpan RequestsInterval { get; set; }
        public TimeSpan Timeout { get; set; }
    }

    private static readonly GetResultTimeouts DefaultResultTimeouts = new()
    {
        FirstRequestDelay = TimeSpan.FromSeconds(1),
        FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
        RequestsInterval = TimeSpan.FromSeconds(1),
        Timeout = TimeSpan.FromSeconds(80)
    };

    private static GetResultTimeouts GetTimeouts(Type type)
    {
        if (!ResultTimeouts.TryGetValue(type, out var getResultTimeouts) &&
            !ResultTimeouts.TryGetValue(type.BaseType!, out getResultTimeouts))
        {
            getResultTimeouts = DefaultResultTimeouts;
        }

        return getResultTimeouts;
    }

    private static readonly IReadOnlyDictionary<Type, GetResultTimeouts> ResultTimeouts =
        new Dictionary<Type, GetResultTimeouts>
        {
            [typeof(RecaptchaV2Request)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(RecaptchaV2EnterpriseRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(RecaptchaV3ProxylessRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(RecaptchaV3EnterpriseRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(ImageToTextRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromMilliseconds(350),
                RequestsInterval = TimeSpan.FromMilliseconds(200),
                Timeout = TimeSpan.FromSeconds(10)
            },
            [typeof(ComplexImageTaskRequestBase<>)] = new()
            {
                FirstRequestDelay = TimeSpan.FromMilliseconds(350),
                RequestsInterval = TimeSpan.FromMilliseconds(200),
                Timeout = TimeSpan.FromSeconds(10)
            },
            [typeof(FunCaptchaRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(1),
                Timeout = TimeSpan.FromSeconds(80)
            },
            [typeof(HCaptchaRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(GeeTestRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                RequestsInterval = TimeSpan.FromSeconds(1),
                Timeout = TimeSpan.FromSeconds(80)
            },
            [typeof(TurnstileRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(1),
                Timeout = TimeSpan.FromSeconds(80)
            },
            [typeof(DataDomeCustomTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(AmazonWafRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(TenDiCustomTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(BasiliskCustomTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(100)
            },
            [typeof(BinanceTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                RequestsInterval = TimeSpan.FromSeconds(1),
                Timeout = TimeSpan.FromSeconds(20)
            },
            [typeof(ImpervaCustomTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                RequestsInterval = TimeSpan.FromSeconds(1),
                Timeout = TimeSpan.FromSeconds(15)
            },
            [typeof(TemuCustomTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(MTCaptchaTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(YidunTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
            [typeof(ProsopoTaskRequest)] = new()
            {
                FirstRequestDelay = TimeSpan.FromSeconds(1),
                FirstRequestNoCacheDelay = TimeSpan.FromSeconds(10),
                RequestsInterval = TimeSpan.FromSeconds(3),
                Timeout = TimeSpan.FromSeconds(180)
            },
        };
}
