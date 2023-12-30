using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    private float speedRotation = 3f;
    private Light m_light;
    private float intensityOnStart;
    private void Start()
    {
        m_light = GetComponent<Light>();
        intensityOnStart = m_light.intensity;
    }
    private void Update()
    {
        float currentRotation = transform.rotation.eulerAngles.x;
        transform.Rotate(1f * speedRotation * Time.deltaTime, 0f, 0f, Space.World);
        if (currentRotation > 0f && currentRotation < 180f)
        {
            m_light.intensity = intensityOnStart;
        }
        else
            m_light.intensity = 0f;
    }
}
