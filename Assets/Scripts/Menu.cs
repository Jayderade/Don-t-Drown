using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Bools")]

    

    public bool fullscreenBool;
    public bool makeFullscreen;
    public bool inGame;
    public bool pauseBool;
    public bool showPause;
    public bool musicPlay;

    [Header("GameObjects")]
    public GameObject mainMenu;
    






    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    public void Awake()
    {
        Time.timeScale = 1;


    }



    public void Start()
    {
        inGame = false;




    }

    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            mainMenu.SetActive(true);
            TogglePause();

        }



    }

    public void Play()
    {
        SceneManager.LoadScene(0);
        inGame = true;
    }














    

    





    public void Exit()
    {
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }



    public void Resume()
    {
        TogglePause();
    }

    public bool TogglePause()
    {
        if (pauseBool)
        {
            if (!showPause)
            {
                Time.timeScale = 1;
                pauseBool = false;
                mainMenu.SetActive(false);
            }
            else
            {
                showPause = false;
                mainMenu.SetActive(true);
            }
            return false;
        }
        else
        {
            Time.timeScale = 0;
            pauseBool = true;
            mainMenu.SetActive(true);
            return true;
        }
    }
}
