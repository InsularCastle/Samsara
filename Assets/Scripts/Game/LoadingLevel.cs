using System;
using System.Collections.Generic;
using UnityEngine;

public class LoadingLevel
{
    public static string levelName;
    public LoadingLevel()
    {

    }

    public void Init()
    {
        WindowManager.Open<LoadingWnd>();
        GameTimer.Invoke(LoadNextLevel, 2f);
    }

    private void LoadNextLevel()
    {
        WindowManager.Close<LoadingWnd>();
        Application.LoadLevelAsync(levelName);
    }
}