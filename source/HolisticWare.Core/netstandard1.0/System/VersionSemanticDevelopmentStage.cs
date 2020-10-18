using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    /// <summary>
    /// A list of development stages.
    /// </summary>
    public enum VersionSemanticDevelopmentStage
    {
        /// <summary>
        /// This is the default or unspecified value.
        /// </summary>
        None = 0,
        /// <summary>
        /// <para>
        /// Usually akin to a prototype, this has either very little
        /// functionality, is a mock-up, or is still otherwise in the
        /// design stages.
        /// </para>
        /// </summary>
        PreAlpha = 1,
        /// <summary>
        /// This typically means that work on major features is still
        /// ongoing.
        /// </summary>
        Alpha = 2,
        /// <summary>
        /// This typically means that major features are complete, though
        /// not necessarily bug-free or tested, and may or may not mean
        /// that minor features are done or tested.
        /// </summary>
        Beta = 3,
        /// <summary>
        /// This typically means that all planned features or changes are
        /// either done or cut, as well as tested and mostly ready.  Code
        /// should be mainly stable.
        /// </summary>
        RC = 4,
        /// <summary>
        /// This typically means a shipping or production version.
        /// </summary>
        Final = 5
    }
}
