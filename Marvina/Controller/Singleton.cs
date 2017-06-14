class Singleton
{
	//Variable
	private static Singleton Instance;
	private static string userName;

	//Constructor
	private Singleton()
	{
        userName = "hue landia";
	}
	//Property
	public static Singleton GetInstance()
	{
		if (Instance == null)
		{
			Instance = new Singleton();
		}
		return Instance;

	}


	public static string getUserName()
	{
		return userName;
	}

	public static void setUserName(string name)
	{
		userName = name;
	}


}
