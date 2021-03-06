﻿using Machine.Specifications;

namespace Elders.Cronus
{
    [Subject("Urn")]
    public class When_formatting_urn_using__Base64UrlTokenUrnFormatProvider__
    {
        Because of = () => result = provider.Format(urn);

        It should_format_to_base64 = () => result.ShouldEqual(urnBase64UrlToken);

        static Base64UrlTokenUrnFormatProvider provider = new Base64UrlTokenUrnFormatProvider();
        static IUrn urn = new Urn("Tenant", @"arName:abc123()+,-.:=@;$_!*'%99a");
        static string urnBase64UrlToken = "dXJuOnRlbmFudDphcm5hbWU6YWJjMTIzKCkrLC0uOj1AOyRfISonJTk5YQ2";
        static string result;
    }
}
