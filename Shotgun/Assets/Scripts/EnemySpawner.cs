using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Enemy follower;
    float halfScreenWidth;
    float halfScreenHeight;
    Constants constants;
    float timeBetweenFollowers = 0.1f;
    float nextFollowerSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextFollowerSpawnTime < Time.timeSinceLevelLoad){
            SpawnFollower();
            nextFollowerSpawnTime += timeBetweenFollowers;
        }
    }

    void SpawnFollower(){
        Vector3 pos = Vector3.one;

        //decide the side
        int side = Random.Range(0, 4);
        if (side == 0 || side == 1){ // top
            pos.x = Random.Range(-constants.sideOutOfScreen - constants.outOfScreenMargin, constants.sideOutOfScreen + constants.outOfScreenMargin);
            pos.z = constants.topOutOfScreen + constants.outOfScreenMargin;
            if (side == 1){
                pos.z *= -1;
            }
        } else if (side == 2 || side == 3){ // left
            pos.x = constants.sideOutOfScreen + constants.outOfScreenMargin;
            pos.z = Random.Range(-constants.topOutOfScreen - constants.outOfScreenMargin, constants.topOutOfScreen + constants.outOfScreenMargin);
            if (side == 3){
                pos.x *= -1;
            }
        }

        pos.y = follower.transform.localScale.y;
        Instantiate(follower, pos, Quaternion.identity);
    }
}
