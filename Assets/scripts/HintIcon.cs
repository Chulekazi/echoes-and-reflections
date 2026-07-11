using UnityEngine;
using System.Collections;

public class HintIcon : MonoBehaviour
{
    private Coroutine hintCoroutine;
    private bool isDiscovered = false;

    [Header("UI Hint Settings")]
    // Drag your floating icon GameObject (the child icon) into this slot in the Inspector
    [SerializeField] private GameObject hintIcon;

    [Header("Timing")]
    [SerializeField] private float secondsToWait = 7.0f;

    void Start()
    {
        // Safety check: Make sure the icon starts hidden when the game begins
        if (hintIcon != null)
        {
            hintIcon.SetActive(false);
        }

        // Start the 7-second countdown immediately
        StartHintTimer();
    }

    // This background timer waits for 7 seconds, then turns on the icon if the player hasn't found it
    private IEnumerator WaitAndShowHint()
    {
        yield return new WaitForSeconds(secondsToWait);

        if (!isDiscovered && hintIcon != null)
        {
            hintIcon.SetActive(true);
        }
    }

    public void StartHintTimer()
    {
        StopHintTimer(); // Clear any running timers so they don't overlap

        if (!isDiscovered)
        {
            hintCoroutine = StartCoroutine(WaitAndShowHint());
        }
    }

    private void StopHintTimer()
    {
        if (hintCoroutine != null)
        {
            StopCoroutine(hintCoroutine);
            hintCoroutine = null;
        }
    }

    // --- Interaction / Mouse Detection ---

    void OnMouseEnter()
    {
        // The player found it! Hide the hint icon immediately
        if (hintIcon != null)
        {
            hintIcon.SetActive(false);
        }

        // Stop the background timer because they don't need a hint anymore
        StopHintTimer();
    }

    void OnMouseExit()
    {
        // If the player moves the mouse away without clicking/collecting it, 
        // restart the 7-second countdown to show the hint again later.
        StartHintTimer();
    }

    // Call this public method from your gameplay/click script when the player successfully interacts with the item
    public void OnItemInteracted()
    {
        isDiscovered = true;
        StopHintTimer();

        if (hintIcon != null)
        {
            hintIcon.SetActive(false);
        }

        // Turn off this script completely so it stops running background loops
        this.enabled = false;
    }
}

