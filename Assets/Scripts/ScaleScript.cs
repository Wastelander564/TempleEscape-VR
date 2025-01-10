using UnityEngine;
using UnityEngine.UI; // For Button and Text components
using TMPro;

public class ScaleScript : MonoBehaviour
{
    public Button addButton;          // Button to add coins
    public Button subtractButton;     // Button to subtract coins
    public TextMeshProUGUI feedbackText;         // Text for feedback messages (e.g., "Scale Balanced!")
    public GameObject coinPrefab;     // Prefab for the coin object
    public Transform coinParent;      // Parent object to hold the coins

    public int currentCoinCount = 0;  // Current coin count
    public int requiredCoinCount = 10; // Number of coins required for the signal

    public bool activationSignal = false; // Bool signal for ProgressScript

    private void Start()
    {
        // Add listeners to buttons to update the coin count
        addButton.onClick.AddListener(AddCoins);
        subtractButton.onClick.AddListener(SubtractCoins);
    }

    // Method to add a coin (create a coin object)
    private void AddCoins()
    {
        // Instantiate a new coin and set its parent
        GameObject newCoin = Instantiate(coinPrefab, coinParent);
        newCoin.SetActive(true);  // Ensure the coin is visible

        // Update the coin count and check the scale
        currentCoinCount++;
    }

    // Method to subtract a coin (destroy a coin object)
    private void SubtractCoins()
    {
        if (currentCoinCount > 0) // Prevent negative coin count
        {
            // Find the last coin (the most recently added one) and destroy it
            Transform lastCoin = coinParent.GetChild(coinParent.childCount - 1);
            Destroy(lastCoin.gameObject);

            // Update the coin count and check the scale
            currentCoinCount--;
        }
    }

    // Method to check the coin count and set the activation signal and feedback
    public void CheckScale()
    {
        // Check if the correct number of coins is present
        if (currentCoinCount == requiredCoinCount)
        {
            activationSignal = true; // Activate the signal
            feedbackText.text = "Scale Balanced!";
        }
        else
        {
            activationSignal = false; // Deactivate the signal
        }

        // Provide feedback based on the coin count
        if (currentCoinCount > requiredCoinCount)
        {
            feedbackText.text = "Too Many Coins!";
        }
        else if (currentCoinCount < requiredCoinCount)
        {
            feedbackText.text = "Add More Coins!";
        }
    }
}
