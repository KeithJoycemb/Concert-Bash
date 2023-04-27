using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour
{
    public GameObject player;
    public GameObject underStage;
    public GameObject lounge;
    public GameObject startingRoom;
    public GameObject bathroom;
    public GameObject danceFloor;

    public void startRoom()
    {
        player.gameObject.transform.position = startingRoom.gameObject.transform.position;
    }
    public void underRoom()
    {
        player.gameObject.transform.position = underStage.gameObject.transform.position;
    }
    public void loungeRoom()
    {
        player.gameObject.transform.position = lounge.gameObject.transform.position;
    }
    public void bathRoom()
    {
        player.gameObject.transform.position = bathroom.gameObject.transform.position;
    }
    public void danceRoom()
    {
        player.gameObject.transform.position = danceFloor.gameObject.transform.position;
    }
    
}
