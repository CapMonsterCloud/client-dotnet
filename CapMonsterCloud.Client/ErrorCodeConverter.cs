using System;

namespace Zennolab.CapMonsterCloud;

internal static class ErrorCodeConverter
{
    public static ErrorType Convert(string? errorCode)
    {
        if (string.IsNullOrEmpty(errorCode))
            return ErrorType.Unknown;

        const string Prefix = "ERROR_";

        if (errorCode.StartsWith(Prefix, StringComparison.Ordinal))
        {
            errorCode = errorCode[Prefix.Length..];
        }

        return Enum.TryParse<ErrorType>(errorCode, ignoreCase: true, out var result)
            ? result
            : errorCode.Equals("WRONG_CAPTCHA_ID", StringComparison.OrdinalIgnoreCase)
                ? ErrorType.NO_SUCH_CAPCHA_ID
                : ErrorType.Unknown;
    }
}
