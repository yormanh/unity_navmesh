using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    NavMeshAgent _agent;
    [SerializeField] Transform _destiny;
    [SerializeField] Transform _puntero;
 
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

            RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, 1000);

            //for(int i =0; i < hits.Length; i++)
            //{
            //    //hits[i];
            //}

            bool isRampa = false;
            foreach (var hit in hits)
            {


                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Suelo"))
                {
                    if(hit.collider.name == "Rampa")
                    {
                        isRampa = true;
                        _agent.SetDestination(hit.point);
                        _puntero.position = hit.point;
                        _puntero.rotation = Quaternion.LookRotation(hit.normal);

                    }
                    else if (isRampa == false)
                    {
                        _agent.SetDestination(hit.point);
                        _puntero.position = hit.point;
                        _puntero.rotation = Quaternion.LookRotation(hit.normal);
                    }
                }

                ButtonBox buttonBox = hit.collider.GetComponent<ButtonBox>();
                if (buttonBox)
                {
                    //buttonBox.Use();
                }


            }



            //RaycastHit hit;
            //if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
            //{
            //    //_agent.SetDestination(hit.point);
            //    Debug.Log(hit.collider.gameObject.name);

            //    ButtonBox buttonBox = hit.collider.GetComponent<ButtonBox>();

            //    if (buttonBox)
            //    {
            //        //buttonBox.Use();
            //    }
            //    else
            //    {
            //        _agent.SetDestination(hit.point);
            //    }

            //}
        }
    }
}
