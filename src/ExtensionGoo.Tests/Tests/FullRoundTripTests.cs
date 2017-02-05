using System.IO;
using System.Threading.Tasks;
using ExtensionGoo.Standard.Extensions;
using ExtensionGoo.Tests.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionGoo.Tests.Tests
{
    [TestClass]
    public class FullRoundTripTests
    {
        [TestMethod]
        public async Task TestRoundTrip()
        {
            var url =
                "https://jwtparse.azurewebsites.net/api/JWTWithRsaValidator?code=r3gqblabmyfju0c6zbhknwyiimhdrdn1yld7";

            var sampleData = File.ReadAllText("Data\\JwtSampleEntity.txt").DeSerialise<JwtSampleEntity>();

            var result = await url.PostAndParse<TokenResult, JwtSampleEntity>(sampleData);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public async Task TestPost()
        {
            var url =
                "https://api.projectoxford.ai/vision/v1.0/analyze?visualFeatures=Adult,Categories,Color,Description,Faces,ImageType,Tags&subscription-key=5c1fdbb9037a43788bd46b9261866f13 ";

            var img = File.ReadAllBytes("Data\\stan.jpg");

            var postResult = await url.PostAndParse<VisionResponse>(img);

            Assert.IsNotNull(postResult);
        }
    }
}
