using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = player.transform.position.x; 
        transform.position = position;
    }
}
