using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace BNM
{
    public static class Config
    {
    	//Tweaks
    	public static bool shortswordBuff = true;
    	//Features

    	static string ConfigPath = Path.Combine(Main.SavePath, "BNM.json");

    	static Preferences Configuration = new Preferences(ConfigPath);

    	public static void Load()
        {
            bool success = ReadConfig();

            if(!success)
            {
                ErrorLogger.Log("Failed to read BNM config file, recreating config...");
                CreateConfig();
            }
        }

        static bool ReadConfig()
        {
            if(Configuration.Load())
            {
				Configuration.Get("Shortsword Buff", ref shortswordBuff);
			}
			return false;
		}

	    static void CreateConfig()
        {
            Configuration.Clear();
			Configuration.Put("Shortsword Buff", shortswordBuff);
			Configuration.Save();
		}
    }
}