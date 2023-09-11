using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public string levelName; // Имя сцены, которую нужно загрузить

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}