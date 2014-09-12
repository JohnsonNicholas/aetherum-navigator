using System;

namespace TwilightShards.AetherumExplorerW
{
    /// <summary>
    /// This enum tracks flags for creation. Used in a setting.
    /// </summary>
    public enum AetherumGenerationFlags
    {
        /// <summary>
        /// This says we use only normal stellar opts as defined by GURPS
        /// </summary>
        NormalGeneration = 1,

        /// <summary>
        /// This allows us to add extra options such as any flare star, black holes, etc.
        /// </summary>
        ExpandedGeneration = 2,
    }

}
