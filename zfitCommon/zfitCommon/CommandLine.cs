using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    ///   CommandLine class.
    /// </summary>
    /// <remarks>
    ///   namespace Zephry.
    /// </remarks>
    public class CommandLine
    {
        #region Constructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="CommandLine"/> class.
        /// </summary>
        public CommandLine()
        {
            string[] vArgArray = Environment.GetCommandLineArgs();
            Array.ForEach(Environment.GetCommandLineArgs(), vArg => { });
        }

        #endregion
    }
}
