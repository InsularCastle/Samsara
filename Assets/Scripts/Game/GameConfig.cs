using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using Newtonsoft.Json;
using System.IO;

public class GameConfig
{
    private List<string> _options;

    private List<string> _languages;

    public Dictionary<int, LevelConfig> _levelConfigs;

    public void LoadConfigs()
    {
        string appDBPath = "";
#if UNITY_EDITOR
        appDBPath = Application.dataPath + "/Plugins/Android/assets/" + "Samsara.db";
        DbAccess db = new DbAccess(@"Data Source=" + appDBPath);
#elif UNITY_ANDROID && !UNITY_EDITOR
        appDBPath = Application.persistentDataPath + "/Samsara.db";
        if(!File.Exists(appDBPath))
        {  
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "Samsara.db");   
  
            while(!loadDB.isDone){}
            File.WriteAllBytes(appDBPath, loadDB.bytes);
        }  
        DbAccess db = new DbAccess("URI=file:" + appDBPath);
#endif

        LoadGlobalConfig(db);

        db.CloseSqlConnection();
    }

    public List<string> GetOptions()
    {
        return _options;
    }

    public List<string> GetLanguages()
    {
        return _languages;
    }

    public LevelConfig GetLevelCfg(int levelID)
    {
        if (_levelConfigs.ContainsKey(levelID))
        {
            return _levelConfigs[levelID];
        }
        return null;
    }

    private void LoadGlobalConfig(DbAccess db)
    {
        using (SqliteDataReader sqReader = db.ReadFullTable("global_config"))
        {
            while (sqReader.Read())
            {
                switch (sqReader.GetString(sqReader.GetOrdinal("name")))
                {
                    case "options":
                        string optionsValue = sqReader.GetString(sqReader.GetOrdinal("value"));
                        _options = JsonHelper.DeserializeJsonToList<string>(optionsValue);
                        break;
                    case "languages":
                        string languagesValue = sqReader.GetString(sqReader.GetOrdinal("value"));
                        _languages = JsonHelper.DeserializeJsonToList<string>(languagesValue);
                        break;
                }
            }

            sqReader.Close();
        }
    }
}