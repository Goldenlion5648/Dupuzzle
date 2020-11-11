using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("ButtonTutorial");
    }
    public void optionsMenu()
    {
        //SceneManager.LoadScene(globals.levelOrder[0]);
    }

    public void quitGame()
    {
        //SceneManager.LoadScene(globals.levelOrder[0]);
        Debug.Log("quit game");

        Application.Quit();

    }

}
