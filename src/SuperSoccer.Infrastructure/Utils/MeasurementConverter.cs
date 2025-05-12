namespace SuperSoccer.Infrastructure.Utils
{
    /// <summary>
    /// Static class that provide measurements converters
    /// </summary>
    public static class MeasurementConverter
    {
        /// <summary>
        /// Converts weight from hg to kg
        /// </summary>
        /// <param name="weightInHectograms">Weight in hg</param>
        /// <returns>Returns weight in kg</returns>
        public static double ConvertWeightFromHgToKg(int weightInHectograms) 
        {
            return weightInHectograms / 10.0;
        }

        /// <summary>
        /// Converts height from dm to cm
        /// </summary>
        /// <param name="heightInDecimeters">Height in dm</param>
        /// <returns>Returns height in cm</returns>
        public static double ConvertHeightFromDmToCm(int heightInDecimeters)
        {
            return heightInDecimeters * 10.0;
        }
    }
}
