using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnColliderEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent onCollisionEnter;
    [SerializeField] private UnityEvent onCollisionExit;
    
    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onTriggerExit;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        onCollisionEnter.Invoke();
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        onCollisionExit.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter.Invoke();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        onTriggerExit.Invoke();
    }
}
