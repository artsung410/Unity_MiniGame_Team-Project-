using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowitzerBullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int Damage;
    [SerializeField] private float lifeTime;


    private void Start()
    {
        StartCoroutine(spawnBullet());
    }

    IEnumerator spawnBullet()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            GetComponent<ParabolaController>().FollowParabola();
        }
    }



    //IEnumerator Deactivation()
    //{
    //    yield return new WaitForSeconds(lifeTime);
    //    HowitzerBulletPool.ReturnObject(this);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        other.gameObject.GetComponent<LivingEntity>().TakeDamage(Damage);
    //        HowitzerBulletPool.ReturnObject(this);
    //    }
    //}
}
