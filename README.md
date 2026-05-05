✅ CapMonster.Cloud — Fast, Reliable CAPTCHA Solving for Automation & Scraping

[![CapMonster Cloud](https://help.zennolab.com/upload/u/e4/e4bc15839b25.png)](https://capmonster.cloud/en/?utm_source=github&utm_campaign=cmcrep)
 
 # CapMonster Cloud .NET SDK

[![NuGet version](https://img.shields.io/nuget/v/Zennolab.CapMonsterCloud.Client)](https://www.nuget.org/packages/Zennolab.CapMonsterCloud.Client)

Official .NET SDK for the CapMonster Cloud API.
Use this package when you want to create tasks and retrieve solutions from .NET applications and services.

## Links

- Package: [Zennolab.CapMonsterCloud.Client on NuGet](https://www.nuget.org/packages/Zennolab.CapMonsterCloud.Client)
- Documentation: [docs.capmonster.cloud](https://docs.capmonster.cloud/?utm_source=github&utm_campaign=cmcrep)
- Dashboard / API key: [dash.capmonster.cloud](https://dash.capmonster.cloud/?utm_source=github&utm_campaign=cmcrep)

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

- [AltchaCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/altcha-task?utm_source=github&utm_campaign=cmcrep)
- [AmazonWafRequest](https://docs.capmonster.cloud/docs/captchas/amazon-task?utm_source=github&utm_campaign=cmcrep)
- [BasiliskCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/Basilisk-task?utm_source=github&utm_campaign=cmcrep)
- [BinanceTaskRequest](https://docs.capmonster.cloud/docs/captchas/binance?utm_source=github&utm_campaign=cmcrep)
- [CastleCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/castle-task?utm_source=github&utm_campaign=cmcrep)
- [DataDomeCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/datadome?utm_source=github&utm_campaign=cmcrep)
- [FunCaptchaComplexImageTaskRequest](https://docs.capmonster.cloud/docs/captchas/ComplexImageTask-Recognition?utm_source=github&utm_campaign=cmcrep)
- [FunCaptchaRequest](https://docs.capmonster.cloud/docs/captchas/funcaptcha-task?utm_source=github&utm_campaign=cmcrep)
- [GeeTestRequest](https://docs.capmonster.cloud/docs/captchas/geetest-task?utm_source=github&utm_campaign=cmcrep)
- [HuntCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/hunt-task?utm_source=github&utm_campaign=cmcrep)
- [ImageToTextRequest](https://docs.capmonster.cloud/docs/captchas/image-to-text?utm_source=github&utm_campaign=cmcrep)
- [ImpervaCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/incapsula?utm_source=github&utm_campaign=cmcrep)
- [MTCaptchaTaskRequest](https://docs.capmonster.cloud/docs/captchas/mtcaptcha-task?utm_source=github&utm_campaign=cmcrep)
- [ProsopoTaskRequest](https://docs.capmonster.cloud/docs/captchas/prosopo-task?utm_source=github&utm_campaign=cmcrep)
- [RecaptchaComplexImageTaskRequest](https://docs.capmonster.cloud/docs/captchas/recaptcha-click?utm_source=github&utm_campaign=cmcrep)
- [RecaptchaV2EnterpriseRequest](https://docs.capmonster.cloud/docs/captchas/recaptcha-v2-enterprise-task?utm_source=github&utm_campaign=cmcrep)
- [RecaptchaV2Request](https://docs.capmonster.cloud/docs/captchas/no-captcha-task?utm_source=github&utm_campaign=cmcrep)
- [RecaptchaV3ProxylessRequest](https://docs.capmonster.cloud/docs/captchas/recaptcha-v3-task?utm_source=github&utm_campaign=cmcrep)
- [RecognitionComplexImageTaskRequest](https://docs.capmonster.cloud/docs/captchas/ComplexImageTask-Recognition?utm_source=github&utm_campaign=cmcrep)
- [TemuCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/temu-task?utm_source=github&utm_campaign=cmcrep)
- [TenDiCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/tendi?utm_source=github&utm_campaign=cmcrep)
- [TspdCustomTaskRequest](https://docs.capmonster.cloud/docs/captchas/tspd-task?utm_source=github&utm_campaign=cmcrep)
- [TurnstileRequest](https://docs.capmonster.cloud/docs/captchas/turnstile-task?utm_source=github&utm_campaign=cmcrep)
- [YidunTaskRequest](https://docs.capmonster.cloud/docs/captchas/yidun-task?utm_source=github&utm_campaign=cmcrep)

:star:️ If you find this project useful, please give it a star on GitHub!
