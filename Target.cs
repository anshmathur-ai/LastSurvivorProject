using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hit " + collision.gameObject.name + "!"); 
            Destroy(gameObject); 
        }
    }
}
