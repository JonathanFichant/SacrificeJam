using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private float offsetY;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 tempPosition = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, offsetY, 0), speed * Time.deltaTime); ;
        tempPosition.z = -10f;
        transform.position = tempPosition;

    }
}