using System.Collections.Generic;
using Marvina.Model;

class Singleton
{
	//Variable
	private static Singleton Instance;
	private static string userName;
	private static List<Option> listOfOption;


	//Constructor
	private Singleton()
	{
        userName = null;
        listOfOption = new List<Option>();
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
    public static void addListOfOption(Option op){
        listOfOption.Add(op);
    }

    public static List<Option> getListOfOption(){
        return listOfOption;
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
