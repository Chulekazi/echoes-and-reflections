using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueMnager : MonoBehaviour
{
    public static DialogueMnager Instance;

    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI bodyText;
    public Image portraitImage;

    [Header("Settings")]
    [SerializeField] private float typingSpeed = 0.03f;

    private Queue<Dialogue> lineQueue = new Queue<Dialogue>();
    private bool isTyping = false;
    private string currentFullText = "";
    private Coroutine typingCoroutine;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(DialogueObject dialogue)
    {
        lineQueue.Clear();

        foreach (Dialogue line in dialogue.lines)
        {
            lineQueue.Enqueue(line);
        }

        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            bodyText.text = currentFullText;
            isTyping = false;
            return;
        }

        if (lineQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue currentLine = lineQueue.Dequeue();
        nameText.text = currentLine.speakerName;
        portraitImage.sprite = currentLine.speakerPortrait;
        portraitImage.gameObject.SetActive(currentLine.speakerPortrait != null);

        bodyText.fontStyle = currentLine.italicizeText ? FontStyles.Italic : FontStyles.Normal;
        currentFullText = currentLine.dialogueText;
        typingCoroutine = StartCoroutine(TypeText(currentFullText));
    }

    private IEnumerator TypeText(string textToType)
    {
        isTyping = true;
        bodyText.text = "";

        foreach (char letter in textToType.ToCharArray())
        {
            bodyText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        isTyping = false;
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Debug.Log("Dialogue sequence completed successfully.");
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            DisplayNextLine();
        }
    }
}

