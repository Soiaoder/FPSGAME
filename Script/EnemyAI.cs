using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private Vector3 tmpPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        tmpPos =player.position;
        tmpPos.y=transform.position.y;
        transform.LookAt(tmpPos);
        transform.Translate(Vector3.forward * Time.deltaTime * 2);
    }
}
