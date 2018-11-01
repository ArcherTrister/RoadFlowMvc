using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;

namespace RoadFlow.Utility
{
	public abstract class FileCompression
	{
		public static bool CompressFile(List<FileInfo> fileNames, string GzipFileName, int CompressionLevel, bool deleteFile)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			ZipOutputStream val = null;
			try
			{
				val = new ZipOutputStream((Stream)File.Create(GzipFileName));
				val.SetLevel(CompressionLevel);
				foreach (FileInfo fileName in fileNames)
				{
					FileStream fileStream = null;
					try
					{
						fileStream = fileName.Open(FileMode.Open, FileAccess.ReadWrite);
					}
					catch (Exception)
					{
						continue;
					}
					byte[] buffer = new byte[2048];
					int num = 2048;
					ZipEntry val2 = new ZipEntry(Path.GetFileName(fileName.Name));
					val2.set_DateTime((fileName.CreationTime > fileName.LastWriteTime) ? fileName.LastWriteTime : fileName.CreationTime);
					val.PutNextEntry(val2);
					while (true)
					{
						num = fileStream.Read(buffer, 0, num);
						if (num <= 0)
						{
							break;
						}
						((Stream)val).Write(buffer, 0, num);
					}
					fileStream.Close();
					if (deleteFile)
					{
						fileName.Delete();
					}
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				if (val != null)
				{
					val.Finish();
					((Stream)val).Close();
				}
			}
		}

		public static void CompressDirectory(string dirPath, string GzipFileName, int CompressionLevel, bool deleteDir)
		{
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Expected O, but got Unknown
			if (GzipFileName == string.Empty)
			{
				GzipFileName = dirPath.Substring(dirPath.LastIndexOf("//") + 1);
				GzipFileName = dirPath.Substring(0, dirPath.LastIndexOf("//")) + "//" + GzipFileName + ".zip";
			}
			ZipOutputStream val = new ZipOutputStream((Stream)File.Create(GzipFileName));
			try
			{
				val.SetLevel(CompressionLevel);
				Crc32 val2 = new Crc32();
				foreach (KeyValuePair<string, DateTime> allFy in GetAllFies(dirPath))
				{
					FileStream fileStream = File.OpenRead(allFy.Key.ToString());
					byte[] array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
					ZipEntry val3 = new ZipEntry(allFy.Key.Substring(dirPath.Length));
					val3.set_DateTime(allFy.Value);
					val3.set_Size(fileStream.Length);
					fileStream.Close();
					val2.Reset();
					val2.Update(array);
					val3.set_Crc(val2.get_Value());
					val.PutNextEntry(val3);
					((Stream)val).Write(array, 0, array.Length);
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
			if (deleteDir)
			{
				Directory.Delete(dirPath, true);
			}
		}

		private static Dictionary<string, DateTime> GetAllFies(string dir)
		{
			Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
			DirectoryInfo directoryInfo = new DirectoryInfo(dir);
			if (!directoryInfo.Exists)
			{
				throw new FileNotFoundException("目录:" + directoryInfo.FullName + "没有找到!");
			}
			GetAllDirFiles(directoryInfo, dictionary);
			GetAllDirsFiles(directoryInfo.GetDirectories(), dictionary);
			return dictionary;
		}

		private static void GetAllDirsFiles(DirectoryInfo[] dirs, Dictionary<string, DateTime> filesList)
		{
			foreach (DirectoryInfo directoryInfo in dirs)
			{
				FileInfo[] files = directoryInfo.GetFiles("*.*");
				foreach (FileInfo fileInfo in files)
				{
					filesList.Add(fileInfo.FullName, fileInfo.LastWriteTime);
				}
				GetAllDirsFiles(directoryInfo.GetDirectories(), filesList);
			}
		}

		private static void GetAllDirFiles(DirectoryInfo dir, Dictionary<string, DateTime> filesList)
		{
			FileInfo[] files = dir.GetFiles("*.*");
			foreach (FileInfo fileInfo in files)
			{
				filesList.Add(fileInfo.FullName, fileInfo.LastWriteTime);
			}
		}

		public static string Decompress(string zipFile, string targetPath)
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			try
			{
				if (!targetPath.EndsWith("\\"))
				{
					targetPath += "\\";
				}
				string text = targetPath;
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string str = text;
				byte[] array = new byte[2048];
				int num = 2048;
				ZipEntry val = null;
				ZipInputStream val2 = new ZipInputStream((Stream)File.OpenRead(zipFile));
				try
				{
					while ((val = val2.GetNextEntry()) != null)
					{
						if (val.get_IsDirectory())
						{
							if (!Directory.Exists(str + val.get_Name()))
							{
								Directory.CreateDirectory(str + val.get_Name());
							}
						}
						else if (val.get_Name() != string.Empty)
						{
							if (val.get_Name().Contains("//"))
							{
								string text2 = val.get_Name().Remove(val.get_Name().LastIndexOf("//") + 1);
								if (!Directory.Exists(text2))
								{
									Directory.CreateDirectory(str + text2);
								}
							}
							using (FileStream fileStream = File.Create(str + val.get_Name()))
							{
								while (true)
								{
									num = ((Stream)val2).Read(array, 0, array.Length);
									if (num <= 0)
									{
										break;
									}
									fileStream.Write(array, 0, num);
								}
								fileStream.Close();
							}
						}
					}
					((Stream)val2).Close();
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
				return "1";
			}
			catch (Exception ex)
			{
				return ex.Message + ex.StackTrace;
			}
		}
	}
}
