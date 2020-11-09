using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciever : MonoBehaviour, IEntity
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public FPSController playerController;
    
    void Start()
    {
        playerController = GetComponent<FPSController>();
    }

    public void ApplyDamage(float points)
    {
        playerHP -= points;

        if (playerHP <= 0)
        {
            //Player is dead
            playerController.canMove = false;
            playerHP = 0;
        }
    }
}
