namespace SuperSoccer.Infrastructure.Utils
{
    /// <summary>
    /// Static class that provides Super Soccer Player Power calculation method
    /// </summary>
    public static class PlayerPowerCalculator
    {
        /// <summary>
        /// Calculates Super Soccer Player power. Power is an average between Player's Height and Player's Weight.
        /// </summary>
        /// <param name="playerHeight">Super Soccer Player's height</param>
        /// <param name="playerWeight">Super Soccer Player's weight</param>
        /// <returns></returns>
        public static double CalculatePlayerPower(double playerHeight, double playerWeight) 
        {
            return Math.Round((playerHeight + playerWeight) / 2.0, 1);
        }
    }
}
