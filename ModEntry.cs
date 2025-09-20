using System;
using StardewModdingAPI;
using StardewValley;

namespace NoVSync
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        }

        private void OnGameLaunched(object sender, StardewModdingAPI.Events.GameLaunchedEventArgs e)
        {
            try
            {
                Game1.graphics.SynchronizeWithVerticalRetrace = false;
                Game1.IsFixedTimeStep = true;
                Game1.TargetElapsedTime = TimeSpan.FromMilliseconds(16.67);

                Monitor.Log("V-Sync disabled successfully!", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Monitor.Log($"Error disabling V-Sync: {ex}", LogLevel.Error);
            }
        }
    }
}