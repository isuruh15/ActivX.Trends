using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace EleSy.ActiveX.Tools
{
    /// <summary>
    /// Core image relatad methods.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// All methods of this class are static and represent general routines
    ///             used by different image processing classes.
    /// </remarks>
    public static class Image
    {
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            //var logo = Resources.logo;

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }

                //graphics.DrawImage(logo, new Rectangle(0, 0, logo.Width, logo.Height));
            }

            return destImage;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImageSaveRatio(System.Drawing.Image image, int width, int height)
        {
            try
            {
                var scaleHeight = (double)height / (double)image.Height;
                var scaleWidth = (double)width / (double)image.Width;
                var scale = Math.Min(scaleHeight, scaleWidth);

                int newWidth = (int)Math.Floor(image.Width * scale);
                int newHeight = (int)Math.Floor(image.Height * scale);

                var destRect = new Rectangle(0, 0, newWidth, newHeight);
                var destImage = new Bitmap(newWidth, newHeight);
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    graphics.Clear(Color.Transparent);

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return destImage;
            }
            catch (Exception)
            {

            }

            return null;
        }

        /// <summary>
        /// Check if specified 8 bpp image is grayscale.
        /// 
        /// </summary>
        /// <param name="image">Image to check.</param>
        /// <returns>
        /// Returns <b>true</b> if the image is grayscale or <b>false</b> otherwise.
        /// </returns>
        /// 
        /// <remarks>
        /// The methods checks if the image is a grayscale image of 256 gradients.
        ///             The method first examines if the image's pixel format is
        ///             <see cref="T:System.Drawing.Imaging.PixelFormat">Format8bppIndexed</see>
        ///             and then it examines its palette to check if the image is grayscale or not.
        /// </remarks>
        public static bool IsGrayscale(Bitmap image)
        {
            bool flag = false;
            if (image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                flag = true;
                ColorPalette palette = image.Palette;
                for (int index = 0; index < 256; ++index)
                {
                    Color color = palette.Entries[index];
                    if ((int)color.R != index || (int)color.G != index || (int)color.B != index)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Create and initialize new 8 bpp grayscale image.
        /// 
        /// </summary>
        /// <param name="width">Image width.</param><param name="height">Image height.</param>
        /// <returns>
        /// Returns the created grayscale image.
        /// </returns>
        /// 
        /// <remarks>
        /// The method creates new 8 bpp grayscale image and initializes its palette.
        ///             Grayscale image is represented as
        ///             <see cref="T:System.Drawing.Imaging.PixelFormat">Format8bppIndexed</see>
        ///             image with palette initialized to 256 gradients of gray color.
        /// </remarks>
        public static Bitmap CreateGrayscaleImage(int width, int height)
        {
            Bitmap image = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            SetGrayscalePalette(image);
            return image;
        }

        /// <summary>
        /// Set pallete of the 8 bpp indexed image to grayscale.
        /// 
        /// </summary>
        /// <param name="image">Image to initialize.</param>
        /// <remarks>
        /// The method initializes palette of
        ///             <see cref="T:System.Drawing.Imaging.PixelFormat">Format8bppIndexed</see>
        ///             image with 256 gradients of gray color.
        /// </remarks>
        /// <exception cref="T:UnsupportedImageFormatException">Provided image is not 8 bpp indexed image.</exception>
        public static void SetGrayscalePalette(Bitmap image)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new ArgumentException("Source image is not 8 bpp image.");
            ColorPalette palette = image.Palette;
            for (int index = 0; index < 256; ++index)
                palette.Entries[index] = Color.FromArgb(index, index, index);
            image.Palette = palette;
        }

        /// <summary>
        /// Clone image.
        /// 
        /// </summary>
        /// <param name="source">Source image.</param><param name="format">Pixel format of result image.</param>
        /// <returns>
        /// Returns clone of the source image with specified pixel format.
        /// </returns>
        /// 
        /// <remarks>
        /// The original <see cref="M:System.Drawing.Bitmap.Clone(System.Drawing.Rectangle,System.Drawing.Imaging.PixelFormat)">Bitmap.Clone()</see>
        ///              does not produce the desired result - it does not create a clone with specified pixel format.
        ///              More of it, the original method does not create an actual clone - it does not create a copy
        ///              of the image. That is why this method was implemented to provide the functionality.
        /// </remarks>
        public static Bitmap Clone(Bitmap source, PixelFormat format)
        {
            if (source.PixelFormat == format)
                return Clone(source);
            int width = source.Width;
            int height = source.Height;
            Bitmap bitmap = new Bitmap(width, height, format);
            Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap);
            graphics.DrawImage((System.Drawing.Image)source, 0, 0, width, height);
            graphics.Dispose();
            return bitmap;
        }

        /// <summary>
        /// Clone image.
        /// 
        /// </summary>
        /// <param name="source">Source image.</param>
        /// <returns>
        /// Return clone of the source image.
        /// </returns>
        /// 
        /// <remarks>
        /// The original <see cref="M:System.Drawing.Bitmap.Clone(System.Drawing.Rectangle,System.Drawing.Imaging.PixelFormat)">Bitmap.Clone()</see>
        ///             does not produce the desired result - it does not create an actual clone (it does not create a copy
        ///             of the image). That is why this method was implemented to provide the functionality.
        /// </remarks>
        public static Bitmap Clone(Bitmap source)
        {
            BitmapData bitmapData = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, source.PixelFormat);
            Bitmap bitmap = Clone(bitmapData);
            source.UnlockBits(bitmapData);
            if (source.PixelFormat == PixelFormat.Format1bppIndexed || source.PixelFormat == PixelFormat.Format4bppIndexed || (source.PixelFormat == PixelFormat.Format8bppIndexed || source.PixelFormat == PixelFormat.Indexed))
            {
                ColorPalette palette1 = source.Palette;
                ColorPalette palette2 = bitmap.Palette;
                int length = palette1.Entries.Length;
                for (int index = 0; index < length; ++index)
                    palette2.Entries[index] = palette1.Entries[index];
                bitmap.Palette = palette2;
            }
            return bitmap;
        }

        /// <summary>
        /// Clone image.
        /// 
        /// </summary>
        /// <param name="sourceData">Source image data.</param>
        /// <returns>
        /// Clones image from source image data. The message does not clone pallete in the
        ///              case if the source image has indexed pixel format.
        /// </returns>
        public static Bitmap Clone(BitmapData sourceData)
        {
            int width = sourceData.Width;
            int height = sourceData.Height;
            Bitmap bitmap = new Bitmap(width, height, sourceData.PixelFormat);
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            MemTools.CopyUnmanagedMemory(bitmapdata.Scan0, sourceData.Scan0, height * sourceData.Stride);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }


        /// <summary>
        /// Load bitmap from file.
        /// 
        /// </summary>
        /// <param name="fileName">File name to load bitmap from.</param>
        /// <returns>
        /// Returns loaded bitmap.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// The method is provided as an alternative of <see cref="M:System.Drawing.Image.FromFile(System.String)"/>
        ///             method to solve the issues of locked file. The standard .NET's method locks the source file until
        ///             image's object is disposed, so the file can not be deleted or overwritten. This method workarounds the issue and
        ///             does not lock the source file.
        /// </para>
        /// 
        /// <para>
        /// Sample usage:
        /// </para>
        /// 
        /// <code>
        /// Bitmap image = FromFile( "test.jpg" );
        /// 
        /// </code>
        /// 
        /// </remarks>
        public static Bitmap FromFile(string fileName)
        {
            FileStream fileStream = (FileStream)null;
            try
            {
                fileStream = File.OpenRead(fileName);
                MemoryStream memoryStream = new MemoryStream();
                byte[] buffer = new byte[10000];
                while (true)
                {
                    int count = fileStream.Read(buffer, 0, 10000);
                    if (count != 0)
                        memoryStream.Write(buffer, 0, count);
                    else
                        break;
                }
                return (Bitmap)System.Drawing.Image.FromStream((Stream)memoryStream);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Convert bitmap with 16 bits per plane to a bitmap with 8 bits per plane.
        /// 
        /// </summary>
        /// <param name="bimap">Source image to convert.</param>
        /// <returns>
        /// Returns new image which is a copy of the source image but with 8 bits per plane.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// The routine does the next pixel format conversions:
        /// 
        /// <list type="bullet">
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format16bppGrayScale">Format16bppGrayScale</see> to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format8bppIndexed">Format8bppIndexed</see> with grayscale palette;
        /// </item>
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format48bppRgb">Format48bppRgb</see> to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format24bppRgb">Format24bppRgb</see>;
        /// </item>
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format64bppArgb">Format64bppArgb</see> to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format32bppArgb">Format32bppArgb</see>;
        /// </item>
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format64bppPArgb">Format64bppPArgb</see> to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format32bppPArgb">Format32bppPArgb</see>.
        /// </item>
        /// 
        /// </list>
        /// 
        /// </para>
        /// 
        /// </remarks>
        /// <exception cref="T:UnsupportedImageFormatException">Invalid pixel format of the source image.</exception>
        public static unsafe Bitmap Convert16bppTo8bpp(Bitmap bimap)
        {
            int width = bimap.Width;
            int height = bimap.Height;
            Bitmap bitmap;
            int num1;
            switch (bimap.PixelFormat)
            {
                case PixelFormat.Format64bppPArgb:
                    bitmap = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
                    num1 = 4;
                    break;
                case PixelFormat.Format64bppArgb:
                    bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                    num1 = 4;
                    break;
                case PixelFormat.Format16bppGrayScale:
                    bitmap = CreateGrayscaleImage(width, height);
                    num1 = 1;
                    break;
                case PixelFormat.Format48bppRgb:
                    bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                    num1 = 3;
                    break;
                default:
                    throw new ArgumentException("Invalid pixel format of the source image.");
            }
            BitmapData bitmapdata1 = bimap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bimap.PixelFormat);
            BitmapData bitmapdata2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte* numPtr1 = (byte*)bitmapdata1.Scan0.ToPointer();
            byte* numPtr2 = (byte*)bitmapdata2.Scan0.ToPointer();
            int stride1 = bitmapdata1.Stride;
            int stride2 = bitmapdata2.Stride;
            for (int index = 0; index < height; ++index)
            {
                ushort* numPtr3 = (ushort*)(numPtr1 + ((IntPtr)index).ToInt64() * stride1);
                byte* numPtr4 = numPtr2 + ((IntPtr)index).ToInt64() * stride2;
                int num2 = 0;
                int num3 = width * num1;
                while (num2 < num3)
                {
                    *numPtr4 = (byte)((uint)*numPtr3 >> 8);
                    ++num2;
                    ++numPtr3;
                    ++numPtr4;
                }
            }
            bimap.UnlockBits(bitmapdata1);
            bitmap.UnlockBits(bitmapdata2);
            return bitmap;
        }

        /// <summary>
        /// Convert bitmap with 8 bits per plane to a bitmap with 16 bits per plane.
        /// 
        /// </summary>
        /// <param name="bimap">Source image to convert.</param>
        /// <returns>
        /// Returns new image which is a copy of the source image but with 16 bits per plane.
        /// </returns>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// The routine does the next pixel format conversions:
        /// 
        /// <list type="bullet">
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format8bppIndexed">Format8bppIndexed</see> (grayscale palette assumed) to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format16bppGrayScale">Format16bppGrayScale</see>;
        /// </item>
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format24bppRgb">Format24bppRgb</see> to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format48bppRgb">Format48bppRgb</see>;
        /// </item>
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format32bppArgb">Format32bppArgb</see> to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format64bppArgb">Format64bppArgb</see>;
        /// </item>
        /// 
        /// <item>
        /// <see cref="F:System.Drawing.Imaging.PixelFormat.Format32bppPArgb">Format32bppPArgb</see> to
        ///             <see cref="F:System.Drawing.Imaging.PixelFormat.Format64bppPArgb">Format64bppPArgb</see>.
        /// </item>
        /// 
        /// </list>
        /// 
        /// </para>
        /// 
        /// </remarks>
        /// <exception cref="T:UnsupportedImageFormatException">Invalid pixel format of the source image.</exception>
        public static unsafe Bitmap Convert8bppTo16bpp(Bitmap bimap)
        {
            int width = bimap.Width;
            int height = bimap.Height;
            Bitmap bitmap;
            int num1;
            switch (bimap.PixelFormat)
            {
                case PixelFormat.Format32bppPArgb:
                    bitmap = new Bitmap(width, height, PixelFormat.Format64bppPArgb);
                    num1 = 4;
                    break;
                case PixelFormat.Format32bppArgb:
                    bitmap = new Bitmap(width, height, PixelFormat.Format64bppArgb);
                    num1 = 4;
                    break;
                case PixelFormat.Format24bppRgb:
                    bitmap = new Bitmap(width, height, PixelFormat.Format48bppRgb);
                    num1 = 3;
                    break;
                case PixelFormat.Format8bppIndexed:
                    bitmap = new Bitmap(width, height, PixelFormat.Format16bppGrayScale);
                    num1 = 1;
                    break;
                default:
                    throw new ArgumentException("Invalid pixel format of the source image.");
            }
            BitmapData bitmapdata1 = bimap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bimap.PixelFormat);
            BitmapData bitmapdata2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte* numPtr1 = (byte*)bitmapdata1.Scan0.ToPointer();
            byte* numPtr2 = (byte*)bitmapdata2.Scan0.ToPointer();
            int stride1 = bitmapdata1.Stride;
            int stride2 = bitmapdata2.Stride;
            for (int index = 0; index < height; ++index)
            {
                byte* numPtr3 = numPtr1 + ((IntPtr)index).ToInt64() * stride1;
                ushort* numPtr4 = (ushort*)(numPtr2 + ((IntPtr)index).ToInt64() * stride2);
                int num2 = 0;
                int num3 = width * num1;
                while (num2 < num3)
                {
                    *numPtr4 = (ushort)((uint)*numPtr3 << 8);
                    ++num2;
                    ++numPtr3;
                    ++numPtr4;
                }
            }
            bimap.UnlockBits(bitmapdata1);
            bitmap.UnlockBits(bitmapdata2);
            return bitmap;
        }
    }
}
