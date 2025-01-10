using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButton : MonoBehaviour
{
    public string SampleScene = "SampleScene";  // The name of the scene for replay  // The name of the main menu scene
    
    public void playSwitchScene()
    {
        SceneManager.LoadScene(SampleScene);
    }
   

    // Function to quit the game
    public void QuitGame()
    {
        // Check if the game is running in the editor or build
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #else
            Application.Quit(); // Quit the application when running a build
        #endif
    }
}
