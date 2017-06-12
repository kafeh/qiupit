using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
    private float timeCount;

    void Start () {
        timeCount = 0f;
    }
	
	void Update () {
        timeCount += Time.deltaTime;

    }
    void PutItem()
    {

    }
}
