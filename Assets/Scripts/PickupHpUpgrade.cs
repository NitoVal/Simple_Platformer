using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHpUpgrade : MonoBehaviour, IPickupBase
{
    private bool _bCanBePickup = true;
    public void Pickup(Player player)
    {
        if (_bCanBePickup)
        {
            player.IncreaseHp();
            _bCanBePickup = false;
            gameObject.SetActive(false);
        }
    }
}
