using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        player = GameMan.player.gameObject.transform;
    }
    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(player.position.x, player.position.y, -3);   
    }

}
