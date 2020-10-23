using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPrefab : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ExplosionTimer());
    }

    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
