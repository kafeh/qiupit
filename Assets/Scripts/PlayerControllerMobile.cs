using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControllerMobile : MonoBehaviour
{
    private float MoveForce;
    Rigidbody2D MyBody;

    void Start()
    {
        MyBody = this.GetComponent<Rigidbody2D>();
        MoveForce = 200;
    }

    void FixedUpdate()
    {
       // print(new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * MoveForce);
        MyBody.AddForce(new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * MoveForce);
    }
  
}