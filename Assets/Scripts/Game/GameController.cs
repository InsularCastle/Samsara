using UnityEngine;
using System.Collections;

/// <summary>
/// 关卡类型
/// </summary>
public enum LevelType
{
    Startup = 0,
    Loading = 1,
    City = 2,
    Play = 3
}

public class GameController : MonoBehaviour
{
    public static GameConfig config;

    //private static Level _level;

    private WindowManager _wndManager;
    private TimerManager _timerManager;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _timerManager = new TimerManager();

        config = new GameConfig();
        config.LoadConfigs();

        _wndManager = new WindowManager();
        WindowManager.Open<LoginWnd>().Init();
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == (int)LevelType.Loading)
        {
            LoadingLevel loadingLevel = new LoadingLevel();
            loadingLevel.Init();
        }
        else if (level == (int)LevelType.City)
        {
            CityLevel cityLevel = new CityLevel();
            cityLevel.Init();
        }
        else if (level >= (int)LevelType.Play)
        {
            //LevelConfig levelCfg = config.GetLevelCfg(Level.LevelID);
            //_level = new Level(levelCfg);
        }
    }

    void Update()
    {
        // 每一帧的增量时间
        float dt = Time.deltaTime;

        _timerManager.Update(dt);

        //if (_level != null)
        //{
        //    _level.Update(dt);
        //}
    }

    public static void LevelEnd()
    {
        //_level.Clear();
        //_level = null;
        WindowManager.Close<PlayWnd>();
        LoadingLevel.levelName = "City";
        Application.LoadLevelAsync("Loading");
    }
}
