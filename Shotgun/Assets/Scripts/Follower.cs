using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Enemy
{

    float maxhealth = 3;
    float speed = 10;
    Player player;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        health = maxhealth;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move();
    }

    void Move(){
        Vector3 vecToPlayer = player.transform.position - transform.position;
        vecToPlayer.y = 0;
        vecToPlayer = vecToPlayer.normalized;
        Vector3 movement = vecToPlayer * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    
}
