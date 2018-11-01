using LitJson;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace RoadFlow.Utility
{
	public class Tools
	{
		[Obsolete("请用RoadFlow.Utility.DateTimeNew.Now", true)]
		public static DateTime DateTime
		{
			get
			{
				return DateTimeNew.Now;
			}
		}

		public static MemoryStream GetValidateImg(out string code, string bgImg = "/Images/vcodebg.png")
		{
			code = GetValidateCode();
			Random random = new Random();
			Bitmap bitmap = new Bitmap((int)Math.Ceiling((double)code.Length * 17.2), 28);
			System.Drawing.Image image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(bgImg));
			Graphics graphics = Graphics.FromImage(bitmap);
			Font font = new Font("Arial", 16f, FontStyle.Italic);
			Font font2 = new Font("Arial", 16f, FontStyle.Italic);
			new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);
			graphics.DrawImage(image, 0, 0, new Rectangle(random.Next(image.Width - bitmap.Width), random.Next(image.Height - bitmap.Height), bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
			graphics.DrawString(code, font2, Brushes.White, 0f, 1f);
			graphics.DrawString(code, font, Brushes.Green, 0f, 1f);
			int width = bitmap.Width;
			graphics.DrawLine(y1: random.Next(5, bitmap.Height), y2: random.Next(5, bitmap.Height), pen: new Pen(Color.Green, 2f), x1: 1, x2: width - 2);
			graphics.DrawRectangle(new Pen(Color.Transparent), 0, 10, bitmap.Width - 1, bitmap.Height - 1);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			return memoryStream;
		}

		private static string GetValidateCode()
		{
			string text = string.Empty;
			Random random = new Random(Guid.NewGuid().GetHashCode());
			for (int i = 0; i < 4; i++)
			{
				int num = random.Next();
				char c = (num % 2 != 0) ? ((num % 3 != 0) ? ((char)(65 + (ushort)(num % 26))) : ((char)(97 + (ushort)(num % 26)))) : ((char)(48 + (ushort)(num % 10)));
				text += ((c == '0' || c == 'O') ? "x" : c.ToString());
			}
			return text;
		}

		public static string GetIPAddress()
		{
			if (HttpContext.Current == null || HttpContext.Current.Request == null)
			{
				return "";
			}
			string text = HttpContext.Current.Request.UserHostAddress;
			if (text.IsNullOrEmpty())
			{
				text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			}
			return text;
		}

		public static string GetBrowse()
		{
			if (HttpContext.Current == null || HttpContext.Current.Request == null)
			{
				return "";
			}
			return HttpContext.Current.Request.Browser.Type;
		}

		public static string GetOSName()
		{
			if (HttpContext.Current == null || HttpContext.Current.Request == null)
			{
				return "";
			}
			string result = HttpContext.Current.Request.Browser.Platform;
			string userAgent = HttpContext.Current.Request.UserAgent;
			if (userAgent.Contains("NT 10"))
			{
				result = "Windows10";
			}
			else if (userAgent.Contains("NT 6.3"))
			{
				result = "Windows8.1";
			}
			else if (userAgent.Contains("NT 6.2"))
			{
				result = "Windows8";
			}
			else if (userAgent.Contains("NT 6.1"))
			{
				result = "Windows7";
			}
			else if (userAgent.Contains("NT 6.0"))
			{
				result = "WindowsVista";
			}
			else if (userAgent.Contains("NT 5.2"))
			{
				result = "WindowsServer2003";
			}
			else if (userAgent.Contains("NT 5.1"))
			{
				result = "WindowsXP";
			}
			else if (userAgent.Contains("NT 5"))
			{
				result = "Windows2000";
			}
			else if (userAgent.Contains("NT 4"))
			{
				result = "WindowsNT4.0";
			}
			else if (userAgent.Contains("Me"))
			{
				result = "WindowsMe";
			}
			else if (userAgent.Contains("98"))
			{
				result = "Windows98";
			}
			else if (userAgent.Contains("95"))
			{
				result = "Windows95";
			}
			else if (userAgent.Contains("Mac"))
			{
				result = "Mac";
			}
			else if (userAgent.Contains("Unix"))
			{
				result = "UNIX";
			}
			else if (userAgent.Contains("Linux"))
			{
				result = "Linux";
			}
			else if (userAgent.Contains("SunOS"))
			{
				result = "SunOS";
			}
			return result;
		}

		public static string GetPagerHtml(long recordCount, int pageSize, int pageNumber, string queryString)
		{
			if (pageSize <= 0)
			{
				pageSize = GetPageSize();
			}
			long num = (recordCount <= 0) ? 1 : ((recordCount % pageSize == 0L) ? (recordCount / pageSize) : (recordCount / pageSize + 1));
			long num2 = pageNumber;
			if (num2 < 1)
			{
				num2 = 1L;
			}
			else if (num2 > num)
			{
				num2 = num;
			}
			if (num <= 1)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder(1500);
			string empty = string.Empty;
			int num3 = 10;
			stringBuilder.Append("<div>");
			stringBuilder.Append("<span style='margin-right:15px;'>共 " + recordCount.ToString() + " 条  每页 <input type='text' id='tnt_count' title='输入数字可改变每页显示条数' class='pagertxt' onchange=\"javascript:_toPage_" + empty + "(" + num2.ToString() + ",this.value);\" value='" + pageSize.ToString() + "' /> 条  ");
			stringBuilder.Append("转到 <input type='text' id='paernumbertext' title='输入数字可跳转页' value=\"" + num2.ToString() + "\" onchange=\"javascript:_toPage_" + empty + "(this.value," + pageSize.ToString() + ");\" class='pagertxt'/> 页</span>");
			if (num2 > 1)
			{
				stringBuilder.Append("<a class=\"pager\" href=\"javascript:_toPage_" + empty + "(" + (num2 - 1).ToString() + "," + pageSize.ToString() + ");\"><span class=\"pagerarrow\">«</span></a>");
			}
			if (num2 >= num3 / 2 + 3)
			{
				stringBuilder.Append("<a class=\"pager\" href=\"javascript:_toPage_" + empty + "(1," + pageSize.ToString() + ");\">1…</a>");
			}
			else
			{
				stringBuilder.Append("<a class=\"" + ((1 == num2) ? "pagercurrent" : "pager") + "\" href=\"javascript:_toPage_" + empty + "(1," + pageSize.ToString() + ");\">1</a>");
			}
			long num4 = num2 - num3 / 2;
			long num5 = num2 + num3 / 2;
			if (num4 < 2)
			{
				num5 += 2 - num4;
				num4 = 2L;
			}
			if (num5 > num - 1)
			{
				num4 -= num5 - (num - 1);
				num5 = num - 1;
			}
			if (num4 < 2)
			{
				num4 = 2L;
			}
			for (long num6 = num4; num6 <= num5; num6++)
			{
				stringBuilder.Append("<a class=\"" + ((num6 == num2) ? "pagercurrent" : "pager") + "\" href=\"javascript:_toPage_" + empty + "(" + num6.ToString() + "," + pageSize.ToString() + ");\">" + num6.ToString() + "</a>");
			}
			if (num2 <= num - num3 / 2)
			{
				stringBuilder.Append("<a class=\"pager\" href=\"javascript:_toPage_" + empty + "(" + num.ToString() + "," + pageSize.ToString() + ");\">…" + num.ToString() + "</a>");
			}
			else if (num > 1)
			{
				stringBuilder.Append("<a class=\"" + ((num == num2) ? "pagercurrent" : "pager") + "\" href=\"javascript:_toPage_" + empty + "(" + num.ToString() + "," + pageSize.ToString() + ");\">" + num.ToString() + "</a>");
			}
			if (num2 < num)
			{
				stringBuilder.Append("<a class=\"pager\" href=\"javascript:_toPage_" + empty + "(" + (num2 + 1).ToString() + "," + pageSize.ToString() + ");\"><span class=\"pagerarrow\">»</span></a>");
			}
			stringBuilder.Append("</div>");
			stringBuilder.Append("<script type=\"text/javascript\" lanuage=\"javascript\">");
			stringBuilder.Append("function _toPage_" + empty + "(page,size){");
			stringBuilder.Append("var par=\"" + queryString + "\";");
			stringBuilder.Append("window.location=\"?pagenumber=\"+page+\"&pagesize=\"+size+par;");
			stringBuilder.Append("}");
			stringBuilder.Append("</script>");
			return stringBuilder.ToString();
		}

		public static int GetPageSize()
		{
			string str = HttpContext.Current.Request["pagesize"];
			if (!str.IsInt())
			{
				HttpCookie httpCookie = HttpContext.Current.Request.Cookies["roadflowpagesize"];
				if (httpCookie != null)
				{
					str = httpCookie.Value;
				}
			}
			int test;
			int num = str.IsInt(out test) ? test : 15;
			if (num <= 0)
			{
				num = 15;
			}
			HttpContext.Current.Response.Cookies.Add(new HttpCookie("roadflowpagesize")
			{
				Value = num.ToString(),
				Expires = DateTimeNew.Now.AddYears(2)
			});
			return num;
		}

		public static int GetPageNumber()
		{
			int test;
			if (!(HttpContext.Current.Request["pagenumber"] ?? "1").IsInt(out test))
			{
				return 1;
			}
			return test;
		}

		public static ListItem[] GetListItems(IList<string[]> list, string value, bool showEmpty = false, string emptyTitle = "")
		{
			List<ListItem> list2 = new List<ListItem>();
			if (showEmpty)
			{
				list2.Add(new ListItem(emptyTitle, ""));
			}
			foreach (string[] item in list)
			{
				if (item.Length >= 2)
				{
					ListItem listItem = new ListItem(item[0], item[1]);
					listItem.Selected = (!value.IsNullOrEmpty() && value == item[1] && !list2.Exists((ListItem p) => p.Selected));
					list2.Add(listItem);
				}
			}
			return list2.ToArray();
		}

		public static ListItem[] GetListItems(IList<string> list, string value, bool showEmpty = false, string emptyTitle = "")
		{
			List<string[]> list2 = new List<string[]>();
			foreach (string item in list)
			{
				list2.Add(new string[2]
				{
					item,
					item
				});
			}
			return GetListItems(list2, value, showEmpty, emptyTitle);
		}

		public static string GetOptionsString(ListItem[] items)
		{
			StringBuilder stringBuilder = new StringBuilder(items.Length * 50);
			foreach (ListItem listItem in items)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>", listItem.Value.Replace("\"", "'"), listItem.Selected ? "selected=\"selected\"" : "");
				stringBuilder.Append(listItem.Text);
				stringBuilder.Append("</option>");
			}
			return stringBuilder.ToString();
		}

		public static string GetCheckBoxString(ListItem[] items, string name, string[] values, string otherAttr = "")
		{
			StringBuilder stringBuilder = new StringBuilder(items.Length * 50);
			foreach (ListItem listItem in items)
			{
				string arg = Guid.NewGuid().ToString("N");
				stringBuilder.AppendFormat("<input type=\"checkbox\" value=\"{0}\" {1} id=\"{2}\" name=\"{3}\" {4} style=\"vertical-align:middle\" />", listItem.Value.Replace("\"", "'"), (listItem.Selected || (values != null && values.Contains(listItem.Value))) ? "checked=\"checked\"" : "", string.Format("{0}_{1}", name, arg), name, otherAttr);
				stringBuilder.AppendFormat("<label style=\"vertical-align:middle;margin-right:2px;\" for=\"{0}\">", string.Format("{0}_{1}", name, arg));
				stringBuilder.Append(listItem.Text);
				stringBuilder.Append("</label>");
			}
			return stringBuilder.ToString();
		}

		public static string GetRadioString(ListItem[] items, string name, string otherAttr = "")
		{
			StringBuilder stringBuilder = new StringBuilder(items.Length * 50);
			foreach (ListItem listItem in items)
			{
				string arg = Guid.NewGuid().ToString("N");
				stringBuilder.AppendFormat("<input type=\"radio\" value=\"{0}\" {1} id=\"{2}\" name=\"{3}\" {4} style=\"vertical-align:middle\" />", listItem.Value.Replace("\"", "'"), listItem.Selected ? "checked=\"checked\"" : "", string.Format("{0}_{1}", name, arg), name, otherAttr);
				stringBuilder.AppendFormat("<label style=\"vertical-align:middle;margin-right:2px;\" for=\"{0}\">", string.Format("{0}_{1}", name, arg));
				stringBuilder.Append(listItem.Text);
				stringBuilder.Append("</label>");
			}
			return stringBuilder.ToString();
		}

		public static ListItem[] GetYesNoListItems(string value, bool showEmpty = false, string emptyString = "")
		{
			List<string[]> list = new List<string[]>();
			list.Add(new string[2]
			{
				"是",
				"1"
			});
			list.Add(new string[2]
			{
				"否",
				"0"
			});
			return GetListItems(list, value, showEmpty, emptyString);
		}

		public static string GetSqlInString(string str, bool isSingleQuotes = true, string split = ",")
		{
			return GetSqlInString(str.Split(new string[1]
			{
				split
			}, StringSplitOptions.RemoveEmptyEntries), isSingleQuotes);
		}

		public static string GetSqlInString<T>(T[] strArray, bool isSingleQuotes = true)
		{
			StringBuilder stringBuilder = new StringBuilder(strArray.Length * 40);
			for (int i = 0; i < strArray.Length; i++)
			{
				T val = strArray[i];
				if (!val.ToString().IsNullOrEmpty())
				{
					if (isSingleQuotes)
					{
						stringBuilder.Append("'");
					}
					stringBuilder.Append(val.ToString().Trim());
					if (isSingleQuotes)
					{
						stringBuilder.Append("'");
					}
					stringBuilder.Append(",");
				}
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public static int[] GetRandomNum(int count, int minValue, int maxValue)
		{
			byte[] array = new byte[4];
			new RNGCryptoServiceProvider().GetBytes(array);
			Random random = new Random(BitConverter.ToInt32(array, 0));
			int num = maxValue - minValue + 1;
			byte[] array2 = new byte[num];
			random.NextBytes(array2);
			int[] array3 = new int[num];
			for (int i = 0; i < num; i++)
			{
				array3[i] = i + minValue;
			}
			Array.Sort(array2, array3);
			int[] array4 = new int[count];
			Array.Copy(array3, array4, count);
			return array4;
		}

		public static string GetRandomString(int length = 5)
		{
			string text = string.Empty;
			byte[] array = new byte[4];
			new RNGCryptoServiceProvider().GetBytes(array);
			Random random = new Random(BitConverter.ToInt32(array, 0));
			for (int i = 0; i < length + 1; i++)
			{
				int num = random.Next();
				text += ((char)((num % 2 != 0) ? ((ushort)(65 + (ushort)(num % 26))) : ((ushort)(48 + (ushort)(num % 10))))).ToString();
			}
			return text;
		}

		public static string GetRandomLetter(int length = 2)
		{
			string text = string.Empty;
			byte[] array = new byte[4];
			new RNGCryptoServiceProvider().GetBytes(array);
			Random random = new Random(BitConverter.ToInt32(array, 0));
			for (int i = 0; i < length; i++)
			{
				int num = random.Next();
				text += ((char)(ushort)(65 + (ushort)(num % 26))).ToString();
			}
			return text;
		}

		public static string GetFileSize(string file)
		{
			if (!File.Exists(file))
			{
				return "";
			}
			return (new FileInfo(file).Length / 1000).ToString("###,###");
		}

		public static string DataTableToJsonString(DataTable dt)
		{
			JsonData jsonData = new JsonData();
			foreach (DataRow row in dt.Rows)
			{
				JsonData jsonData2 = new JsonData();
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					JsonData jsonData3 = new JsonData();
					jsonData3 = row[i].ToString();
					jsonData2.Add(jsonData3);
				}
				jsonData.Add(jsonData2);
			}
			return jsonData.ToJson();
		}

		public static object ExecuteCsharpMethod(string methodName, object methodParams = null)
		{
			try
			{
				Assembly assembly = Assembly.Load(methodName.Substring(0, methodName.IndexOf('.')));
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(methodName);
				string name = methodName.Substring(fileNameWithoutExtension.Length + 1);
				Type type = assembly.GetType(fileNameWithoutExtension, true);
				object obj = Activator.CreateInstance(type, false);
				MethodInfo method = type.GetMethod(name);
				if (method != null)
				{
					return method.Invoke(obj, (methodParams == null) ? null : new object[1]
					{
						methodParams
					});
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		public static object ExecuteCsharpCode(string code)
		{
			try
			{
				CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
				CompilerParameters options = new CompilerParameters();
				return cSharpCodeProvider.CompileAssemblyFromSource(options, BuildCode(code)).CompiledAssembly.GetType("C").GetMethod("T").Invoke(null, null);
			}
			catch
			{
				return null;
			}
		}

		private static string BuildCode(string code)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("using System;");
			stringBuilder.Append("public class C{ public static Object T(){");
			stringBuilder.Append(code);
			stringBuilder.Append("}}");
			return stringBuilder.ToString();
		}

		public static string DataTableToHtml(DataTable dt)
		{
			if (dt.Columns.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<table class=\"listtable\" style=\"WORD-BREAK:break-all;WORD-WRAP:break-word\">");
			stringBuilder.Append("<thead>");
			stringBuilder.Append("<tr>");
			foreach (DataColumn column in dt.Columns)
			{
				stringBuilder.Append("<th>" + column.ColumnName + "</th>");
			}
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</thead>");
			stringBuilder.Append("<tbody>");
			foreach (DataRow row in dt.Rows)
			{
				stringBuilder.Append("<tr>");
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					stringBuilder.Append("<td>" + row[i].ToString().HtmlEncode() + "</td>");
				}
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</tbody>");
			stringBuilder.Append("</table>");
			return stringBuilder.ToString();
		}

		public static DateTime JavaLongToDateTime(int time_JAVA_Long)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			long ticks = long.Parse(time_JAVA_Long.ToString() + "0000000");
			TimeSpan value = new TimeSpan(ticks);
			return dateTime.Add(value);
		}

		public static string[] GetImageUrlFromHTML(string sHtmlText)
		{
			MatchCollection matchCollection = new Regex("<img\\b[^<>]*?\\bsrc[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*[\"']?[\\s\\t\\r\\n]*(?<imgUrl>[^\\s\\t\\r\\n\"'<>]*)[^<>]*?/?[\\s\\t\\r\\n]*>", RegexOptions.IgnoreCase).Matches(sHtmlText);
			int num = 0;
			string[] array = new string[matchCollection.Count];
			foreach (Match item in matchCollection)
			{
				array[num++] = item.Groups["imgUrl"].Value;
			}
			return array;
		}

		public static string RemoveHTML(string Htmlstring)
		{
			Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "([\\r\\n])[\\s]+", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "¡", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "¢", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "£", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "©", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&#(\\d+);", "", RegexOptions.IgnoreCase);
			Htmlstring.Replace("<", "");
			Htmlstring.Replace(">", "");
			Htmlstring.Replace("\r\n", "");
			Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
			return Htmlstring;
		}

		public static bool IsPhoneAccess()
		{
			string text = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
			Regex regex = new Regex("(android|bb\\d+|meego).+mobile|avantgo|bada\\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			Regex regex2 = new Regex("1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\\-(n|u)|c55\\/|capi|ccwa|cdm\\-|cell|chtm|cldc|cmd\\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\\-s|devi|dica|dmob|do(c|p)o|ds(12|\\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\\-|_)|g1 u|g560|gene|gf\\-5|g\\-mo|go(\\.w|od)|gr(ad|un)|haie|hcit|hd\\-(m|p|t)|hei\\-|hi(pt|ta)|hp( i|ip)|hs\\-c|ht(c(\\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\\-(20|go|ma)|i230|iac( |\\-|\\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\\/)|klon|kpt |kwc\\-|kyo(c|k)|le(no|xi)|lg( g|\\/(k|l|u)|50|54|\\-[a-w])|libw|lynx|m1\\-w|m3ga|m50\\/|ma(te|ui|xo)|mc(01|21|ca)|m\\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\\-2|po(ck|rt|se)|prox|psio|pt\\-g|qa\\-a|qc(07|12|21|32|60|\\-[2-7]|i\\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\\-|oo|p\\-)|sdk\\/|se(c(\\-|0|1)|47|mc|nd|ri)|sgh\\-|shar|sie(\\-|m)|sk\\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\\-|v\\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\\-|tdg\\-|tel(i|m)|tim\\-|t\\-mo|to(pl|sh)|ts(70|m\\-|m3|m5)|tx\\-9|up(\\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\\-|your|zeto|zte\\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			Regex regex3 = new Regex(".*wechat.*(\\r\\n)?", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			if (!regex.IsMatch(text) && !regex2.IsMatch(text.Substring(0, 4)))
			{
				return regex3.IsMatch(text);
			}
			return true;
		}

		public static string GetDateTimeDifferString(DateTime dt1, DateTime dt2)
		{
			TimeSpan timeSpan = dt2 - dt1;
			int days = timeSpan.Days;
			if (days >= 1)
			{
				return days.ToString() + "天";
			}
			int hours = timeSpan.Hours;
			if (hours >= 1)
			{
				return hours.ToString() + "小时";
			}
			int minutes = timeSpan.Minutes;
			if (minutes >= 1)
			{
				return minutes.ToString() + "分钟";
			}
			int seconds = timeSpan.Seconds;
			if (seconds >= 1)
			{
				return seconds.ToString() + "秒";
			}
			return "";
		}
	}
}
