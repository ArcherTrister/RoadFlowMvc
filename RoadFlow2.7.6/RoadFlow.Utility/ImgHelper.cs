// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.ImgHelper
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace RoadFlow.Utility
{
  public class ImgHelper
  {
    public static string CutAvatar(string imgUrl, string newImgUrl, int pointX = 0, int pointY = 0, int width = 0, int height = 0)
    {
      Bitmap bitmap = (Bitmap) null;
      Image image1 = (Image) null;
      Graphics graphics = (Graphics) null;
      Image image2 = (Image) null;
      try
      {
        int thumMaxWidth = 180;
        int thumMaxHeight = 180;
        if (string.IsNullOrEmpty(imgUrl))
          return "";
        bitmap = new Bitmap(width, height);
        image1 = Image.FromFile(imgUrl);
        graphics = Graphics.FromImage((Image) bitmap);
        graphics.DrawImage(image1, new Rectangle(0, 0, width, height), new Rectangle(pointX, pointY, width, height), GraphicsUnit.Pixel);
        image2 = ImgHelper.GetThumbNailImage((Image) bitmap, thumMaxWidth, thumMaxHeight);
        EncoderParameters encoderParams = new EncoderParameters();
        long[] numArray = new long[1]{ 80L };
        EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, numArray);
        encoderParams.Param[0] = encoderParameter;
        ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
        ImageCodecInfo encoder = (ImageCodecInfo) null;
        for (int index = 0; index < imageEncoders.Length; ++index)
        {
          if (imageEncoders[index].FormatDescription.Equals("JPEG"))
          {
            encoder = imageEncoders[index];
            break;
          }
        }
        string path1 = newImgUrl;
        string filename = HttpContext.Current.Server.MapPath(path1);
        string path2 = filename.Substring(0, filename.LastIndexOf("\\"));
        if (!Directory.Exists(path2))
          Directory.CreateDirectory(path2);
        if (encoder != null)
          image2.Save(filename, encoder, encoderParams);
        else
          image2.Save(filename);
        return path1;
      }
      catch (Exception ex)
      {
        return "";
      }
      finally
      {
        bitmap.Dispose();
        image1.Dispose();
        graphics.Dispose();
        image2.Dispose();
        GC.Collect();
      }
    }

    public static Image GetThumbNailImage(Image originalImage, int thumMaxWidth, int thumMaxHeight)
    {
      Size empty = Size.Empty;
      Image image = originalImage;
      Graphics graphics = (Graphics) null;
      try
      {
        Size newSize = ImgHelper.GetNewSize(thumMaxWidth, thumMaxHeight, originalImage.Width, originalImage.Height);
        image = (Image) new Bitmap(newSize.Width, newSize.Height);
        graphics = Graphics.FromImage(image);
        graphics.DrawImage(originalImage, new Rectangle(0, 0, newSize.Width, newSize.Height), new Rectangle(0, 0, originalImage.Width, originalImage.Height), GraphicsUnit.Pixel);
      }
      catch
      {
      }
      finally
      {
        graphics?.Dispose();
      }
      return image;
    }

    public static Size GetNewSize(int maxWidth, int maxHeight, int imageOriginalWidth, int imageOriginalHeight)
    {
      double num1 = Convert.ToDouble(imageOriginalWidth);
      double num2 = Convert.ToDouble(imageOriginalHeight);
      double num3 = Convert.ToDouble(maxWidth);
      double num4 = Convert.ToDouble(maxHeight);
      double num5;
      double num6;
      if (num1 < num3 && num2 < num4)
      {
        num5 = num1;
        num6 = num2;
      }
      else if (num1 / num2 > num3 / num4)
      {
        num5 = (double) maxWidth;
        num6 = num5 * num2 / num1;
      }
      else
      {
        num6 = (double) maxHeight;
        num5 = num6 * num1 / num2;
      }
      return new Size(Convert.ToInt32(num5), Convert.ToInt32(num6));
    }
  }
}
