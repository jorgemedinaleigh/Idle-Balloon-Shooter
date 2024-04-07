using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BankController : MonoBehaviour
{
    [SerializeField] int startingBalance = 0;
    [SerializeField] TextMeshProUGUI balanceText;

    private int currentBalance;

    private void Start()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance = currentBalance + Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance = currentBalance - Mathf.Abs(amount);
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        balanceText.text = currentBalance.ToString();
    }
}
