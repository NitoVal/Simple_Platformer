using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour, IPickupBase
{
    public float healAmount = 10f;

    public void Pickup(Player player)
    {
        player.Heal(healAmount);
        gameObject.SetActive(false);
    }
}
