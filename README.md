# CapMonster Cloud .NET SDK

[![NuGet version](https://img.shields.io/nuget/v/Zennolab.CapMonsterCloud.Client)](https://www.nuget.org/packages/Zennolab.CapMonsterCloud.Client)

Official .NET SDK for the CapMonster Cloud API.
Use this package when you want to create tasks and retrieve solutions from .NET applications and services.

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

Need to test before depositing? Contact support and we’ll add trial credits to your account.

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

Supported request classes:

- [AltchaCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/altcha-task)
- [AmazonWafRequest](https://docs.capmonster.cloud/docs/captchas/amazon-task)
- [BasiliskCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/Basilisk-task)
- [BinanceTaskRequest](https://docs.capmonster.cloud/docs/captchas/binance)
- [CastleCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/castle-task)
- [DataDomeCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/datadome)
- [FunCaptchaComplexImageTaskRequest](https://docs.capmonster.cloud/docs/captchas/ComplexImageTask-Recognition)
- [FunCaptchaRequest](https://docs.capmonster.cloud/docs/captchas/funcaptcha-task)
- [GeeTestRequest](https://docs.capmonster.cloud/docs/captchas/geetest-task)
- [HuntCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/hunt-task)
- [ImageToTextRequest](https://docs.capmonster.cloud/docs/captchas/image-to-text)
- [ImpervaCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/incapsula)
- [MTCaptchaTaskRequest](https://docs.capmonster.cloud/docs/captchas/mtcaptcha-task)
- [ProsopoTaskRequest](https://docs.capmonster.cloud/docs/captchas/prosopo-task)
- [RecaptchaComplexImageTaskRequest](https://docs.capmonster.cloud/docs/captchas/recaptcha-click)
- [RecaptchaV2EnterpriseRequest](https://docs.capmonster.cloud/docs/captchas/recaptcha-v2-enterprise-task)
- [RecaptchaV2Request](https://docs.capmonster.cloud/docs/captchas/no-captcha-task)
- [RecaptchaV3ProxylessRequest](https://docs.capmonster.cloud/docs/captchas/recaptcha-v3-task)
- [RecognitionComplexImageTaskRequest](https://docs.capmonster.cloud/docs/captchas/ComplexImageTask-Recognition)
- [TemuCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/temu-task)
- [TenDiCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/tendi)
- [TspdCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/tspd-task)
- [TurnstileRequest](https://docs.capmonster.cloud/docs/captchas/turnstile-task)
- [YidunTaskRequest](https://docs.capmonster.cloud/docs/captchas/yidun-task)
