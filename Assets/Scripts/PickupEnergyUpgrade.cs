using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEnergyUpgrade : MonoBehaviour, IPickupBase
{
    private bool _bCanBePickup = true;
    public void Pickup(Player player)
    {
        if (_bCanBePickup)
        {
            player.IncreaseMaxEnergy();
            _bCanBePickup = false;
            gameObject.SetActive(_bCanBePickup);
        }
    }
}
