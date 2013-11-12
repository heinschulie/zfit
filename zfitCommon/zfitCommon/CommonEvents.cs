using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    ///   ObjectChangedHandler delegate.
    /// </summary>
    /// <remarks>
    ///   The method signature that can be hooked to the event.
    /// </remarks>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ObjectChangedEventArgs"/> instance containing the event data.</param>
    public delegate void ObjectChangedHandler(object sender, ObjectChangedEventArgs e);
    /// <summary>
    ///   CommonEvents static class.
    /// </summary>
    /// <remarks> 
    ///   namespace Zephry.
    /// </remarks>
    public static class CommonEvents
    {
        /// <summary>
        /// Fired by classes that change objects.
        /// </summary>
        public static event ObjectChangedHandler ObjectChanged;

        /// <summary>
        ///   Called when object changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Zephry.ObjectChangedEventArgs"/> instance containing the event data.</param>
        public static void OnObjectChanged(object sender, ObjectChangedEventArgs e)
        {
            if (ObjectChanged != null)
            {
                ObjectChanged(sender, e);
            }
        }
    }
}
