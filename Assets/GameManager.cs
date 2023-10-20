using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float oxygenMax = 100;
    [SerializeField] private float oxygenDecreaseSpeed = 1;
    [SerializeField] private Image oxygenBar;
    
    private float oxygen;
    
    

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
        oxygen -= oxygenDecreaseSpeed * Time.deltaTime;
        if (oxygen <= 0)
        {
            Debug.Log("Game Over");
            return;
        }
        UpdateOxygenBar();
    }
    private void UpdateOxygenBar()
    {
        oxygenBar.fillAmount = oxygen / oxygenMax;
    }
    
}
