using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float oxygenMax = 100;
    [SerializeField] private float oxygenDecreaseSpeed = 1;
    [SerializeField] private Image oxygenBar;
    
    private float oxygen;
    
    [SerializeField, ReadOnly] private PlayerController playerController;
    
    [SerializeField] private UnityEvent onWin;
    
    private void Start()
    {
        oxygen = oxygenMax;
    }
    
    public void AddOxygen(float value)
    {
        oxygen += value;
        if (oxygen > oxygenMax)
            oxygen = oxygenMax;
        UpdateOxygenBar();
    }

    private void Update()
    {
        if (!playerController.IsAlive) return;
        oxygen -= oxygenDecreaseSpeed * Time.deltaTime;
        if (oxygen <= 0)
        {
            onWin?.Invoke();
            playerController.Die();
            return;
        }
        UpdateOxygenBar();
    }
    private void UpdateOxygenBar()
    {
        oxygenBar.fillAmount = oxygen / oxygenMax;
    }

    private void OnValidate()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
}
