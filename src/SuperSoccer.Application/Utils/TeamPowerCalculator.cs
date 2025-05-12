namespace SuperSoccer.Application.Utils
{
    /// <summary>
    /// Static class to calculate TeamPower
    /// </summary>
    public static class TeamPowerCalculator
    {
        /// <summary>
        /// Calculates Super Soccer team power
        /// </summary>
        /// <param name="players">List of team players</param>
        /// <returns>Returns Super Soccer team power.</returns>
        public static double CalculateTeamPower(List<AssignedPlayer> players)
        {
            return Math.Round(players.Sum(player => player.Power), 1);
        }
    }
}
