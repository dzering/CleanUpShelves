using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController
{
    Button restart;
    Button quit;

    public PauseMenuController(UIView gameMenuView)
    {
        restart = gameMenuView.Restart;
        quit = gameMenuView.Quit;
        restart.onClick.AddListener(Restart);
        quit.onClick.AddListener(Quit);
    }

    void Quit()
    {
        SceneManager.LoadScene(0);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
