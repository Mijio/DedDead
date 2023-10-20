using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OxygenBar : MonoBehaviour
{
    // Start is called before the first frame update
    private float Oxygen = 100f;
    public Image Bar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Oxygen/100;
    }

}
