using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningRazorBehavior : MonoBehaviour
{
    public Transform playerPosition;

    private void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = playerPosition.position;
        if (CheckChildActive())
            gameObject.SetActive(false);
    }

    private bool CheckChildActive()
    {
        int counter = gameObject.transform.childCount;
        foreach(Transform child in transform)
        {
            if (child.gameObject.activeInHierarchy)
                counter--;
        }
        return counter == gameObject.transform.childCount;
    }
}
