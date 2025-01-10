using UnityEngine;

public class ProgressScript : MonoBehaviour
{
    public MemoryScript memoryScript;
    public ScaleScript scaleScript;
    public CogScript cogScript;
    public GameObject[] gameObjectsToActivate; // Array of GameObjects to activate
    [SerializeField] private GameObject targetToDestroy;        // Target GameObject to destroy
    [SerializeField] private Light mysticLight;

    private bool memoryActivated = false;
    private bool scaleActivated = false;
    private bool cogActivated = false;

    void Start()
    {
        mysticLight.enabled = false;
    }

    void Update()
    {
        // Check and handle the memory signal
        if (memoryScript.activationSignal && !memoryActivated)
        {
            ActivateGameObject(0);
            memoryActivated = true;
        }

        // Check and handle the scale signal
        if (scaleScript.activationSignal && !scaleActivated)
        {
            ActivateGameObject(1);
            scaleActivated = true;
        }

        // Check and handle the cog signal
        if (cogScript.activationSignal && !cogActivated)
        {
            ActivateGameObject(2);
            cogActivated = true;
        }

        // If all signals are active, destroy the target
        if (memoryActivated && scaleActivated && cogActivated && targetToDestroy != null)
        {
            Destroy(targetToDestroy);
            mysticLight.enabled = true;
            targetToDestroy = null; // Ensure it doesn't get destroyed multiple times
        }
    }

    private void ActivateGameObject(int index)
    {
        if (index < gameObjectsToActivate.Length && gameObjectsToActivate[index] != null)
        {
            gameObjectsToActivate[index].SetActive(true);
        }
    }
}
