using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Ui : MonoBehaviour

{public Resource resource;
    [SerializeField] TextMeshProUGUI safetyText;
    [SerializeField] TextMeshProUGUI customerText;

    private void Awake()
    {
        changeSafety();
        changeCs();
    }
    public void changeSafety()
    {

        resource.CurrentSafety -= 3;
        safetyText.text = ("Safety: " + resource.CurrentSafety);
    }

    public void changeCs()
    {

        resource.CurrentCustomer -= 3;
        customerText.text = ("Customer: " + resource.CurrentCustomer);
    }
}
