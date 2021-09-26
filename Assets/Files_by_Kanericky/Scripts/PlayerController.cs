using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        idle,
        falling,
        death,
    }


    [SerializeField]
    PlayerState playerState;
    
    public PlayerState getPlayerState()
    {
        return playerState;
    }

    public void setPlayerState(PlayerState newState)
    {
        playerState = newState;
    }

}
