using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 8;
    float currFireValue;
    float prevFireValue;
    public Shotgun shotgun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        CheckFire();
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        movement = movement * Time.deltaTime * speed;
        transform.Translate(movement, Space.World);
        Vector2 mouseDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.rotation = Quaternion.LookRotation(new Vector3(mouseDir.x, 0, mouseDir.y), Vector3.up);
    }

    void CheckFire(){
        currFireValue = Input.GetAxisRaw("Fire1");
        if(currFireValue > prevFireValue){
            shotgun.Fire();
        }
        prevFireValue = currFireValue;
    }

    
}
