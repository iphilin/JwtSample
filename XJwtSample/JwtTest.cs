using System;
using JwtSample;
using Xunit;

namespace XJwtSample
{
    public class JwtTest
    {
        [Fact]
        public void Generate_not_null()
        {
            var jwtGenerator = new JwtGenerator();
            var expireIn = 123123213; // from config
            var jwt =
                jwtGenerator.Generate(
                    "iZdf4+Arx48ML67OZl3CLXudHNxD4EKq+ObmC6qwayw=",
                    DateTime.Now,
                    DateTime.Now.AddSeconds(expireIn),
                    "kriss.rock@gmail.com");
            Assert.NotNull(jwt);
        }
    }
}