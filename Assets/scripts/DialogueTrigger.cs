using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueObject dialogueToTrigger;

    [Header("UI Prompt")]
    
    public GameObject promptVisual;

    private bool playerIsClose = false;

    private void Start()
    {
       
        if (promptVisual != null)
        {
            promptVisual.SetActive(false);
        }
    }

    private void Update()
    {
      
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            DialogueMnager.Instance.StartDialogue(dialogueToTrigger);

            promptVisual.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;

            if (promptVisual != null)
            {
                promptVisual.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;

            if (promptVisual != null)
            {
                promptVisual.SetActive(false);
            }
        }
    }
}
