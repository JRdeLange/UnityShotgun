using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected float health;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        print("starta");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (health <= 0){
            Death();
        }
    }

    void Damage(float damage){
        health -= damage;
    }

    void Death(){
        Destroy(gameObject);
    }
}
