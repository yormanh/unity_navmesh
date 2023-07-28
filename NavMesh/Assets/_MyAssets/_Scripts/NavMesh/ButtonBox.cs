using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ButtonBox : MonoBehaviour
{
    [SerializeField]GameObject _puertaObject;
    Animator _animator;
    bool isDentro = false;

    private void Awake()
    {
        _animator = _puertaObject.GetComponent<Animator>();
    }

    public void Use()
    {
        if (isDentro)
            _animator.SetBool("IsOpen", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        isDentro = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isDentro = false;
    }


}
