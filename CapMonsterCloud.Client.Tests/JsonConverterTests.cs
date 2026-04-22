using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Zennolab.CapMonsterCloud.Requests;

namespace Zennolab.CapMonsterCloud.Client
{
    public class JsonConverterTests
    {
        [Test]
        public void NumericFlagConverter_ShouldDeserialize([Values] bool numeric)
        {
            // Arrange
            var request = new ImageToTextRequest
            {
                Body = "some base64 body",
                CapMonsterModule = CapMonsterModules.YandexWave,
                CaseSensitive = true,
                Numeric = numeric,
                RecognizingThreshold = 65,
                Math = false
            };

            var target = JsonConvert.SerializeObject(request);

            // Act
            var actual = JsonConvert.DeserializeObject<ImageToTextRequest>(target);

            // Assert
            _ = actual!.Numeric.Should().Be(request.Numeric);
        }

    }
}
