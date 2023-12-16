using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : MonoBehaviour
{
  [field:SerializeField] public float CurrentGoldAmount {  get; private set; }

  public void DepositGold(float amount)
    {
        CurrentGoldAmount += amount;
    }
}
