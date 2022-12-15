using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestMipmap {
  [Test]
  public void TestPNGImage() {
    var data = new byte[] {
      0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D, 0x49, 0x48, 0x44, 0x52,
      0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x08, 0x06, 0x00, 0x00, 0x00, 0x72, 0xB6, 0x0D,
      0x24, 0x00, 0x00, 0x00, 0x1B, 0x49, 0x44, 0x41, 0x54, 0x08, 0xD7, 0x63, 0x60, 0xF8, 0xCF, 0xD0,
      0xC0, 0xC0, 0xF0, 0xDF, 0x81, 0xE1, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x33, 0x30, 0xEC, 0x07, 0x00,
      0x43, 0x18, 0x08, 0x79, 0xEB, 0xE3, 0x55, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x49, 0x45, 0x4E, 0x44,
      0xAE, 0x42, 0x60, 0x82
    };

    var texture = AsyncImageLoader.CreateFromImage(data);
    var mipmapLevel0 = texture.GetPixelData<int>(0);
    var mipmapLevel1 = texture.GetPixelData<int>(1);

    Assert.That(texture.format, Is.EqualTo(TextureFormat.RGBA32));
    Assert.That(texture.width, Is.EqualTo(2));
    Assert.That(texture.height, Is.EqualTo(2));
    Assert.That(texture.mipmapCount, Is.EqualTo(2));

    Assert.That(mipmapLevel0.Length, Is.EqualTo(4));
    Assert.That(mipmapLevel0[0], Is.EqualTo(unchecked((int)0xFF_FF_FF_FF)));
    Assert.That(mipmapLevel0[1], Is.EqualTo(unchecked((int)0xBF_00_00_FF)));
    Assert.That(mipmapLevel0[2], Is.EqualTo(unchecked((int)0x80_00_FF_00)));
    Assert.That(mipmapLevel0[3], Is.EqualTo(unchecked((int)0x40_FF_00_00)));

    Assert.That(mipmapLevel1.Length, Is.EqualTo(1));
    Assert.That(mipmapLevel1[0], Is.EqualTo(unchecked((int)0x9F_7F_7F_7F)));
  }

  [Test]
  public void TestJPEGImage() {
    var data = new byte[] {
      0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01, 0x01, 0x01, 0x01, 0x2C,
      0x01, 0x2C, 0x00, 0x00, 0xFF, 0xDB, 0x00, 0x43, 0x00, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0xFF, 0xDB, 0x00, 0x43, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01,
      0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0xFF, 0xC9,
      0x00, 0x11, 0x08, 0x00, 0x02, 0x00, 0x02, 0x03, 0x01, 0x11, 0x00, 0x02, 0x11, 0x01, 0x03, 0x11,
      0x01, 0xFF, 0xCC, 0x00, 0x0A, 0x00, 0x10, 0x10, 0x05, 0x01, 0x10, 0x11, 0x05, 0xFF, 0xDA, 0x00,
      0x0C, 0x03, 0x01, 0x00, 0x02, 0x11, 0x03, 0x11, 0x00, 0x3F, 0x00, 0xFF, 0x00, 0xED, 0x83, 0x1F,
      0x33, 0xBE, 0xF8, 0x94, 0x15, 0x70, 0xB2, 0xBB, 0x79, 0x32, 0xF4, 0x33, 0x76, 0x95, 0xE5, 0x72,
      0x12, 0x80, 0xC7, 0xBB, 0xD4, 0xFB, 0xA3, 0x62, 0x4D, 0xF7, 0x60, 0x15, 0xAF, 0x52, 0x24, 0xCD,
      0xD2, 0xBF, 0xC1, 0x1C, 0xF3, 0x9A, 0x08, 0x87, 0xEE, 0x86, 0xB1, 0xD7, 0xE2, 0xC8, 0x9D, 0x24,
      0x55, 0xC1, 0x6D, 0xFF, 0x00, 0x4F, 0x49, 0x19, 0x7B, 0x42, 0xB3, 0x28, 0xB9, 0xB6, 0x05, 0x0E,
      0x5F, 0xCF, 0x84, 0x92, 0x6C, 0xB5, 0x54, 0x89, 0xBF, 0xFE, 0xE0, 0x0F, 0x33, 0x5E, 0x63, 0xB3,
      0x89, 0xEB, 0x11, 0x5A, 0x95, 0xD5, 0x09, 0x39, 0x2C, 0xB6, 0x04, 0x72, 0x3D, 0xF4, 0x9B, 0xB4,
      0x58, 0x49, 0x64, 0x46, 0x1D, 0x65, 0x60, 0x14, 0xBD, 0x04, 0x5C, 0xA4, 0xF0, 0x82, 0xAF, 0x10,
      0xC8, 0xFD, 0x60, 0x8E, 0x9C, 0x55, 0x8C, 0xA4, 0xFF, 0x00, 0x3C, 0xAE, 0x16, 0xBB, 0x53, 0xC2,
      0x59, 0x82, 0xDD, 0xAD, 0x3F, 0x7D, 0x68, 0x04, 0x6D, 0x7E, 0xD3, 0x6B, 0xA9, 0xA2, 0x01, 0x7F,
      0x6E, 0xA9, 0xBE, 0xE9, 0x3E, 0xB6, 0x24, 0x9E, 0xAB, 0xAD, 0xD8, 0xE7, 0x60, 0x64, 0x73, 0xC3,
      0x8F, 0xDC, 0xDC, 0xC2, 0x2F, 0x35, 0xF1, 0xEB, 0x2F, 0xA2, 0x75, 0x61, 0x01, 0xDF, 0x11, 0xF4,
      0xD0, 0xC1, 0x62, 0x5A, 0x28, 0x22, 0xEC, 0x05, 0x2A, 0x41, 0x14, 0xC2, 0xA0, 0x4D, 0xB7, 0x9F,
      0x3C, 0xF5, 0xD8, 0x90, 0xF1, 0x6F, 0x87, 0x09, 0xBE, 0xA9, 0xFD, 0x44, 0xBD, 0x59, 0x0C, 0x8B,
      0x03, 0xF8, 0xB1, 0x0E, 0x07, 0x73, 0x3C, 0x82, 0xDA, 0x09, 0x83, 0x35, 0x03, 0x90, 0x3E, 0xBC,
      0x65, 0x4B, 0x44, 0xAF, 0x2C, 0x80, 0xFF, 0xD9
    };

    var texture = AsyncImageLoader.CreateFromImage(data);
    var mipmapLevel0 = texture.GetPixelData<byte>(0);
    var mipmapLevel1 = texture.GetPixelData<byte>(1);

    Assert.That(texture.format, Is.EqualTo(TextureFormat.RGB24));
    Assert.That(texture.width, Is.EqualTo(2));
    Assert.That(texture.height, Is.EqualTo(2));
    Assert.That(texture.mipmapCount, Is.EqualTo(2));

    Assert.That(mipmapLevel0.Length, Is.EqualTo(3 * 4));
    Assert.That(mipmapLevel0[0], Is.EqualTo(0XF7));
    Assert.That(mipmapLevel0[1], Is.EqualTo(0XFF));
    Assert.That(mipmapLevel0[2], Is.EqualTo(0XFF));
    Assert.That(mipmapLevel0[3], Is.EqualTo(0XF7));
    Assert.That(mipmapLevel0[4], Is.EqualTo(0X07));
    Assert.That(mipmapLevel0[5], Is.EqualTo(0X08));
    Assert.That(mipmapLevel0[6], Is.EqualTo(0X00));
    Assert.That(mipmapLevel0[7], Is.EqualTo(0XFF));
    Assert.That(mipmapLevel0[8], Is.EqualTo(0X00));
    Assert.That(mipmapLevel0[9], Is.EqualTo(0X00));
    Assert.That(mipmapLevel0[10], Is.EqualTo(0X08));
    Assert.That(mipmapLevel0[11], Is.EqualTo(0XFF));

    Assert.That(mipmapLevel1.Length, Is.EqualTo(3));
    Assert.That(mipmapLevel1[0], Is.EqualTo(0x7B));
    Assert.That(mipmapLevel1[1], Is.EqualTo(0x83));
    Assert.That(mipmapLevel1[2], Is.EqualTo(0x81));
  }
}