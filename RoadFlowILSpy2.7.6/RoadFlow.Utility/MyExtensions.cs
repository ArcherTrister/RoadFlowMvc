using LitJson;
using Microsoft.VisualBasic;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

public static class MyExtensions
{
	private class CompareText : IEqualityComparer<string>
	{
		private StringComparison m_comparisonType
		{
			get;
			set;
		}

		public int GetHashCode(string t)
		{
			return t.GetHashCode();
		}

		public CompareText(StringComparison comparisonType)
		{
			m_comparisonType = comparisonType;
		}

		public bool Equals(string x, string y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			return x.Equals(y, m_comparisonType);
		}
	}

	public static bool IsDecimal(this string str)
	{
		decimal result;
		return decimal.TryParse(str, out result);
	}

	public static bool IsDecimal(this string str, out decimal test)
	{
		return decimal.TryParse(str, out test);
	}

	public static bool IsDouble(this string str)
	{
		double result;
		return double.TryParse(str, out result);
	}

	public static bool IsDouble(this string str, out double test)
	{
		return double.TryParse(str, out test);
	}

	public static string ToFormatString(this decimal str)
	{
		string text = str.ToString();
		if (text.IndexOf('.') < 0)
		{
			return str.ToString("#,##0");
		}
		return str.ToString("#,##0" + ".".PadRight(text.Substring(text.IndexOf('.')).Length, '0'));
	}

	public static double Add(this double d1, double d2)
	{
		return (double)((decimal)d1 + (decimal)d2);
	}

	public static double sub(this double d1, double d2)
	{
		return (double)((decimal)d1 - (decimal)d2);
	}

	public static double mul(this double d1, double d2)
	{
		return (double)((decimal)d1 * (decimal)d2);
	}

	public static double div(this double d1, double d2)
	{
		if (d2 != 0.0)
		{
			return (double)((decimal)d1 / (decimal)d2);
		}
		return 0.0;
	}

	public static bool IsInt(this string str)
	{
		int result;
		return int.TryParse(str, out result);
	}

	public static bool IsInt(this string str, out int test)
	{
		return int.TryParse(str, out test);
	}

	public static string Join1<T>(this T[] arr, string split = ",")
	{
		StringBuilder stringBuilder = new StringBuilder(arr.Length * 36);
		for (int i = 0; i < arr.Length; i++)
		{
			stringBuilder.Append(arr[i].ToString());
			if (i < arr.Length - 1)
			{
				stringBuilder.Append(split);
			}
		}
		return stringBuilder.ToString();
	}

	public static string RemoveSpace(this string str)
	{
		if (str.IsNullOrEmpty())
		{
			return "";
		}
		return str.Replace("", " ").Replace("\r", "").Replace("\n", "");
	}

	public static string Trim1(this string str)
	{
		if (str.IsNullOrEmpty())
		{
			return "";
		}
		return str.Trim();
	}

	public static bool IsFontIco(this string str)
	{
		return str.Trim1().StartsWith("fa");
	}

	public static bool IsLong(this string str)
	{
		long result;
		return long.TryParse(str, out result);
	}

	public static bool IsLong(this string str, out long test)
	{
		return long.TryParse(str, out test);
	}

	public static bool IsDateTime(this string str)
	{
		if (str.IsDecimal())
		{
			return false;
		}
		DateTime result;
		return DateTime.TryParse(str, out result);
	}

	public static bool IsDateTime(this string str, out DateTime test)
	{
		if (str.IsDecimal())
		{
			test = DateTime.MinValue;
			return false;
		}
		return DateTime.TryParse(str, out test);
	}

	public static bool IsGuid(this string str)
	{
		Guid result;
		return Guid.TryParse(str, out result);
	}

	public static bool IsGuid(this string str, out Guid test)
	{
		return Guid.TryParse(str, out test);
	}

	public static bool IsEmptyGuid(this Guid guid)
	{
		return guid == Guid.Empty;
	}

	public static int ToInt32(this Guid guid)
	{
		return Math.Abs(guid.GetHashCode());
	}

