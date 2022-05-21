using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public SliderController[] sliders;
    
    public float timer = 0;


    private void Update()
    {        
        if (timer <= 0.5f)
        {
            OnePoint();
            timer += Time.deltaTime;
        }
        timer = timer > 0.5f ? 0 : timer;
    } 

    void OnePoint()
    {
        foreach (var s in sliders)
        {
            if(s.full == false)
            {
                s.Charge();
                break;
            }
        }
    }

    public void GetPoint(int points)
    {
        for (int i = 0; i < points; i++)
        {
            for (int j = 0; j < sliders.Length; j++)
            {
                if (sliders[j].full == true)
                {
                    sliders[j].GetPoints();
                    break;
                }
            }
        }
    }
}
