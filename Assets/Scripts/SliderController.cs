using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    Slider slider;
    float timer = 0f;
    public bool full = true;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void GetPoints()
    {
        slider.value = slider.minValue;
        timer = 0f;
        full = false;
    }

    public void Charge()
    {
        StartCoroutine(ChargePoint());
    }
    IEnumerator ChargePoint()
    {
        yield return new WaitForSeconds(0.25f);
        slider.value = slider.maxValue / 2;
        yield return new WaitForSeconds(0.25f);
        slider.value = slider.maxValue;
        full = true;
    }
}
