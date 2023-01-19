using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AthmosphereBar : MonoBehaviour
{
    public Slider slider;
    private float currentAir = 1f;
    public float decreaseSpeed = 0.01f;
    public Health health;

    private void Start()
    {
        slider.maxValue = 1f;
        slider.value = currentAir;
    }
    private void Update()
    {
        currentAir -= decreaseSpeed * Time.deltaTime;
        slider.value = currentAir;

        if(slider.value == 0)
        {
            health.TakeDamage(1);
            replenishAir();
        }
    }
    //IEnumerator decreaseAir()
    //{
    //    float startTime = Time.deltaTime;
    //    while (currentAir > 0)
    //    {
    //        float elapsedTime = Time.deltaTime - startTime;
    //        currentAir -= (decreaseSpeed * elapsedTime) / 10f;
    //        yield return new WaitForSeconds(1);
    //    }
    //}

    public void replenishAir()
    {
        currentAir = 1f;
    }

}
