using System;
using System.Runtime.InteropServices;

public static partial class AsyncImageLoader {
  public static class FreeImage {
    public enum Format {
      FIF_UNKNOWN = -1,
      FIF_BMP = 0,
      FIF_ICO = 1,
      FIF_JPEG = 2,
      FIF_JNG = 3,
      FIF_KOALA = 4,
      FIF_LBM = 5,
      FIF_IFF = FIF_LBM,
      FIF_MNG = 6,
      FIF_PBM = 7,
      FIF_PBMRAW = 8,
      FIF_PCD = 9,
      FIF_PCX = 10,
      FIF_PGM = 11,
      FIF_PGMRAW = 12,
      FIF_PNG = 13,
      FIF_PPM = 14,
      FIF_PPMRAW = 15,
      FIF_RAS = 16,
      FIF_TARGA = 17,
      FIF_TIFF = 18,
      FIF_WBMP = 19,
      FIF_PSD = 20,
      FIF_CUT = 21,
      FIF_XBM = 22,
      FIF_XPM = 23,
      FIF_DDS = 24,
      FIF_GIF = 25,
      FIF_HDR = 26,
      FIF_FAXG3 = 27,
      FIF_SGI = 28,
      FIF_EXR = 29,
      FIF_J2K = 30,
      FIF_JP2 = 31,
      FIF_PFM = 32,
      FIF_PICT = 33,
      FIF_RAW = 34,
      FIF_WEBP = 35,
      FIF_JXR = 36
    }

    internal enum Type {
      /// <summary>
      /// unknown type
      /// </summary>
      FIT_UNKNOWN = 0,
      /// <summary>
      /// standard image : 1-, 4-, 8-, 16-, 24-, 32-bit
      /// </summary>
      FIT_BITMAP = 1,
      /// <summary>
      /// array of unsigned short : unsigned 16-bit
      /// </summary>
      FIT_UINT16 = 2,
      /// <summary>
      /// array of short : signed 16-bit
      /// </summary>
      FIT_INT16 = 3,
      /// <summary>
      /// array of unsigned long : unsigned 32-bit
      /// </summary>
      FIT_UINT32 = 4,
      /// <summary>
      /// array of long : signed 32-bit
      /// </summary>
      FIT_INT32 = 5,
      /// <summary>
      /// array of float : 32-bit IEEE floating point
      /// </summary>
      FIT_FLOAT = 6,
      /// <summary>
      /// array of double : 64-bit IEEE floating point
      /// </summary>
      FIT_DOUBLE = 7,
      /// <summary>
      /// array of FICOMPLEX : 2 x 64-bit IEEE floating point
      /// </summary>
      FIT_COMPLEX = 8,
      /// <summary>
      /// 48-bit RGB image : 3 x 16-bit
      /// </summary>
      FIT_RGB16 = 9,
      /// <summary>
      /// 64-bit RGBA image : 4 x 16-bit
      /// </summary>
      FIT_RGBA16 = 10,
      /// <summary>
      /// 96-bit RGB float image : 3 x 32-bit IEEE floating point
      /// </summary>
      FIT_RGBF = 11,
      /// <summary>
      /// 128-bit RGBA float image : 4 x 32-bit IEEE floating point
      /// </summary>
      FIT_RGBAF = 12
    }

