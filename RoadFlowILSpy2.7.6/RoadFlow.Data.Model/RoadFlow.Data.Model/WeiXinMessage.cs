using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WeiXinMessage
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("企业号CorpID")]
		public string ToUserName
		{
			get;
			set;
		}

		[DisplayName("发送人员账号")]
		public string FromUserName
		{
			get;
			set;
		}

		[DisplayName("消息创建时间")]
		public int CreateTime
		{
			get;
			set;
		}

		[DisplayName("消息创建时间")]
		public DateTime CreateTime1
		{
			get;
			set;
		}

		[DisplayName("消息类型")]
		public string MsgType
		{
			get;
			set;
		}

		[DisplayName("消息id，64位整型")]
		public long MsgId
		{
			get;
			set;
		}

		[DisplayName("企业应用的id")]
		public int AgentID
		{
			get;
			set;
		}

		[DisplayName("文本消息内容")]
		public string Contents
		{
			get;
			set;
		}

		[DisplayName("图片链接")]
		public string PicUrl
		{
			get;
			set;
		}

		[DisplayName("图片媒体文件id")]
		public string MediaId
		{
			get;
			set;
		}

		[DisplayName("语音格式，如amr，speex等")]
		public string Format
		{
			get;
			set;
		}

		[DisplayName("视频消息缩略图的媒体id")]
		public string ThumbMediaId
		{
			get;
			set;
		}

		[DisplayName("地理位置纬度")]
		public string Location_X
		{
			get;
			set;
		}

		[DisplayName("地理位置经度")]
		public string Location_Y
		{
			get;
			set;
		}

		[DisplayName("地图缩放大小")]
		public string Scale
		{
			get;
			set;
		}

		[DisplayName("地理位置信息")]
		public string Label
		{
			get;
			set;
		}

		[DisplayName("标题(link消息)")]
		public string Title
		{
			get;
			set;
		}

		[DisplayName("描述(link消息)")]
		public string Description
		{
			get;
			set;
		}

		[DisplayName("添加时间")]
		public DateTime AddTime
		{
			get;
			set;
		}
	}
}
