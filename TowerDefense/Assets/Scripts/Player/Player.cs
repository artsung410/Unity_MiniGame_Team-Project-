using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : LivingEntity
{
    public GameObject player;

    public Slider HealthSlider;

    private Camera mainCam;
    private NavMeshAgent agent;


    private bool _isMove;
    private Vector3 _destination;

    #region public �ʵ�
    //public float MoveSpeed;
    public bool IsDead;

    #endregion


    private void Awake()
    {
        mainCam = Camera.main;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        agent.updateRotation = false;
        IsDead = false;
    }

    private void OnEnable()
    {
        HealthSlider.maxValue = Health;
        HealthSlider.value = Health;

    }

    private void Update()
    {
        //agent.speed = Speed * 4f;
        // ���콺Ŭ�� ��ġ�� ĳ������ �������� ����
        if (IsDead == false)
        {
            agent.speed = MoveSpeed * 4f;
            if (Input.GetMouseButton(1))
            {
                Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 5000f))
                {
                    Debug.DrawLine(mainCam.transform.position, hit.point, Color.blue, 3f);

                    _isMove = true;
                    _destination = hit.point;
                    agent.SetDestination(_destination);
                }
            }

            Move();
        }


    }

    private void Move()
    {
        if (_isMove)
        {
            if (agent.velocity.magnitude == 0f)
            {
                _isMove = false;
                return;
            }

            

            Vector3 direction = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(direction);

            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, targetRot, Time.deltaTime * 500f);
        }
    }

    public override void TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            IsDead = true;
            Debug.Log("�÷��̾� ���");
        }

        Health -= damage;
        HealthSlider.value = Health;
    }
}
