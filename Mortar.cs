using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : TurretBehavior
{
    public Rigidbody projectile;
    private Transform target;

    public float h = 25;
    public float gravity = -18;

    public string enemyTag = "Enemy";

    TurretPlace placeTurret;
    public GameObject cannonRotate;

    public bool DebugPath = false;

    void Start()
    {
        //MainFucntions
        placeTurret = GameObject.FindObjectOfType<TurretPlace>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (DebugPath)
            DrawPath();

        if (placeTurret != null)
            placeCheck = placeTurret.isHolding;

        if (!placeCheck)
        {
            placeTurret = null;
            recoilObj.PlaceEvent();
            TurretAI();
        }
    }

    //Mortar ball projectile
    public override void Fire()
    {
        GameObject projectileGo = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        //Projectile projectile = projectileGo.GetComponent<Projectile>();
        Rigidbody pro = projectileGo.GetComponent<Rigidbody>();

        Physics.gravity = Vector3.up * gravity;
        pro.velocity = CalculateLaunchData().initialVelocity;

        Recoil();
    }

    LaunchData CalculateLaunchData()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag(enemyTag);
        if(enemy != null)
        target = enemy.transform;

        float displacementY = target.position.y - firePoint.position.y;
        Vector3 displacementXZ = new Vector3(target.position.x - firePoint.position.x, 0, target.position.z - firePoint.position.z);
        float time = (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / time;
        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }

    void DrawPath()
    {
        LaunchData launchData = CalculateLaunchData();
        Vector3 previousDrawPoint = firePoint.position;

        int resolution = 30;
        for(int i = 1; i <= resolution; i++)
        {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;
            Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = firePoint.position + displacement;
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            previousDrawPoint = drawPoint;
        }
    }

    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData (Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }
    }
}
