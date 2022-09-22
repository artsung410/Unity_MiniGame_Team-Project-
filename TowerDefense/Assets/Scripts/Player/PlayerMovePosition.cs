using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovePosition : MonoBehaviour
{
    public GameObject player;

    private Camera mainCam;
    private NavMeshAgent agent;

    private bool _isMove;
    private Vector3 _destination;

    private void Awake()
    {
        mainCam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.updateRotation = false;
    }

    private void Update()
    {
        // 마우스클릭 위치를 캐릭터의 목적지로 설정
        if (Input.GetMouseButton(1))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _isMove = true;
                _destination = hit.point;
                agent.SetDestination(_destination);
            }
        }
        Move();
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

}
