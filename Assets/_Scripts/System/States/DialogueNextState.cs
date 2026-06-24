using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;


public class DialogueNextState : DialogueBaseState
    {
    void NextLine()
    {
        var node = (nodes != null && nodeIndex >= 0 && nodeIndex < nodes.Length) ? nodes[nodeIndex] : null;
        if (node == null)
        {
            Debug.Log("1");

            dialogueBox.SetActive(false);
            return;
        }

        if (lineIndex < node.lines.Length - 1)
        {
            Debug.Log("2");
            lineIndex++;
            StartCoroutine(TypeLine());
            return;
        }

        // End of lines for this node
        if (node.hasChoices)
        {
            Debug.Log("3");
            // Show choices panel and wait for player to choose. Buttons should be configured in the inspector
            
            {
                choicesPanel.SetActive(true);
            }
            return;
        }
       
        if (node.nextNode >= 0 && node.nextNode < nodes.Length)
        {
            nodeIndex = node.nextNode;
            lineIndex = 0;
            StartCoroutine(TypeLine());
            return;
        }

        // No next node - close dialogue
        dialogueBox.SetActive(false);
    }
    public override void EnterState(DialogueManager1 dialogueManager)
    {
    }
    public override void UpdateState(DialogueManager1 dialogueManager)
    {
       
    }
    public override void OnCollisionEnter(DialogueManager1 dialogueManager)
    {
    }
}
