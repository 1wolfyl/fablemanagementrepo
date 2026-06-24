using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueChoicesState : DialogueBaseState
    {
    private DialogueNode[] nodes;
    public override void EnterState(DialogueManager1 dialogueManager)
    {
        
    }
    public override void UpdateState(DialogueManager1 dialogueManager)
    {
         void Choose(int nextNode)
    {
        if (choicesPanel != null) choicesPanel.SetActive(false);
        if (nodes == null) return;
        if (nextNode < 0 || nextNode >= nodes.Length)
        {
            dialogueBox.SetActive(false);
            return;
        }

        nodeIndex = nextNode;
        lineIndex = 0;
        StartCoroutine(TypeLine());
    }
    }
private string GetCurrentLine()
{
    if ( nodes.Length == 0) return null;
    if (nodeIndex < 0 || nodeIndex >= nodes.Length) return null;
    var node = nodes[nodeIndex];
    if (node.lines.Length == 0) return null;
    if (lineIndex < 0 || lineIndex >= node.lines.Length) return null;
    return node.lines[lineIndex];
}

private IEnumerator TypeLine()
{
    textComponent.text = string.Empty;
    string line = GetCurrentLine();
    if (line == null) yield break;
    foreach (char c in line.ToCharArray())
    {
        textComponent.text += c;
        yield return new WaitForSeconds(textSpeed);
    }
}
public override void OnCollisionEnter(DialogueManager1 dialogueManager)
    {
    }
}
