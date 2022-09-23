using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowitzerBullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Damage;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(Deactivation());
    }

    private void Update()
    {
        Vector3 targetPos = AllyHowitzerTurret.Target;
        Speed += Mathf.Pow(Time.deltaTime * 2f, 3);

        if (targetPos != null)
        {
            Vector3 to = targetPos;
            Vector3 from = transform.position;
            Vector3 dir = to - from;

            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }

    IEnumerator Deactivation()
    {
        yield return new WaitForSeconds(lifeTime);
        HowitzerBulletPool.ReturnObject(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            HowitzerBulletPool.ReturnObject(this);
        }
    }
}
