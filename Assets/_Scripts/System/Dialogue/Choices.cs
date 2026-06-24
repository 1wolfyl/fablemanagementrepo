using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Choices : MonoBehaviour

{
    [SerializeField] private Resource resource;
    [SerializeField] private TextMeshProUGUI safetyText;
    [SerializeField] private TextMeshProUGUI customerText;
    [SerializeField] private Script dialogueScript;

    private void Awake()
    {
        // Do not apply changes on Awake. Choices should be applied when the player selects them.
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (safetyText != null && resource != null)
            safetyText.text = "Safety: " + resource.currentSafety;
        if (customerText != null && resource != null)
            customerText.text = "Customer: " + resource.currentCustomer;
    }

    // Call this from a choice button. Provide the node index to jump to after applying the effect.
    public void OnChoiceSelected(int nextNode)
    {
        // Example effects - tweak or expose parameters per button as needed
        if (resource != null)
        {
            resource.currentSafety -= 3;
            resource.currentCustomer -= 3;
        }

        UpdateUI();

        if (dialogueScript != null)
        {
            dialogueScript.Choose(nextNode);
        }
    }
}
