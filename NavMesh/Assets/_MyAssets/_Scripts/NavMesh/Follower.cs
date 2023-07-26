using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    NavMeshAgent _agent;
    [SerializeField] Transform _destiny;
 
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        //_agent.SetDestination(_destiny.position);
    }

 
    void Update()
    {
        //_agent.SetDestination(_destiny.position);

        if (Input.GetMouseButtonDown(0)) //GetMouseButton GetMouseButtonUp
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);


            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
            {
                _agent.SetDestination(hit.point);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
