using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerHTML5 : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    private float drag, forceDuration, timeCount, moveForce;
    public GameObject bulletPosition;
    public GameObject bullet;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveForce = 200f;
        drag = myRigidBody.drag;
        forceDuration = 0.1f;
        timeCount = 0f;
    }
    void FixedUpdate()
    {
        HandleMovement();
        timeCount += Time.deltaTime;
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
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletPosition.transform.position,  Quaternion.identity);
        }
        else
        {
            SetForce();
        }
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