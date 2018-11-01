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
			Bitmap bitmap = null;
			Image image = null;
			Graphics graphics = null;
			Image image2 = null;
			try
			{
				int thumMaxWidth = 180;
				int thumMaxHeight = 180;
				if (!string.IsNullOrEmpty(imgUrl))
				{
					bitmap = new Bitmap(width, height);
					image = Image.FromFile(imgUrl);
					graphics = Graphics.FromImage(bitmap);
					graphics.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(pointX, pointY, width, height), GraphicsUnit.Pixel);
					image2 = GetThumbNailImage(bitmap, thumMaxWidth, thumMaxHeight);
					EncoderParameters encoderParameters = new EncoderParameters();
					EncoderParameter encoderParameter = new EncoderParameter(value: new long[1]
					{
						80L
					}, encoder: Encoder.Quality);
					encoderParameters.Param[0] = encoderParameter;
					ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
					ImageCodecInfo imageCodecInfo = null;
					for (int i = 0; i < imageEncoders.Length; i++)
					{
						if (imageEncoders[i].FormatDescription.Equals("JPEG"))
						{
							imageCodecInfo = imageEncoders[i];
							break;
						}
					}
					string text = HttpContext.Current.Server.MapPath(newImgUrl);
					string path = text.Substring(0, text.LastIndexOf("\\"));
					if (!Directory.Exists(path))
					{
						Directory.CreateDirectory(path);
					}
					if (imageCodecInfo != null)
					{
						image2.Save(text, imageCodecInfo, encoderParameters);
					}
					else
					{
						image2.Save(text);
					}
					return newImgUrl;
				}
				return "";
			}
			catch (Exception)
			{
				return "";
			}
			finally
			{
				bitmap.Dispose();
				image.Dispose();
				graphics.Dispose();
				image2.Dispose();
				GC.Collect();
			}
		}

		public static Image GetThumbNailImage(Image originalImage, int thumMaxWidth, int thumMaxHeight)
		{
			Size empty = Size.Empty;
			Image image = originalImage;
			Graphics graphics = null;
			try
			{
				empty = GetNewSize(thumMaxWidth, thumMaxHeight, originalImage.Width, originalImage.Height);
				image = new Bitmap(empty.Width, empty.Height);
				graphics = Graphics.FromImage(image);
				graphics.DrawImage(originalImage, new Rectangle(0, 0, empty.Width, empty.Height), new Rectangle(0, 0, originalImage.Width, originalImage.Height), GraphicsUnit.Pixel);
				return image;
			}
			catch
			{
				return image;
			}
			finally
			{
				if (graphics != null)
				{
					graphics.Dispose();
					graphics = null;
				}
			}
		}

		public static Size GetNewSize(int maxWidth, int maxHeight, int imageOriginalWidth, int imageOriginalHeight)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = Convert.ToDouble(imageOriginalWidth);
			double num4 = Convert.ToDouble(imageOriginalHeight);
			double num5 = Convert.ToDouble(maxWidth);
			double num6 = Convert.ToDouble(maxHeight);
			if (num3 < num5 && num4 < num6)
			{
				num = num3;
				num2 = num4;
			}
			else if (num3 / num4 > num5 / num6)
			{
				num = (double)maxWidth;
				num2 = num * num4 / num3;
			}
			else
			{
				num2 = (double)maxHeight;
				num = num2 * num3 / num4;
			}
			return new Size(Convert.ToInt32(num), Convert.ToInt32(num2));
		}
	}
}
