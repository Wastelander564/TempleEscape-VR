using UnityEngine;
using UnityEngine.SceneManagement; // To load new scenes

public class endGame : MonoBehaviour
{
    public MemoryScript memoryScript;
    public ScaleScript scaleScript;
    public CogScript cogScript;
    public string completedGameScene = "CompletedGameScene"; // Name of the completed game scene

    // OnTriggerEnter is called when another collider enters the trigger collider attached to the GameObject
    void OnTriggerEnter(Collider other)
    {
        // Ensure the collider is not tagged as "Structure"
        if (!other.CompareTag("Structure"))
        {
            // Check if all signals are active
            if (memoryScript.activationSignal && scaleScript.activationSignal && cogScript.activationSignal)
            {
                // Switch to the completed game scene
                SwitchScene();
            }
        }
    }

    // Function to switch the scene when the conditions are met
    void SwitchScene()
    {
        SceneManager.LoadScene(completedGameScene);
    }
}
