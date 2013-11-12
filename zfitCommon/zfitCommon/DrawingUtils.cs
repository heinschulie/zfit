using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Zephry
{
    /// <summary>
    ///   DrawingUtils static class.
    /// </summary>
    /// <remarks>
    ///   namespace Zephry.
    /// </remarks>
    public static class DrawingUtils
    {

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x10;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath,
        uint dwFileAttributes,
        ref SHFILEINFO psfi,
        uint cbSizeFileInfo,
        uint uFlags);

        #region Bitmap FilledBitmap
        /// <summary>
        /// Return a Bitmap of the specified width and height, with a border of the specified thickness and color,
        /// and filled with the specified color
        /// </summary>
        /// <param name="aWidth">The width of the bitmap</param>
        /// <param name="aHeight">The height of the bitmap</param>
        /// <param name="aBorderWidth">The thickness of the border</param>
        /// <param name="aBorderColor">The border color</param>
        /// <param name="aBackgroundColor">The fill color</param>
        /// <returns></returns>
        public static Bitmap FilledBitmap(int aWidth, int aHeight, int aBorderWidth, Color aBorderColor, Color aBackgroundColor)
        {
            var vBitmap = new Bitmap(aWidth, aHeight);
            for (int x = 0; x < vBitmap.Width; x++)
                for (int y = 0; y < vBitmap.Height; y++)
                    vBitmap.SetPixel(x, y, aBorderColor);
            for (int x = aBorderWidth; x < vBitmap.Width - aBorderWidth; x++)
                for (int y = aBorderWidth; y < vBitmap.Height - aBorderWidth; y++)
                    vBitmap.SetPixel(x, y, aBackgroundColor);
            return vBitmap;
        }
        #endregion

        #region Image LoadFromByteArray
        /// <summary>
        /// Return an Image from an array of bytes. If the array is empty, returns an alternate image.
        /// </summary>
        /// <param name="aByteArray">The byte array containing the serialized image</param>
        /// <param name="aAlternateImage">A alternate image that is returned if the Byte array is empty</param>
        /// <returns>
        /// The Image reference
        /// </returns>
        public static Image LoadFromByteArray(byte[] aByteArray, Image aAlternateImage)
        {
            if (aByteArray == null || aByteArray.Length < 1)
            {
                return aAlternateImage;
            }

            using (var vMemoryStream = new MemoryStream(aByteArray))
            {
                return (Image.FromStream(vMemoryStream));
            }
        }
        #endregion

        #region Image Resize
        /// <summary>
        /// Return a resized image with an argument size and aspect ratio
        /// </summary>
        /// <param name="aImage">An image.</param>
        /// <param name="aNewSize">A new size.</param>
        /// <param name="aKeepAspectRatio">Keep aspect ratio if set to <c>true</c></param>
        /// <returns></returns>
        public static Image Resize(Image aImage, Size aNewSize, bool aKeepAspectRatio = true)
        {
            int vNewWidth;
            int vNewHeight;
            if (aKeepAspectRatio)
            {
                int vOrigWidth = aImage.Width;
                int vOrigHeight = aImage.Height;
                float vPercentWidth = (float)aNewSize.Width / (float)vOrigWidth;
                float vPercentHeight = (float)aNewSize.Height / (float)vOrigHeight;
                float percent = vPercentHeight < vPercentWidth ? vPercentHeight : vPercentWidth;
                vNewWidth = (int)(vOrigWidth * percent);
                vNewHeight = (int)(vOrigHeight * percent);
            }
            else
            {
                vNewWidth = aNewSize.Width;
                vNewHeight = aNewSize.Height;
            }
            Image newImage = new Bitmap(vNewWidth, vNewHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(aImage, 0, 0, vNewWidth, vNewHeight);
            }
            return newImage;
        }
        #endregion

        #region Icon GetExtensionIcon
        public static Icon GetExtensionIcon(string aFileExtension, bool largeIcon)
        {
            string vFileName = String.Format("*.{0}", aFileExtension);

            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImg;
            if (largeIcon)
            {
                hImg = SHGetFileInfo(vFileName, FILE_ATTRIBUTE_NORMAL, ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                SHGFI_ICON |
                SHGFI_LARGEICON |
                SHGFI_USEFILEATTRIBUTES);
            }
            else
            {
                hImg = SHGetFileInfo(vFileName, FILE_ATTRIBUTE_NORMAL, ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                SHGFI_ICON |
                SHGFI_SMALLICON |
                SHGFI_USEFILEATTRIBUTES);
            }
            try
            {
                return Icon.FromHandle(shinfo.hIcon);
            }
            catch
            {
                return null;
            }
        } 
        #endregion

    }
}
