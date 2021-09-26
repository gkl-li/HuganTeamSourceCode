using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController001 : MonoBehaviour
{

    public GameObject player;
    public DoorTrigger door;
    public Vector3 respawnPosition = new Vector3(-7.8f, 0.5f, 2.2f);

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (door.isDoorOpen)
        {
            // TODO: The player pass this level. - Load Next Level
            Debug.Log("PLAYER PASS THE LEVEL!");
        }

        if (playerController.getPlayerState() == PlayerController.PlayerState.death)
        {
            RespawnPlayer();
            playerController.setPlayerState(PlayerController.PlayerState.idle);
        }


    }

    void RespawnPlayer()
    {
        player.transform.position = respawnPosition;
        player.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

}
