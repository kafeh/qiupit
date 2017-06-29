using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{
    private float playerTargetDistance;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private float damping;
    [SerializeField]
    private GameObject playerTarget;
    private Rigidbody2D enemyRigidBody;

    void Start ()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
	}
	void Update ()
    {
        playerTargetDistance = Vector3.Distance(playerTarget.transform.position, transform.position);
        LookPlayer();
        Attack();
	}
    void LookPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(playerTarget.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
    void Attack()
    {
        if (playerTargetDistance > attackDistance)
        {
            enemyRigidBody.AddForce(transform.forward * enemySpeed);
        }
        else
        {
            Debug.Log("Ataque del enemigo");
        }
    }
}
