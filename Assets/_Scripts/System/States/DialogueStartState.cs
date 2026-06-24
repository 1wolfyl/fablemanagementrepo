using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;



public class DialogueStartState : DialogueBaseState
    {
    public TextMeshProUGUI textComponent;
    public DialogueNode[] nodes;
    public float textSpeed = 0.05f;
    // index of current node and current line within the node
    private int nodeIndex;
    private int lineIndex;
    public GameObject dialogueBox;
    // Panel that contains choice buttons. Buttons should call Script.Choose(int nextNode)
    public GameObject choicesPanel;
    public override void EnterState(DialogueManager1 dialogueManager)
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    public override void UpdateState(DialogueManager1 dialogueManager)
    {

        if (Input.GetMouseButtonDown(0))
        {
            string currentLine = GetCurrentLine();
            if (currentLine == null) return;

            if (textComponent.text == currentLine)
            {
                DialogeLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = currentLine;
            }
        }
    }
    void StartDialogue()
    {
        nodeIndex = 0;
        lineIndex = 0;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeLine());
    }
    void DialogeLine()
    {
        if (lineIndex < nodes[nodeIndex].lines.Length - 1)
        {
            lineIndex++;
            StartCoroutine(TypeLine());


        }
    }
    public override void OnCollisionEnter(DialogueManager1 dialogueManager)
    {
    }
}
