
/***
 * Author: Logan
 * Created: 1/30/2022
 * Last Modifed: never
 *
 * Last Modified by: Logan
 * Last modified date: None
 *
 * Purpose: ApplePicker Tree movement and apple-drop logic
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AppleTree : MonoBehaviour
{

    [Header("Set in Inspector")]

    public GameObject applePrefab; //Prefab for apple instances

    public float speed = 1f; //Speed at which apple tree moves
    public float leftAndRightEdge = 10f; //Distance at which appletree will turn around
    public float chanceToChangeDirections = 0.1f; //Chance per frame that apple tree will change directions
    public float secondsBetweenAppleDrops = 1f; //Rate at which apples are made



    // Start is called before the first frame update
    void Start()
    {
        //Drop apples every second
        Invoke("DropApple",2f); //Invoke the DropApple function in 2 seconds
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position=transform.position; //Move the apple to the tree's position.
        Invoke("DropApple",secondsBetweenAppleDrops); //Call ourselves again soon.
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos; //Update tree position over time

        //Changing directions

        if(pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed); // Move Right
        } else if(pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate(){
        //Changing directions randomly is now time-based because of FixedUpdate.
        if(Random.value < chanceToChangeDirections){ //Randomly change direction
            speed *= -1;
        }
    }
}
