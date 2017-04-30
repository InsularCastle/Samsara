﻿using UnityEngine;
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

    public static string levelName;

    private static Level _level;

    private WindowManager _wndManager;
    private TimerManager _timerManager;

    void Awake()
    {
        DontDestroyOnLoad(this);

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
            WindowManager.Open<LoadingWnd>().Init();
        }
        else if (level == (int)LevelType.City)
        {
            WindowManager.Open<ChooseLevelWnd>().Init();
        }
        else if (level >= (int)LevelType.Play)
        {
            _level = new Level(config.levelConfigs[Level.LevelID]);
        }
    }

    void Update()
    {
        // 每一帧的增量时间
        float dt = Time.deltaTime;

        _timerManager.Update(dt);

        if (_level != null)
        {
            _level.Update(dt);
        }
    }

    public static void LevelEnd()
    {
        _level.Clear();
        _level = null;
        WindowManager.Close<PlayWnd>();
        levelName = "City";
        Application.LoadLevelAsync("Loading");
    }
}
