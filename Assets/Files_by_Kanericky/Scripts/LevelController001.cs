using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController001 : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    public List<GameObject> cubes;
    public DoorTrigger door;
    public Vector3 respawnPosition;

    public enum LevelState {
        TwoD,
        ThreeD,
    }

    public LevelState levelState;

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
            StartCollapse();
            Destroy(player);
            
            //mainCam.Play("LevelClash");
        }

        if (playerController.getPlayerState() == PlayerController.PlayerState.death)
        {
            RespawnPlayer();
            playerController.setPlayerState(PlayerController.PlayerState.idle);
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(0);
        }

    }

    void RespawnPlayer()
    {
        player.transform.position = respawnPosition;
        player.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void StartCollapse()
    {
        for(int i = 0; i < cubes.Count; i++)
        {
            cubes[i].AddComponent<Rigidbody>();
        }
                

    }

}
