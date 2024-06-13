
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeRotationController : MonoBehaviour
{
    public Slider slider;
    public Text speedText;

    public float minSpeed = 90f;
    public float maxSpeed = 450f;

    private float currentSpeed;

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
        speedText.text = "Rotation Speed: " + currentSpeed.ToString("F0") + " deg/s";
    }

    void OnSliderValueChanged(float value)
    {
        if (value == slider.minValue)
        {
            currentSpeed = minSpeed;
        }
        else if (value == slider.maxValue)
        {
            currentSpeed = maxSpeed;
        }
        else
        {
            currentSpeed = minSpeed;
            slider.value = slider.minValue;
        }
    }

    public void OnHandleClick()
    {
        if (slider.value == slider.minValue)
        {
            slider.value = slider.maxValue;
        }
        else if (slider.value == slider.maxValue)
        {
            slider.value = slider.minValue;
        }
    }
}