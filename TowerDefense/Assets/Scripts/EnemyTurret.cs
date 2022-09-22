using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private GameObject RotatedTurret;
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject BulletPrefabs;

    [Header("Target")]
    [SerializeField] private Transform TargetPoint;

    [Header("TurretOption")]
    [SerializeField] private float RotateSpeed;

    private bool onFire = false;
    public bool isDetactive = false;
    
    private void Start()
    {
        StartCoroutine(Fire());
    }

    private void Update()
    {
        if (false == onFire)
        {
            RotatedTurret.transform.Rotate(0, -1f * Time.deltaTime * RotateSpeed, 0) ;
        }

        else
        {
            Vector3 dir = TargetPoint.position - BulletSpawnPoint.position;
            Gun.transform.rotation = Quaternion.LookRotation(dir);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            onFire = true;
            isDetactive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onFire = false;
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (onFire)
            {
                Bullet bullet = BulletPool.GetObject();
                bullet.gameObject.transform.position = BulletSpawnPoint.position;
                bullet.gameObject.transform.rotation = BulletSpawnPoint.rotation;
            }
        }
    }
}
