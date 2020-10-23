using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MortarProjectile : Projectile
{
    //public Projectile projectile;
    //private Transform target;
    public string enemyTag = "Enemy";
    public SphereCollider thisCollider;
    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision other)
    {
        GameObject explosionGo = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        //Debug.Log(other.collider.name);
    }
}
