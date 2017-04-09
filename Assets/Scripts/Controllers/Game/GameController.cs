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
    Game = 3
}

public class GameController : MonoBehaviour
{
    private WindowManager _wndManager;
    private TimeManager _timeManager;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _timeManager = new TimeManager();
        _wndManager = new WindowManager();

    }

    void Start()
    {
	
	}
	
	void Update()
    {
	
	}
}
