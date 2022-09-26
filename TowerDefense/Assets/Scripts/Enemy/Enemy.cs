using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : LivingEntity
{
    [SerializeField] private Transform TargetPoint;
    [SerializeField] private Transform FinishPoint;
    [SerializeField] private GameObject Sword;


    private UnityEngine.AI.NavMeshAgent agent;
    public bool isDetactive = false;

    private int _giveGold;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        StartCoroutine(MoveAndAttack());
        agent.SetDestination(FinishPoint.position);

        _giveGold = 300;

    }

    private IEnumerator MoveAndAttack()
    {
        while(true)
        {

            yield return new WaitForSeconds(0.01f);

            if (false == isDetactive)
            {
                Vector3 direction = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
                Quaternion targetRot = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * 500f);
                Sword.GetComponent<Animator>().SetBool("onAttack", false);
            }
            else
            {
                //agent.ResetPath();
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
    
    public override void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            GameManager.Instance.PlayerGold += _giveGold;
            ++GameManager.Instance.EnemyDeathCount;
            
            Health = 100;
            Destroy(gameObject);
            //EnemyPool.ReturnObject(this);
            return;
        }

        Health -= damage;
    }
}
