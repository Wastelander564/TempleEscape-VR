using UnityEngine;

public class CogScript : MonoBehaviour
{
    public GameObject[] cogSockets;  // Array of sockets
    public GameObject[] correctCogs; // Array of correct cogs
    public bool activationSignal = false; // Bool signal for ProgressScript
    public AudioClip activationSound; // Audio clip to play when signal is true
    private AudioSource audioSource;

    private bool audioPlayed = false; // To ensure the sound plays only once

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        // Continuously check if cogs are placed correctly
        CheckCogs();
    }

    public void CheckCogs()
    {
        // Iterate through each socket and check if the correct cog is placed in the right position
        for (int i = 0; i < cogSockets.Length; i++)
        {
            // Check if the socket is occupied by the correct cog
            if (!IsCogInSocket(correctCogs[i], cogSockets[i]))
            {
                // If any socket does not have the correct cog, deactivate the signal
                activationSignal = false;
                audioPlayed = false; // Reset audio trigger if activationSignal is false
                return;
            }
        }

        // If all sockets have the correct cogs, activate the signal
        activationSignal = true;

        if (!audioPlayed && activationSound != null)
        {
            audioSource.PlayOneShot(activationSound);
            audioPlayed = true;
        }
    }

    // Helper function to check if a specific cog is in the correct socket
    private bool IsCogInSocket(GameObject cog, GameObject socket)
    {
        // Define a threshold for how close the cog must be to the socket position
        float proximityThreshold = 0.1f;

        // Check if the cog is within proximity to the socket (assuming the cog's position should match the socket's position)
        if (Vector3.Distance(cog.transform.position, socket.transform.position) < proximityThreshold)
        {
            return true; // Cog is correctly placed in the socket
        }

        return false; // Cog is not in the correct position
    }
}
