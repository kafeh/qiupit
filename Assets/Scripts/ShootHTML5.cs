using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHTML5 : MonoBehaviour
{
    public float speed;
	void Update ()
    {
        Vector2 position = transform.position;
        transform.position = new Vector2(position.x + speed * Time.deltaTime, position.y + speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
