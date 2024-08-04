using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEnergy : MonoBehaviour, IPickupBase
{
    public float recoveryAmount = 10f;

    public void Pickup(Player player)
    {
        player.RecoverEnergy(recoveryAmount);
        gameObject.SetActive(false);
    }
}
