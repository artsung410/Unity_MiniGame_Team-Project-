using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform TargetPoint;

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
                transform.Translate(transform.forward * Time.deltaTime * MoveSpeed);
            }
        }
    }
}
