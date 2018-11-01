using RoadFlow.Platform;

public static class MyExtensions1
{
	public static string FilterWildcard(this string str, string userID = "")
	{
		if (!str.IsNullOrEmpty())
		{
			return Wildcard.FilterWildcard(str, userID);
		}
		return "";
	}
}
