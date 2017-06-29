using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerHTML5 : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    private float drag, forceDuration, timeCount, moveForce, distance, angle;
    public float distanceMax;
    public GameObject enemy;
    public GameObject[] enemies;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveForce = 200f;
        drag = myRigidBody.drag;
        forceDuration = 0.1f;
        timeCount = 0f;
        enemies = new GameObject[3];

        for (int i = 0; i < 3; i++)
        {
            enemies[i] = Instantiate(enemy, new Vector3(Random.Range(-1000.0F, 1000.0F), Random.Range(-1000.0F, 1000.0F), 0), Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
        timeCount += Time.deltaTime;
        //HandleShoot();
    }
    void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddBoost();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SetDrag();
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            ResetDrag();
        }
        else
        {
            SetForce();
        }
    }
    /*void HandleShoot() {
        for (int i = 0; i < 3; i++)
        {
            distance = Vector3.Distance(enemies[i].transform.position, transform.position);
            angle = AngleInDeg(transform.GetChild(0).position, enemies[i].transform.position);
            //Debug.Log("Angulo en enemigo " + i + ": "+  angle);
            /*float distance_ = Vector3.Distance(transform.position, Camera.main.ViewportToWorldPoint(new Vector2(1,1)));
            Debug.Log("Distancia player y camara " + distance_);
            Debug.Log("Distancia player y enemigo " + distance);

            if (distance < distanceMax && angle < 90 && angle > 0)
            {
                Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity);
            }
        }
    }*/
   float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x) * 180 / Mathf.PI; 
    }
    public void ResetDrag()
    {
        myRigidBody.drag = drag;
    }
    public void SetDrag()
    {
        myRigidBody.drag = drag + 3;
    }

    public void AddBoost()
    {
        myRigidBody.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveForce * 50);
    }
    public void SetForce()
    {
            if (timeCount < forceDuration)
            {
                myRigidBody.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveForce);
            }
            else
            {
                ResetForce();
            }
    }
    public void ResetForce()
    {
        myRigidBody.AddForce(Vector3.zero);
        timeCount = 0.0f;
    }
}