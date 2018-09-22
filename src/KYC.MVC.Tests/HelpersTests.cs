using System;
using Xunit;

namespace KYC.MVC.Tests
{
    public class HelpersTests
    {
        [Fact]
        public void Should_Hash_Object()
        {
			Byte[] actual = Helpers.sha256_hash("");
        }
    }
}
