using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using Newtonsoft.Json;

public class GameConfig
{
    public List<string> options;

    public List<string> languages;

    public Dictionary<int, LevelConfig> levelConfigs;

    public void LoadConfigs()
    {
        string appDBPath = Application.dataPath + "/Resources/Samsara.db";
        DbAccess db = new DbAccess(@"Data Source=" + appDBPath);

        LoadGlobalConfig(db);

        db.CloseSqlConnection();
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
                        options = JsonHelper.DeserializeJsonToList<string>(optionsValue);
                        break;
                    case "languages":
                        string languagesValue = sqReader.GetString(sqReader.GetOrdinal("value"));
                        languages = JsonHelper.DeserializeJsonToList<string>(languagesValue);
                        break;
                }
            }

            sqReader.Close();
        }
    }
}