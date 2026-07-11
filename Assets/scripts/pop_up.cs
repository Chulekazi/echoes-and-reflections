using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class pop_up : MonoBehaviour
{
    public static pop_up Instance;

    public TextMeshProUGUI itemNameText;
    public Image itemIconImage;
    public float displayDuration = 2.0f; // How long the panel stays up

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Ensure it starts hidden
        gameObject.SetActive(false);
    }

    public void ShowPopup(Items equippedItem)
    {
        // Stop any previous fade/hide timer currently running
        StopAllCoroutines();

        // Set the UI text and sprite from the ScriptableObject data
        itemNameText.text = equippedItem.itemName + " Equipped!";
        itemIconImage.sprite = equippedItem.icon;

        // Turn the panel on and start the countdown timer
        gameObject.SetActive(true);
        StartCoroutine(DisplayTimer());
    }

    private IEnumerator DisplayTimer()
    {
        // Wait on screen for the specified amount of seconds
        yield return new WaitForSeconds(displayDuration);

        // Hide the panel so the game continues cleanly
        gameObject.SetActive(false);
    }
}

