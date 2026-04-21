# CapMonster Cloud .NET client

[![NuGet version](https://img.shields.io/nuget/v/Zennolab.CapMonsterCloud.Client)](https://www.nuget.org/packages/Zennolab.CapMonsterCloud.Client)

Official .NET client for creating CAPTCHA tasks and receiving solutions from the CapMonster Cloud API.

## Links

- Package: [Zennolab.CapMonsterCloud.Client on NuGet](https://www.nuget.org/packages/Zennolab.CapMonsterCloud.Client)
- Documentation: [docs.capmonster.cloud](https://docs.capmonster.cloud/)
- Dashboard / API key: [dash.capmonster.cloud](https://dash.capmonster.cloud/)

## Installation

Package Manager:

```powershell
Install-Package Zennolab.CapMonsterCloud.Client
```

.NET CLI:

```bash
dotnet add package Zennolab.CapMonsterCloud.Client
```

## Minimal example

```csharp
var clientOptions = new ClientOptions
{
    ClientKey = "<your capmonster.cloud API key>"
};

var cmCloudClient = CapMonsterCloudClientFactory.Create(clientOptions);

var recaptchaV2Request = new RecaptchaV2Request
{
    WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
    WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
};

var recaptchaV2Result = await cmCloudClient.SolveAsync(recaptchaV2Request);
```

Supported task families include reCAPTCHA, GeeTest, Turnstile, image-to-text, and additional task types documented in the public docs.

Additional examples:

    // solve HCaptcha (without proxy)
    var hcaptchaRequest = new HCaptchaRequest
    {
        WebsiteUrl = "https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
        WebsiteKey = "472fc7af-86a4-4382-9a49-ca9090474471",
    };
    var hcaptchaResult = await cmCloudClient.SolveAsync(hcaptchaRequest);

Supported request classes:

- [GeeTestRequest](https://zenno.link/doc-geetest-proxy-en)
- [HCaptchaRequest](https://zenno.link/doc-hcaptcha-proxy-en)
- [ImageToTextRequest](https://zenno.link/doc-ImageToTextTask-en)
- [RecaptchaV2Request](https://zenno.link/doc-recaptcha2-proxy-en)
- [RecaptchaV3ProxylessRequest](https://zenno.link/doc-recaptcha3-en)
- [RecaptchaV2EnterpriseRequest](https://zenno.link/doc-recaptcha2e-proxy-en)
- [TurnstileRequest](https://zenno.link/doc-turnstile-proxy-en)
- [RecaptchaComplexImageTaskRequest](https://zenno.link/doc-complextask-rc-en)
- [HcaptchaComplexImageTaskRequest](https://zenno.link/doc-complextask-hc-en)
