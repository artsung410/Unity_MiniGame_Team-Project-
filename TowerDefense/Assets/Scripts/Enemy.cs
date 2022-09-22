using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform TargetPoint;
    [SerializeField] private Transform FinishPoint;
    [SerializeField] private GameObject Sword;

    [Header("EnemySettings")]
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float AttackSpeed;
    [SerializeField] private float RotateSpeed;

    public bool isDetactive = false;

    void Start()
    {
        StartCoroutine(MoveAndAttack());
    }

    private IEnumerator MoveAndAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.01f);

            if (false == isDetactive)
            {
                Vector3 dir = FinishPoint.position - transform.position;
                transform.rotation = Quaternion.LookRotation(dir);
                Sword.GetComponent<Animator>().SetBool("onAttack", false);
                MoveTo();
            }

            else
            {
                Vector3 dir = TargetPoint.position - transform.position;
                float Distance = Vector3.Distance(TargetPoint.position, transform.position);
                transform.rotation = Quaternion.LookRotation(dir);

                if (Distance < 2f)
                {
                    Sword.GetComponent<Animator>().SetBool("onAttack", true);
                }

                else
                {
                    Sword.GetComponent<Animator>().SetBool("onAttack", false);
                    MoveTo();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isDetactive = true;
        }
    }

    private void MoveTo()
    {
        transform.Translate(transform.forward * Time.deltaTime * MoveSpeed);
    }
}
