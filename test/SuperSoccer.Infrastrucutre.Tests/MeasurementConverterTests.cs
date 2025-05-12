namespace SuperSoccer.Infrastrucutre.Tests
{
    public class MeasurementConverterTests
    {
        [Theory]
        [InlineData(0, 0.0)]
        [InlineData(10, 1.0)]
        [InlineData(85, 8.5)]
        [InlineData(150, 15.0)]
        public void ConvertWeightFromHgToKg_ValidInputs_ReturnsExpectedKg(int inputHg, double expectedKg)
        {
            // Act
            var result = MeasurementConverter.ConvertWeightFromHgToKg(inputHg);

            // Assert
            Assert.Equal(expectedKg, result);
        }

        [Theory]
        [InlineData(0, 0.0)]
        [InlineData(10, 100)]
        [InlineData(18, 180)]
        [InlineData(200, 2000)]
        public void ConvertHeightFromDmToCm_ValidInputs_ReturnsExpectedCentimeters(int inputDm, double expectedCentimeters)
        {
            // Act
            var result = MeasurementConverter.ConvertHeightFromDmToCm(inputDm);

            // Assert
            Assert.Equal(expectedCentimeters, result);
        }

        [Theory]
        [InlineData(-10, -1.0)]
        [InlineData(-5, -0.5)]
        public void ConvertWeightFromHgToKg_NegativeValues_ReturnsExpectedKg(int inputHg, double expectedKg)
        {
            var result = MeasurementConverter.ConvertWeightFromHgToKg(inputHg);
            Assert.Equal(expectedKg, result);
        }

        [Theory]
        [InlineData(-10, -100)]
        [InlineData(-7, -70)]
        public void ConvertHeightFromDmToM_NegativeValues_ReturnsExpectedCentimeters(int inputDm, double expectedCentimeters)
        {
            var result = MeasurementConverter.ConvertHeightFromDmToCm(inputDm);
            Assert.Equal(expectedCentimeters, result);
        }
    }
}