    [System.Flags]
    internal enum LoadFlags {
      /// <summary>
      /// Default option for all types.
      /// </summary>
      DEFAULT = 0,
      /// <summary>
      /// Load the image as a 256 color image with ununsed palette entries, if it's 16 or 2 color.
      /// </summary>
      GIF_LOAD256 = 1,
      /// <summary>
      /// 'Play' the GIF to generate each frame (as 32bpp) instead of returning raw frame data when loading.
      /// </summary>
      GIF_PLAYBACK = 2,
      /// <summary>
      /// Convert to 32bpp and create an alpha channel from the AND-mask when loading.
      /// </summary>
      ICO_MAKEALPHA = 1,
      /// <summary>
      /// Load the file as fast as possible, sacrificing some quality.
      /// </summary>
      JPEG_FAST = 0x0001,
      /// <summary>
      /// Load the file with the best quality, sacrificing some speed.
      /// </summary>
      JPEG_ACCURATE = 0x0002,
      /// <summary>
      /// Load separated CMYK "as is" (use | to combine with other load flags).
      /// </summary>
      JPEG_CMYK = 0x0004,
      /// <summary>
      /// Load and rotate according to Exif 'Orientation' tag if available.
      /// </summary>
      JPEG_EXIFROTATE = 0x0008,
      /// <summary>
      /// Load the bitmap sized 768 x 512.
      /// </summary>
      PCD_BASE = 1,
      /// <summary>
      /// Load the bitmap sized 384 x 256.
      /// </summary>
      PCD_BASEDIV4 = 2,
      /// <summary>
      /// Load the bitmap sized 192 x 128.
      /// </summary>
      PCD_BASEDIV16 = 3,
      /// <summary>
      /// Avoid gamma correction.
      /// </summary>
      PNG_IGNOREGAMMA = 1,
      /// <summary>
      /// If set the loader converts RGB555 and ARGB8888 -> RGB888.
      /// </summary>
      TARGA_LOAD_RGB888 = 1,
      /// <summary>
      /// Reads tags for separated CMYK.
      /// </summary>
      TIFF_CMYK = 0x0001,
      /// <summary>
      /// Tries to load the JPEG preview image, embedded in
      /// Exif Metadata or load the image as RGB 24-bit if no 
      /// preview image is available.
      /// </summary>
      RAW_PREVIEW = 0x1,
      /// <summary>
      /// Loads the image as RGB 24-bit.
      /// </summary>
      RAW_DISPLAY = 0x2,
    }
	
	public enum Filter
	{
	  /// <summary>
	  /// Box, pulse, Fourier window, 1st order (constant) b-spline
	  /// </summary>
	  FILTER_BOX = 0,

	  /// <summary>
	  /// Mitchell & Netravali's two-param cubic filter
	  /// </summary>
	  FILTER_BICUBIC = 1,

	  /// <summary>
	  /// ! Bilinear filter
	  /// </summary>
	  FILTER_BILINEAR = 2,

	  /// <summary>
	  /// ! 4th order (cubic) b-spline
	  /// </summary>
	  FILTER_BSPLINE = 3,

	  /// <summary>
	  /// ! Catmull-Rom spline, Overhauser spline
	  /// </summary>
	  FILTER_CATMULLROM = 4,

	  /// <summary>
	  /// ! Lanczos3 filter
	  /// </summary>
	  FILTER_LANCZOS3 = 5
	};

    const string FreeImageLibrary = "FreeImage";

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_IsLittleEndian")]
    internal static extern bool IsLittleEndian();

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetFileTypeFromMemory")]
    internal static extern Format GetFileTypeFromMemory(IntPtr memory, int size);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_OpenMemory")]
    internal static extern IntPtr OpenMemory(IntPtr data, uint size_in_bytes);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_CloseMemory")]
    internal static extern IntPtr CloseMemory(IntPtr data);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_LoadFromMemory")]
    internal static extern IntPtr LoadFromMemory(Format format, IntPtr stream, int flags);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_Unload")]
    internal static extern void Unload(IntPtr dib);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_ConvertToRawBits")]
    internal static extern void ConvertToRawBits(IntPtr bits, IntPtr dib, int pitch, uint bpp, uint red_mask, uint green_mask, uint blue_mask, bool topdown);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetWidth")]
    internal static extern uint GetWidth(IntPtr handle);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetHeight")]
    internal static extern uint GetHeight(IntPtr handle);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetImageType")]
    internal static extern Type GetImageType(IntPtr dib);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetBPP")]
    internal static extern int GetBPP(IntPtr dib);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetBits")]
    internal static extern IntPtr GetBits(IntPtr dib);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetLine")]
    internal static extern int GetLine(IntPtr dib);

    [DllImport(FreeImageLibrary, EntryPoint = "FreeImage_GetPitch")]
    internal static extern int GetPitch(IntPtr dib);
	
	[DllImport(FreeImageLibrary, EntryPoint = "FreeImage_Rescale")]
	internal static extern IntPtr Rescale(IntPtr dib, int dst_width, int dst_height, Filter filter = Filter.FILTER_BOX);
  }
}
