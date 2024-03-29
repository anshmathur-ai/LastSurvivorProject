using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bulletPrefab; 

    public Transform bulletSpawn; 

    public float bulletVelocity = 30; 

    public float bulletPrefabLifeTime = 3f; 


    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            FireWeapon(); 
        }
    }

    private void FireWeapon() {
        //instantiate weapon
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity); 

        //shoot bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);

        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime)); 


    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay); 
        Destroy(bullet); 
    }
}
