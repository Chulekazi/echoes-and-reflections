using UnityEngine;
[System.Serializable]
public class Dialogue 
{
    public string speakerName;
    [TextArea(2,5)]
    public string dialogueText;
    public Sprite speakerPortrait;
    public bool italicizeText;
}
