using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    
    public void Quit()
    {
        Application.Quit();
    }

    public void StartEndless()
    {
        DataHolder.Instance.currentLevel = 1;
        SceneManager.LoadScene(1);
    }

    public void StartLevel()
    {
        DataHolder.Instance.currentLevel = 0;
        SceneManager.LoadScene(1);
    }

}
