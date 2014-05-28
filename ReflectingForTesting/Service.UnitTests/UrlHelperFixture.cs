using Fasterflect;
using Moq;
using NUnit.Framework;
using ReflectingForTesting.Model;

namespace ReflectingForTesting.Service.UnitTests
{
    [TestFixture]
    public class UrlHelperFixture
    {
        private UrlHelper _urlHelper;
        private Mock<ServiceProxy> _serviceProxy;

        [SetUp]
        public void SetUp()
        {
            _serviceProxy = new Mock<ServiceProxy>();

            var type = typeof (ServiceProxy);
            type.SetFieldValue("_instance", _serviceProxy.Object);

            _urlHelper = new UrlHelper();
        }

        [Test]
        public void AuthenticatedAssetUrl_AssetProvided_ReturnsFromProxy()
        {
            // Arrange
            var expected = "someUrl.com";
            var asset = new Mock<Asset>().Object;
            _serviceProxy.Setup(x => x.GenerateAuthenticatedAssetUrl(asset))
                            .Returns(expected)
                            .Verifiable();

            // Act
            var actual = _urlHelper.AuthenticatedAssetUrl(asset);

            // Assert
            _serviceProxy.Verify(x => x.GenerateAuthenticatedAssetUrl(asset));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GenerateAuthenticatedDropUrl_DropProvided_ReturnsFromProxy()
        {
            // Arrange
            var expected = "someUrl.com";
            var drop = new Mock<Drop>().Object;
            _serviceProxy.Setup(x => x.GenerateAuthenticatedDropUrl(drop))
                            .Returns(expected)
                            .Verifiable();

            // Act
            var actual = _urlHelper.AuthenticatedDropUrl(drop);

            // Assert
            _serviceProxy.Verify(x => x.GenerateAuthenticatedDropUrl(drop));
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}