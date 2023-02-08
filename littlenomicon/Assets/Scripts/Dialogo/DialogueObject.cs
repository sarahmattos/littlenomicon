using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "DialogueObject", menuName = "NPC Dialogue Object", order = 0)]
public class DialogueObject : ScriptableObject
{
    [Header("Dialogue")]
    public List<DialogueSegment> dialogueSegments = new List<DialogueSegment>();
    [Header("Follow on dialogue")]
    public DialogueObject endDialogue;
}
[System.Serializable]
public struct DialogueSegment{
    public string dialogueText;
    public float dialogueDisplayTime;
    public Sprite icon;
    public int fontAssetId;
    public List<DialogueChoice> dialogueChoices;
}
[System.Serializable]
public struct DialogueChoice{
    public string dialogueChoice;
    public DialogueObject followOnDialogue;
    public bool AlteraStatus;
    
}
