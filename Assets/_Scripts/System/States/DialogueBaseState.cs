using UnityEngine;

public abstract class DialogueBaseState
{
    [System.Serializable]
    public class DialogueNode
    {
        public string nodeName;
        public string[] lines;
        // If true the node will show a choices panel instead of following a single nextNode
        public bool hasChoices = false;
        // Used when hasChoices is false. -1 closes dialogue.
        public int nextNode = -1;
    }

    public abstract void EnterState(DialogueManager1 dialogueManager);
    
   public abstract void UpdateState(DialogueManager1 dialogueManager);
    
public abstract void OnCollisionEnter(DialogueManager1 dialogueManager);
    
}
