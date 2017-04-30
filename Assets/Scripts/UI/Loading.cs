using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour
{
    public void Init()
    {
        WindowManager.Close<LoadingWnd>();
        Application.LoadLevelAsync(GameController.levelName);
    }
}
