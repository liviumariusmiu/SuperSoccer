namespace SuperSoccer.Infrastrucutre.Tests
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void TakeRandom_WithValidCount_ReturnsCorrectNumberOfItems()
        {
            // Arrange
            var items = Enumerable.Range(1, 10).ToList();

            // Act
            var result = items.TakeRandom(5).ToList();

            // Assert
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void TakeRandom_WithCountGreaterThanSource_ReturnsAllItems()
        {
            // Arrange
            var items = Enumerable.Range(1, 5).ToList();

            // Act
            var result = items.TakeRandom(10).ToList();

            // Assert
            Assert.Equal(items.Count, result.Count);
            Assert.True(result.All(items.Contains));
        }

        [Fact]
        public void TakeRandom_WithZeroCount_ReturnsEmptyCollection()
        {
            // Arrange
            var items = Enumerable.Range(1, 5).ToList();

            // Act
            var result = items.TakeRandom(0).ToList();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeRandom_WithEmptySource_ReturnsEmptyCollection()
        {
            // Arrange
            var items = new List<int>();

            // Act
            var result = items.TakeRandom(3).ToList();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeRandom_ReturnsItemsFromOriginalCollection()
        {
            // Arrange
            var items = new[] { "test1", "test2", "test3", "test4", "test5" };

            // Act
            var result = items.TakeRandom(3).ToList();

            // Assert
            Assert.All(result, item => Assert.Contains(item, items));
        }
    }
}
