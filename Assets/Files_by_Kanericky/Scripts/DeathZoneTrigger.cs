using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour
{

    public PlayerController playerController; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.setPlayerState(PlayerController.PlayerState.death);
        }
    }
}
