﻿using System.Drawing;
using System.Drawing.Imaging;

namespace EleSy.ActiveX.Controls
{
    /// <summary>
    /// Picture box control for displaying an image.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// This control is inherited from System.Windows.Forms.PictureBox and is
    ///             aimed to resolve one of its issues - inability to display images with high color depth,
    ///             like 16 bpp grayscale, 48 bpp and 64 bpp color images. .NET framework does not handle
    ///             16 bpp grayscale images at all, throwing exception when user tries to display them. Color
    ///             images with 48 bpp and 64 bpp are "kind of" supported, but only maximum of 13 bits for each
    ///             color plane are allowed. Therefore this control is created, which allows to display as
    ///             16 bpp grayscale images, as 48 bpp and 64 bpp color images.
    /// </para>
    /// 
    /// <para>
    /// <note>To display high color depth images, the control does internal conversion of them
    ///             to lower color depth images - 8 bpp grayscale, 24 bpp and 32 bpp color images respectively. In
    ///             the case source image already has low color depth, it is displayed without any conversions.
    ///             </note>
    /// </para>
    /// 
    /// </remarks>
    public class PictureBox : System.Windows.Forms.PictureBox
    {
        //private System.Drawing.Image sourceImage;
        //private System.Drawing.Image convertedImage;

        /// <summary>
        /// Gets or sets the image that the PictureBox displays.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// The property is used to set image to be displayed or to get currently
        ///             displayed image.
        /// </para>
        /// 
        /// <para>
        /// <note>In the case if source image has high color depth, like 16 bpp grayscale image,
        ///             48 bpp or 64 bpp color image, it is converted to lower color depth before displaying -
        ///             to 8 bpp grayscale, 24 bpp or 32 bpp color image respectively.</note>
        /// </para>
        /// 
        /// <para>
        /// <note>During color conversion the original source image is kept unmodified, but internal
        ///             converted copy is created. The property always returns original source image.</note>
        /// </para>
        /// 
        /// </remarks>
        public new Image Image
        {
            get
            {
                return base.Image; //sourceImage;
            }
            set
            {
                var bitmap = value as Bitmap;
                if (bitmap != null && (bitmap.PixelFormat == PixelFormat.Format16bppGrayScale || bitmap.PixelFormat == PixelFormat.Format48bppRgb || bitmap.PixelFormat == PixelFormat.Format64bppArgb))
                {
                    System.Drawing.Image image = Tools.Image.Convert16bppTo8bpp(bitmap);
                    base.Image = image;
                    //convertedImage?.Dispose();
                    //convertedImage = image;
                }
                else
                    base.Image = value;
                //sourceImage = value;
            }
        }
    }
}
