using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Enemy
{

    float maxhealth = 3;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = maxhealth;
        print("startb");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        health -= 1f/60f;
        print("B");
    }
}
