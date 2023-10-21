using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class AwakeRandom : MonoBehaviour
{
    [ListDrawerSettings (ShowIndexLabels = true)]
    [SerializeField] private List<UnityEvent> events;
    
    private void Awake()
    {
        events[Random.Range(0, events.Count)].Invoke();
    }
}
