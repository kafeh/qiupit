using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour {
    bool up;
	void Start () {
        up = true;
        InvokeRepeating("Idle", 0f, 0.8f);
    }
    void Idle()
    {
        if (up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            up = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
            up = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        ItemsController.DestroyItem(gameObject);
    }
}
