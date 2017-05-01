using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Slider slider;

    private AsyncOperation _op;

    public void Init()
    {
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        _op = Application.LoadLevelAsync(GameController.levelName);
        yield return new WaitForEndOfFrame();
        WindowManager.Close<LoadingWnd>();
    }

    void Update()
    {
        if (_op != null)
        {
            slider.value = _op.progress;
        }
    }
}
