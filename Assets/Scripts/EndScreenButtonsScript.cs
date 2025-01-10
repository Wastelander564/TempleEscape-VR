using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtonsScript : MonoBehaviour
{
    public string SampleScene = "SampleScene";  // The name of the scene for replay
    public string StartScreen = "StartScreen";  // The name of the main menu scene

    // Start is called before the first frame update
    void Start()
    {
        // You can initialize things here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // You can handle frame updates here if needed
    }

    // Function to replay the scene
    public void ReplaySwitchScene()
    {
        SceneManager.LoadScene(SampleScene);
    }
    
    // Function to go back to the main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(StartScreen);
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
