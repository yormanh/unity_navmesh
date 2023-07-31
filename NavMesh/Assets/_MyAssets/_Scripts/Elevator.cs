using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elevator : MonoBehaviour
{
    Animator _animator;
    bool _bInSide;
    //bool _bTopFloor;
    int _pisoActual;
    NavMeshAgent _agent;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();       
    }


    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _bInSide == true)
        {
            _pisoActual = _pisoActual == 1 ? 0 : 1;

            //_bTopFloor = !_bTopFloor;
            _animator.SetBool("IsUp", _pisoActual == 0);

            _agent.enabled = false;
            _agent.transform.SetParent(transform);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            _agent = other.transform.GetComponent<NavMeshAgent>();
            _bInSide = true;

        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            _bInSide = false;
        }
    }

   

    public void OnElevatorEstado(int piso)
    {
        //Debug.Log("piso: " + piso);
        //print($"Piso: {piso}");

        _pisoActual = piso;
        _agent.enabled = true;
        _agent.transform.SetParent(null);

    }


}
