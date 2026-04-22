using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // LOAD SCENE METHOD
    public void OnClickLoadScene(int sceneIndex)
    {
        // make sure the SCENEINDEX is less than
        // or equal to the scene count in the build settings
        if (sceneIndex > SceneManager.sceneCountInBuildSettings-1)
        {
            Debug.LogWarning($"{gameObject.name}'s OnClickLoadScene index is out of range. \n Make sure" +
                      $"you've added all your scenes to the build settings menu.");
        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void OnClickQuit()
    {
        Application.Quit();
        
        // show this message in the editor
        // so we know this method is being called
        Debug.Log("Main Menu Quit.");
    }
}
