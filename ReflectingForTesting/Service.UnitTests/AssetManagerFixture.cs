using System;
using System.Collections.Generic;
using System.Linq;
using Fasterflect;
using FluentAssertions;
using NUnit.Framework;
using ReflectingForTesting.Model;

namespace ReflectingForTesting.Service.UnitTests
{
    [TestFixture]
    public class AssetManagerFixture
    {
        private AssetManager _manager;
        private List<Asset> _assets;
        private Random _random;

        [SetUp]
        public void SetUp()
        {
            this._assets = new List<Asset>();
            _random = new Random();

            Enumerable.Range(1, _random.Next(20, 50)).ToList()
                .ForEach(x => this._assets.Add(new Asset { Id = _random.Next() }));

            this._manager = new AssetManager();
            this._manager.SetFieldValue("_assets", this._assets);
        }

        [Test]
        public void GetAsset_IdForExistingAsset_AssetReturned()
        {
            // Arrange
            var expected = this._assets.Skip(_random.Next(1, this._assets.Count - 1)).First();
            var id = expected.Id;

            // Act
            var actual = this._manager.GetAsset(id);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void GetAsset_IdHasNoExistingAsset_ReturnsNull()
        {
            // Arrange
            var id = this._random.Next();
            while (this._assets.Any(x => x.Id == id))
            {
                id = this._random.Next();
            }

            // Act
            var actual = this._manager.GetAsset(id);

            // Assert
            actual.Should().BeNull();
        }

    }
}