using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMovement;
    [SerializeField] private PlayerAnimation playerAnimation;

    public event Action<string> GoalReached;
    private void Update()
    {
        if (playerAnimation.GoalReached())
        {
            MovePlayer();
        }
        else
        {
           GameManager.instance.PrintGameOver();
        }
        

    }

   

    private void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerMovement.PlayerMovement(move);
        playerAnimation.WalkAnimation(Input.GetAxis("Vertical"));
        playerMovement.CheckBoundary();
    }
}
