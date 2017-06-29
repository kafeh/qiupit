using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerMobile : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    private float  distance, angle, moveForce;
    public float distanceMax;
    public GameObject bullet, enemy;
    public GameObject[] enemies;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveForce = 200f;
        enemies = new GameObject[3];

        for (int i = 0; i < 3; i++)
        {
            enemies[i] = Instantiate(enemy, new Vector3(Random.Range(-1000.0F, 1000.0F), Random.Range(-1000.0F, 1000.0F), 0), Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        myRigidBody.AddForce(new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce);
        HandleShoot();
    }
    void HandleShoot()
    {
        for (int i = 0; i < 3; i++)
        {
            distance = Vector3.Distance(enemies[i].transform.position, transform.position);
            angle = AngleInDeg(transform.GetChild(0).position, enemies[i].transform.position);
            //Debug.Log("Angulo en enemigo " + i + ": " + angle);
            /*float distance_ = Vector3.Distance(transform.position, Camera.main.ViewportToWorldPoint(new Vector2(1,1)));
            Debug.Log("Distancia player y camara " + distance_);
            Debug.Log("Distancia player y enemigo " + distance);*/

            if (distance < distanceMax && angle < 90 && angle > 0)
            {
                Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity);
            }
        }
    }
    float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x) * 180 / Mathf.PI;
    }

}