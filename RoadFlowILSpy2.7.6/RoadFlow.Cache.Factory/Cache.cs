using RoadFlow.Cache.InProc;
using RoadFlow.Cache.Interface;

namespace RoadFlow.Cache.Factory
{
	public class Cache
	{
		public static ICache CreateInstance()
		{
			return new RoadFlow.Cache.InProc.Cache();
		}
	}
}
