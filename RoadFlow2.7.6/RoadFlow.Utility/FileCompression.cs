// Decompiled with JetBrains decompiler
// Type: RoadFlow.Utility.FileCompression
// Assembly: RoadFlow.Utility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E4D91F62-39BF-4125-A013-6EDB7CF1B4EC
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Utility.dll

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
      ZipOutputStream zipOutputStream = (ZipOutputStream) null;
      try
      {
        zipOutputStream = new ZipOutputStream((Stream) File.Create(GzipFileName));
        zipOutputStream.SetLevel(CompressionLevel);
        foreach (FileInfo fileName in fileNames)
        {
          FileStream fileStream;
          try
          {
            fileStream = fileName.Open(FileMode.Open, FileAccess.ReadWrite);
          }
          catch (Exception ex)
          {
            continue;
          }
          byte[] buffer = new byte[2048];
          int count = 2048;
          zipOutputStream.PutNextEntry(new ZipEntry(Path.GetFileName(fileName.Name))
          {
            DateTime = fileName.CreationTime > fileName.LastWriteTime ? fileName.LastWriteTime : fileName.CreationTime
          });
          while (true)
          {
            count = fileStream.Read(buffer, 0, count);
            if (count > 0)
              zipOutputStream.Write(buffer, 0, count);
            else
              break;
          }
          fileStream.Close();
          if (deleteFile)
            fileName.Delete();
        }
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
      finally
      {
        if (zipOutputStream != null)
        {
          zipOutputStream.Finish();
          zipOutputStream.Close();
        }
      }
    }

    public static void CompressDirectory(string dirPath, string GzipFileName, int CompressionLevel, bool deleteDir)
    {
      if (GzipFileName == string.Empty)
      {
        GzipFileName = dirPath.Substring(dirPath.LastIndexOf("//") + 1);
        GzipFileName = dirPath.Substring(0, dirPath.LastIndexOf("//")) + "//" + GzipFileName + ".zip";
      }
      using (ZipOutputStream zipOutputStream = new ZipOutputStream((Stream) File.Create(GzipFileName)))
      {
        zipOutputStream.SetLevel(CompressionLevel);
        Crc32 crc32 = new Crc32();
        foreach (KeyValuePair<string, DateTime> allFy in FileCompression.GetAllFies(dirPath))
        {
          FileStream fileStream = File.OpenRead(allFy.Key.ToString());
          byte[] buffer = new byte[fileStream.Length];
          fileStream.Read(buffer, 0, buffer.Length);
          ZipEntry entry = new ZipEntry(allFy.Key.Substring(dirPath.Length));
          entry.DateTime = allFy.Value;
          entry.Size = fileStream.Length;
          fileStream.Close();
          crc32.Reset();
          crc32.Update(buffer);
          entry.Crc = crc32.Value;
          zipOutputStream.PutNextEntry(entry);
          zipOutputStream.Write(buffer, 0, buffer.Length);
        }
      }
      if (!deleteDir)
        return;
      Directory.Delete(dirPath, true);
    }

    private static Dictionary<string, DateTime> GetAllFies(string dir)
    {
      Dictionary<string, DateTime> filesList = new Dictionary<string, DateTime>();
      DirectoryInfo dir1 = new DirectoryInfo(dir);
      if (!dir1.Exists)
        throw new FileNotFoundException("目录:" + dir1.FullName + "没有找到!");
      FileCompression.GetAllDirFiles(dir1, filesList);
      FileCompression.GetAllDirsFiles(dir1.GetDirectories(), filesList);
      return filesList;
    }

    private static void GetAllDirsFiles(DirectoryInfo[] dirs, Dictionary<string, DateTime> filesList)
    {
      foreach (DirectoryInfo dir in dirs)
      {
        foreach (FileInfo file in dir.GetFiles("*.*"))
          filesList.Add(file.FullName, file.LastWriteTime);
        FileCompression.GetAllDirsFiles(dir.GetDirectories(), filesList);
      }
    }

    private static void GetAllDirFiles(DirectoryInfo dir, Dictionary<string, DateTime> filesList)
    {
      foreach (FileInfo file in dir.GetFiles("*.*"))
        filesList.Add(file.FullName, file.LastWriteTime);
    }

    public static string Decompress(string zipFile, string targetPath)
    {
      try
      {
        if (!targetPath.EndsWith("\\"))
          targetPath += "\\";
        string path1 = targetPath;
        if (!Directory.Exists(path1))
          Directory.CreateDirectory(path1);
        string str = path1;
        byte[] buffer = new byte[2048];
        using (ZipInputStream zipInputStream = new ZipInputStream((Stream) File.OpenRead(zipFile)))
        {
          ZipEntry nextEntry;
          while ((nextEntry = zipInputStream.GetNextEntry()) != null)
          {
            if (nextEntry.IsDirectory)
            {
              if (!Directory.Exists(str + nextEntry.Name))
                Directory.CreateDirectory(str + nextEntry.Name);
            }
            else if (nextEntry.Name != string.Empty)
            {
              if (nextEntry.Name.Contains("//"))
              {
                string path2 = nextEntry.Name.Remove(nextEntry.Name.LastIndexOf("//") + 1);
                if (!Directory.Exists(path2))
                  Directory.CreateDirectory(str + path2);
              }
              using (FileStream fileStream = File.Create(str + nextEntry.Name))
              {
                while (true)
                {
                  int count = zipInputStream.Read(buffer, 0, buffer.Length);
                  if (count > 0)
                    fileStream.Write(buffer, 0, count);
                  else
                    break;
                }
                fileStream.Close();
              }
            }
          }
          zipInputStream.Close();
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
