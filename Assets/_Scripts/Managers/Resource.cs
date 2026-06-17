using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Resource : MonoBehaviour
{
    public TextMeshProUGUI HypeText;
    public TextMeshProUGUI SafetyText;
    public TextMeshProUGUI CustomerText;
    public TextMeshProUGUI TeamText;
    [SerializeField] public int currentHype= 10;
    [SerializeField] public int currentSafety= 10;
    [SerializeField] public int currentCustomer= 10;
    [SerializeField] public int currentTeam= 10;
    public int startHype= 10;
    public int startSafety= 10;
    public int startCustomer= 10;
    public int startTeam= 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
{
    currentHype = startHype;
    currentSafety = startSafety;
    currentCustomer = startCustomer;
    currentTeam = startTeam;
}
    // Update is called once per frame
  private void FixedUpdate()
    {
        HypeText.text = "Hype: " + currentHype.ToString();
        SafetyText.text = "Safety: " + currentSafety.ToString();
        CustomerText.text = "Customer: " + currentCustomer.ToString();
        TeamText.text = "Team: " + currentTeam.ToString();
    }
}