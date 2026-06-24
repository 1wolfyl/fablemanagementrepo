using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

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

public class Script : MonoBehaviour
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

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            string currentLine = GetCurrentLine();
            if (currentLine == null) return;

            if (textComponent.text == currentLine)
            {
                NextLine();
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
        if (choicesPanel != null) choicesPanel.SetActive(false);
        StartCoroutine(TypeLine());
    }

    private string GetCurrentLine()
    {
        if (nodes == null || nodes.Length == 0) return null;
        if (nodeIndex < 0 || nodeIndex >= nodes.Length) return null;
        var node = nodes[nodeIndex];
        if (node.lines == null || node.lines.Length == 0) return null;
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
            if (choicesPanel != null)
            {
                choicesPanel.SetActive(true);
            }
            return;
        }
        Debug.Log(string.Format("Node is null: {0}", node == null));
        if (node.nextNode >= 0 && nodes != null && node.nextNode < nodes.Length)
        {
            nodeIndex = node.nextNode;
            lineIndex = 0;
            StartCoroutine(TypeLine());
            return;
        }

        // No next node - close dialogue
        dialogueBox.SetActive(false);
    }

    // Called by choice buttons. nextNode should be the index of the DialogueNode to jump to.
    public void Choose(int nextNode)
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
