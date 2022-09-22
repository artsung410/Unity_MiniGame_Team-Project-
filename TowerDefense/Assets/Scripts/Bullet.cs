using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Damage;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(Deactivation());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    IEnumerator Deactivation()
    {
        yield return new WaitForSeconds(lifeTime);
        BulletPool.ReturnObject(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BulletPool.ReturnObject(this);
        }
    }
}
