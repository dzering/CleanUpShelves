using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Button restart;
    [SerializeField] Button quit;

    void Start()
    {
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
