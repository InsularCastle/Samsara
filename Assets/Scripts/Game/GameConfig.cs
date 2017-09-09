using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using Newtonsoft.Json;

public class GameConfig
{
    private List<string> _options;

    private List<string> _languages;

    public Dictionary<int, LevelConfig> _levelConfigs;

    public void LoadConfigs()
    {
        string appDBPath = Application.dataPath + "/Resources/Samsara.db";
        DbAccess db = new DbAccess(@"Data Source=" + appDBPath);

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