	public static bool IsUrl(this string str)
	{
		if (str.IsNullOrEmpty())
		{
			return false;
		}
		string pattern = "^(http|https|ftp|rtsp|mms):(\\/\\/|\\\\\\\\)[A-Za-z0-9%\\-_@]+\\.[A-Za-z0-9%\\-_@]+[A-Za-z0-9\\.\\/=\\?%\\-&_~`@:\\+!;]*$";
		return Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase);
	}

	public static bool IsEmail(this string str)
	{
		return Regex.IsMatch(str, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
	}

	public static bool In(this int i, params int[] ints)
	{
		foreach (int num in ints)
		{
			if (i == num)
			{
				return true;
			}
		}
		return false;
	}

	public static object DBValueOrNull(this string str)
	{
		if (str.IsNullOrEmpty())
		{
			return null;
		}
		return str;
	}

	public static decimal ToDecimal(this string str, int decimals)
	{
		decimal result;
		if (!decimal.TryParse(str, out result))
		{
			return decimal.Zero;
		}
		return decimal.Round(result, decimals, MidpointRounding.AwayFromZero);
	}

	public static decimal ToDecimal(this string str)
	{
		decimal result;
		if (!decimal.TryParse(str, out result))
		{
			return decimal.Zero;
		}
		return result;
	}

	public static decimal Round(this decimal dec, int decimals = 2)
	{
		return Math.Round(dec, decimals, MidpointRounding.AwayFromZero);
	}

	public static double ToDouble(this string str, int digits)
	{
		double result;
		if (!double.TryParse(str, out result))
		{
			return 0.0;
		}
		return result.Round(digits);
	}

	public static double ToDouble(this string str)
	{
		double result;
		if (!double.TryParse(str, out result))
		{
			return 0.0;
		}
		return result;
	}

	public static double Round(this double value, int decimals)
	{
		if (value < 0.0)
		{
			return Math.Round(value + 5.0 / Math.Pow(10.0, (double)(decimals + 1)), decimals, MidpointRounding.AwayFromZero);
		}
		return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
	}

	public static short ToShort(this string str)
	{
		short result;
		short.TryParse(str, out result);
		return result;
	}

	public static int? ToIntOrNull(this string str)
	{
		int result;
		if (int.TryParse(str, out result))
		{
			return result;
		}
		return null;
	}

	public static int ToInt(this string str)
	{
		int result;
		int.TryParse(str, out result);
		return result;
	}

	public static int ToInt(this string str, int defaultValue)
	{
		int result;
		if (!int.TryParse(str, out result))
		{
			return defaultValue;
		}
		return result;
	}

	public static long ToLong(this string str)
	{
		long result;
		long.TryParse(str, out result);
		return result;
	}

	public static short ToInt16(this string str)
	{
		short result;
		short.TryParse(str, out result);
		return result;
	}

	public static int ToInt32(this string str)
	{
		int result;
		int.TryParse(str, out result);
		return result;
	}

	public static long ToInt64(this string str)
	{
		long result;
		long.TryParse(str, out result);
		return result;
	}

	public static DateTime ToDateTime(this string str)
	{
		DateTime result;
		DateTime.TryParse(str, out result);
		return result;
	}

	public static DateTime? ToDateTimeOrNull(this string str)
	{
		DateTime result;
		if (DateTime.TryParse(str, out result))
		{
			return result;
		}
		return null;
	}

	public static Guid ToGuid(this string str)
	{
		Guid result;
		if (Guid.TryParse(str, out result))
		{
			return result;
		}
		return Guid.Empty;
	}

	public static bool ToBoolean(this string str)
	{
		bool result;
		if (!bool.TryParse(str, out result))
		{
			return false;
		}
		return result;
	}

	public static string DateFormat(this object date, string format = "yyyy-MM-dd")
	{
		if (date == null)
		{
			return string.Empty;
		}
		DateTime test;
		if (!date.ToString().IsDateTime(out test))
		{
			return date.ToString();
		}
		return test.ToString(format);
	}

	public static bool IsNullOrEmpty(this string str)
	{
		if (!string.IsNullOrWhiteSpace(str))
		{
			return string.IsNullOrEmpty(str);
		}
		return true;
	}

	public static string ToString(this IList<string> strList, char split)
	{
		return strList.ToString(split.ToString());
	}

	public static string ToString(this IList<string> strList, string split)
	{
		StringBuilder stringBuilder = new StringBuilder(strList.Count * 10);
		for (int i = 0; i < strList.Count; i++)
		{
			stringBuilder.Append(strList[i]);
			if (i < strList.Count - 1)
			{
				stringBuilder.Append(split);
			}
		}
		return stringBuilder.ToString();
	}

	public static string ReplaceSql(this string str)
	{
		str = str.Replace("'", "").Replace("--", " ").Replace(";", "");
		return str;
	}

	public static string ReplaceSelectSql(this string str)
	{
		if (str.IsNullOrEmpty())
		{
			return "";
		}
		str = str.Replace1("DELETE ", "").Replace1("UPDATE ", "").Replace1("INSERT ", "")
			.Replace1("TRUNCATE TABLE", "")
			.Replace1("DROP", "");
		return str;
	}

	public static string Replace1(this string str, string oldString, string newString)
	{
		if (!str.IsNullOrEmpty())
		{
			return Strings.Replace(str, oldString, newString, 1, -1, CompareMethod.Text);
		}
		return "";
	}

	public static string ToChineseSpell(this string strText)
	{
		int length = strText.Length;
		string text = "";
		for (int i = 0; i < length; i++)
		{
			text += strText.Substring(i, 1).getSpell();
		}
		return text.ToLower();
	}

	public static string getSpell(this string cnChar)
	{
		byte[] bytes = Encoding.Default.GetBytes(cnChar);
		if (bytes.Length > 1)
		{
			byte num = bytes[0];
			int num2 = bytes[1];
			int num3 = (num << 8) + num2;
			int[] array = new int[26]
			{
				45217,
				45253,
				45761,
				46318,
				46826,
				47010,
				47297,
				47614,
				48119,
				48119,
				49062,
				49324,
				49896,
				50371,
				50614,
				50622,
				50906,
				51387,
				51446,
				52218,
				52698,
				52698,
				52698,
				52980,
				53689,
				54481
			};
			for (int i = 0; i < 26; i++)
			{
				int num4 = 55290;
				if (i != 25)
				{
					num4 = array[i + 1];
				}
				if (array[i] <= num3 && num3 < num4)
				{
					return Encoding.Default.GetString(new byte[1]
					{
						(byte)(65 + i)
					});
				}
			}
			return "x";
		}
		return cnChar;
	}

	public static string Interruption(this string str, int len, string show)
	{
		ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
		int num = 0;
		string text = "";
		byte[] bytes = aSCIIEncoding.GetBytes(str);
		for (int i = 0; i < bytes.Length; i++)
		{
			num = ((bytes[i] != 63) ? (num + 1) : (num + 2));
			try
			{
				text += str.Substring(i, 1);
			}
			catch
			{
				break;
			}
			if (num > len)
			{
				break;
			}
		}
		if (Encoding.Default.GetBytes(str).Length > len)
		{
			text += show;
		}
		text = text.Replace("&nbsp;", " ");
		text = text.Replace("&lt;", "<");
		text = text.Replace("&gt;", ">");
		return text.Replace('\n'.ToString(), "<br>");
	}

	public static string CutString(this string str, int len, string show = "...")
	{
		return str.Interruption(len, show);
	}

	public static string Left(this string str, int len)
	{
		if (str == null || len < 1)
		{
			return "";
		}
		if (len < str.Length)
		{
			return str.Substring(0, len);
		}
		return str;
	}

	public static string Right(this string str, int len)
	{
		if (str == null || len < 1)
		{
			return "";
		}
		if (len < str.Length)
		{
			return str.Substring(str.Length - len);
		}
		return str;
	}

	public static int Size(this string str)
	{
		return Encoding.Default.GetBytes(str).Length;
	}

	public static string RemoveHTML(this string Htmlstring)
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

	public static string RemoveScript(this string html)
	{
		if (html.IsNullOrEmpty())
		{
			return string.Empty;
		}
		Regex regex = new Regex("<script[\\s\\S]+</script *>", RegexOptions.IgnoreCase);
		Regex regex2 = new Regex(" href *= *[\\s\\S]*script *:", RegexOptions.IgnoreCase);
		Regex regex3 = new Regex(" on[\\s\\S]*=", RegexOptions.IgnoreCase);
		Regex regex4 = new Regex("<iframe[\\s\\S]+</iframe *>", RegexOptions.IgnoreCase);
		Regex regex5 = new Regex("<frameset[\\s\\S]+</frameset *>", RegexOptions.IgnoreCase);
		html = regex.Replace(html, "");
		html = regex2.Replace(html, "");
		html = regex3.Replace(html, " _disibledevent=");
		html = regex4.Replace(html, "");
		html = regex5.Replace(html, "");
		return html;
	}

	public static string RemovePageTag(this string html)
	{
		if (html.IsNullOrEmpty())
		{
			return string.Empty;
		}
		Regex regex = new Regex("<!DOCTYPE[^>]*>", RegexOptions.IgnoreCase);
		Regex regex2 = new Regex("<html\\s*", RegexOptions.IgnoreCase);
		Regex regex3 = new Regex("<head[\\s\\S]+</head\\s*>", RegexOptions.IgnoreCase);
		Regex regex4 = new Regex("<body\\s*", RegexOptions.IgnoreCase);
		Regex regex5 = new Regex("<form\\s*", RegexOptions.IgnoreCase);
		Regex regex6 = new Regex("</(form|body|head|html)>", RegexOptions.IgnoreCase);
		html = regex.Replace(html, "");
		html = regex2.Replace(html, "<html\u3000 ");
		html = regex3.Replace(html, "");
		html = regex4.Replace(html, "<body\u3000 ");
		html = regex5.Replace(html, "<form\u3000 ");
		html = regex6.Replace(html, "</$1\u3000>");
		return html;
	}

	public static string GetImg(this string text)
	{
		string result = string.Empty;
		Match match = new Regex("<img\\s+[^>]*\\s*src\\s*=\\s*([']?)(?<url>\\S+)'?[^>]*>", RegexOptions.Compiled).Match(text.ToLower());
		if (match.Success)
		{
			result = match.Result("${url}").Replace("\"", "").Replace("'", "");
		}
		return result;
	}

	public static string[] GetImgs(this string text)
	{
		List<string> list = new List<string>();
		Match match = new Regex("<img\\s+[^>]*\\s*src\\s*=\\s*([']?)(?<url>\\S+)'?[^>]*>", RegexOptions.Compiled).Match(text.ToLower());
		while (match.Success)
		{
			list.Add(match.Result("${url}").Replace("\"", "").Replace("'", ""));
			match = match.NextMatch();
		}
		return list.ToArray();
	}

	public static string GetRandom(int length)
	{
		string text = string.Empty;
		Random random = new Random();
		for (int i = 0; i < length + 1; i++)
		{
			int num = random.Next();
			text += ((char)((num % 2 != 0) ? ((ushort)(65 + (ushort)(num % 26))) : ((ushort)(48 + (ushort)(num % 10))))).ToString();
		}
		return text;
	}

	public static bool InPunctuation(this string str)
	{
		char[] array = str.ToCharArray();
		foreach (char c in array)
		{
			if (char.IsPunctuation(c) && c != '_')
			{
				return true;
			}
		}
		return false;
	}

	public static string RemovePunctuationOrEmpty(this string str)
	{
		StringBuilder stringBuilder = new StringBuilder(str.Length);
		char[] array = str.ToCharArray();
		foreach (char c in array)
		{
			if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c))
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static string ToDateWeekString(this DateTime date)
	{
		string str = string.Empty;
		switch (date.DayOfWeek)
		{
		case DayOfWeek.Friday:
			str = "五";
			break;
		case DayOfWeek.Monday:
			str = "一";
			break;
		case DayOfWeek.Saturday:
			str = "六";
			break;
		case DayOfWeek.Sunday:
			str = "日";
			break;
		case DayOfWeek.Thursday:
			str = "四";
			break;
		case DayOfWeek.Tuesday:
			str = "二";
			break;
		case DayOfWeek.Wednesday:
			str = "三";
			break;
		}
		return date.ToString("yyyy年M月d日 ") + "星期" + str;
	}

	public static string ToDateTimeWeekString(this DateTime date)
	{
		string str = string.Empty;
		switch (date.DayOfWeek)
		{
		case DayOfWeek.Friday:
			str = "五";
			break;
		case DayOfWeek.Monday:
			str = "一";
			break;
		case DayOfWeek.Saturday:
			str = "六";
			break;
		case DayOfWeek.Sunday:
			str = "日";
			break;
		case DayOfWeek.Thursday:
			str = "四";
			break;
		case DayOfWeek.Tuesday:
			str = "二";
			break;
		case DayOfWeek.Wednesday:
			str = "三";
			break;
		}
		return date.ToString("yyyy年M月d日H时m分") + " 星期" + str;
	}

	public static string HtmlEncode(this string str)
	{
		return HttpContext.Current.Server.HtmlEncode(str);
	}

	public static string UrlEncode(this string str)
	{
		if (!str.IsNullOrEmpty())
		{
			return HttpUtility.UrlEncode(str.Replace("+", "%2B"));
		}
		return string.Empty;
	}

	public static string UrlDecode(this string str)
	{
		if (!str.IsNullOrEmpty())
		{
			return HttpUtility.UrlDecode(str);
		}
		return string.Empty;
	}

	public static string MapPathExt(this HttpServerUtility Server, string path)
	{
		if (path.StartsWith("\\\\") || path.Contains(":"))
		{
			return path;
		}
		return Server.MapPath(path);
	}

	public static void SetCDataValue(this XElement element, string value)
	{
		element.RemoveNodes();
		element.Add(new XCData(value));
	}

	public static bool Contains(this string source, string value, StringComparison comparisonType)
	{
		if (source == null || value == null)
		{
			return false;
		}
		if (value == "")
		{
			return true;
		}
		return source.IndexOf(value, comparisonType) >= 0;
	}

	public static bool Contains(this string[] source, string value, StringComparison comparisonType)
	{
		return source.Contains(value, new CompareText(comparisonType));
	}

	public static string Serialize(this object obj)
	{
		if (obj == null)
		{
			return "";
		}
		Type type = obj.GetType();
		if (type.IsSerializable)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				XmlSerializer xmlSerializer = new XmlSerializer(type);
				XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, new XmlWriterSettings
				{
					CloseOutput = true,
					Encoding = Encoding.UTF8,
					Indent = true,
					CheckCharacters = false
				});
				xmlSerializer.Serialize(xmlWriter, obj);
				xmlWriter.Flush();
				xmlWriter.Close();
				return stringBuilder.ToString();
			}
			catch
			{
				return "";
			}
		}
		return "";
	}

	public static string AesEncrypt(this string str)
	{
		return Encryption.Encrypt(str);
	}

	public static string AesDecrypt(this string str)
	{
		return Encryption.Decrypt(str);
	}

	public static string DesEncrypt(this string str)
	{
		return EncryptionDes.Encrypt(str);
	}

	public static string DesDecrypt(this string str)
	{
		return EncryptionDes.Decrypt(str);
	}

	public static void ClickDisabled(this Button button, string newText = "")
	{
		if (button != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			((Page)HttpContext.Current.Handler).ClientScript.GetPostBackEventReference(button, string.Empty);
			if (!button.ValidationGroup.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("if({0})", button.ValidationGroup);
				stringBuilder.Append("{");
				if (!button.OnClientClick.IsNullOrEmpty())
				{
					stringBuilder.Append(button.OnClientClick);
				}
				stringBuilder.Append("this.disabled=true;");
				if (!newText.IsNullOrEmpty())
				{
					stringBuilder.AppendFormat("this.value=\"{0}\";", newText);
				}
				stringBuilder.AppendFormat("__doPostBack(\"{0}\",\"\");", button.ID);
				stringBuilder.Append("}else{return false;}");
			}
			else
			{
				if (!button.OnClientClick.IsNullOrEmpty())
				{
					stringBuilder.Append(button.OnClientClick);
				}
				stringBuilder.Append("this.disabled=true;");
				if (!newText.IsNullOrEmpty())
				{
					stringBuilder.AppendFormat("this.value=\"{0}\";", newText);
				}
				stringBuilder.AppendFormat("__doPostBack(\"{0}\",\"\");", button.ID);
			}
			button.OnClientClick = stringBuilder.ToString();
		}
	}

	public static void ClickDisabled(this LinkButton button, string newText = "")
	{
		if (button != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			((Page)HttpContext.Current.Handler).ClientScript.GetPostBackEventReference(button, string.Empty);
			string text = button.ValidationGroup;
			if (text.IsNullOrEmpty())
			{
				text = button.OnClientClick;
				if (!text.IsNullOrEmpty() && text.StartsWith("return"))
				{
					text = text.Replace("return ", "").Replace(";", "");
				}
			}
			if (!text.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat("if({0})", text);
				stringBuilder.Append("{");
				stringBuilder.Append("this.disabled=true;");
				if (!newText.IsNullOrEmpty())
				{
					stringBuilder.AppendFormat("this.value='{0}';", newText);
				}
				stringBuilder.AppendFormat("__doPostBack('{0}','');", button.ID);
				stringBuilder.Append("}else{return false;}");
			}
			else
			{
				if (!button.OnClientClick.IsNullOrEmpty())
				{
					stringBuilder.Append(button.OnClientClick);
				}
				stringBuilder.Append("this.disabled=true;");
				if (!newText.IsNullOrEmpty())
				{
					stringBuilder.AppendFormat("this.value='{0}';", newText);
				}
				stringBuilder.AppendFormat("__doPostBack('{0}','');", button.ID);
			}
			button.OnClientClick = stringBuilder.ToString();
		}
	}

	public static Guid ToGuid(this int i)
	{
		return i.ToString("00000000-0000-0000-0000-000000000000").ToGuid();
	}

	public static int ToInt(this Guid guid)
	{
		return guid.ToString("N").TrimStart('0').ToInt();
	}

	public static string ToDateString(this string date)
	{
		return date.ToDateTime().ToString(Config.DateFormat);
	}

	public static string ToDateTimeString(this string dateTime)
	{
		return dateTime.ToDateTime().ToString(Config.DateTimeFormat);
	}

	public static string ToDateTimeStringS(this string dateTime)
	{
		return dateTime.ToDateTime().ToString(Config.DateTimeFormatS);
	}

	public static string ToDateString(this DateTime date)
	{
		return date.ToString(Config.DateFormat);
	}

	public static string ToDateTimeString(this DateTime dateTime)
	{
		return dateTime.ToString(Config.DateTimeFormat);
	}

	public static string ToDateTimeStringS(this DateTime dateTime)
	{
		return dateTime.ToString(Config.DateTimeFormatS);
	}

	public static string ToJsonString(this object obj)
	{
		if (obj is DataTable)
		{
			JsonData jsonData = new JsonData();
			DataTable dataTable = obj as DataTable;
			if (dataTable.Rows.Count == 0)
			{
				return "[]";
			}
			foreach (DataRow row in dataTable.Rows)
			{
				JsonData jsonData2 = new JsonData();
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					string columnName = dataTable.Columns[i].ColumnName;
					string data = row[dataTable.Columns[i].ColumnName].ToString();
					jsonData2[columnName] = data;
				}
				jsonData.Add(jsonData2);
			}
			return jsonData.ToJson();
		}
		return JsonMapper.ToJson(obj);
	}

	public static RouteValueDictionary ToRouteValueDictionary(this string urlQuery)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (urlQuery.IsNullOrEmpty())
		{
			return new RouteValueDictionary(dictionary);
		}
		string[] array = urlQuery.TrimStart('?').Split('&');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split('=');
			if (array2.Length >= 2)
			{
				dictionary.Add(array2[0], array2[1]);
			}
		}
		return new RouteValueDictionary(dictionary);
	}
}
