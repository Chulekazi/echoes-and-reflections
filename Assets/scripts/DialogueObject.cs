using UnityEngine;
[CreateAssetMenu(fileName = "New Dialogue Sequence", menuName = "Dialogue/Sequence")]
public class DialogueObject : ScriptableObject
{
    public Dialogue[] lines;
}
