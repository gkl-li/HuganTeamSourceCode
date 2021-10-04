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

    public float walkSpeed = 5f;
    public float jumpSpeed = 2f;

    public LevelController001 levelController;

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

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 p = transform.position;

        if (levelController.levelState == LevelController001.LevelState.TwoD)
        {
            p.x += moveX * walkSpeed * Time.deltaTime;
            p.y += moveY * jumpSpeed * Time.deltaTime;
        }else if (levelController.levelState == LevelController001.LevelState.ThreeD)
        {
            p.z -= moveX * jumpSpeed * Time.deltaTime;
            p.x += moveY * walkSpeed * Time.deltaTime;
        }

        transform.position = p;
    }

}
