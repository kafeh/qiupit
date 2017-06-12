using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaMovement : MonoBehaviour {

    Vector3 lastPosition;
    Vector3 deltaPosition;
    Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        lastPosition = transform.position;
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        deltaPosition = lastPosition - transform.position;
        //print(deltaPosition);
        print(rigid.velocity);
        lastPosition = transform.position;
        if (rigid.velocity.x == 0)
        {
            print("Se detuvooooo");
        }
	}
}
