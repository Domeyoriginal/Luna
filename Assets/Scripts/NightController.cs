using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightController : MonoBehaviour
{
    float angle = 90;
    float index;
    float speed = (2 * Mathf.PI) / 120; //[ / = seconds ]

    public float radius = 500;
    public float amplitudeY = 500.0f;
    public float omegaY = 1.0f;
    public float highestIntensity;

    public GameObject centreOfWorld;
    public GameObject targetLight;
    public GameObject Moon;
    public GameObject[] skyBox;

    private void Awake()
    {
        targetLight = GameObject.FindGameObjectWithTag("Moon");
    }

    private void Start()
    {
        highestIntensity = targetLight.GetComponent<Light>().intensity;
    }

    private void FixedUpdate()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        index += Time.deltaTime;
        angle += speed * Time.deltaTime;

        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Abs(amplitudeY * Mathf.Sin((omegaY * index) * speed));
        float z = Mathf.Cos(angle) * radius;

        //light and moon poisiton and rotation with worldCetre
        targetLight.transform.position = new Vector3(x, y/2 ,z);
        targetLight.transform.LookAt(centreOfWorld.transform);
        Moon.transform.position = targetLight.transform.position;
        Moon.transform.LookAt(centreOfWorld.transform);

        //light intensity with position of moon
        targetLight.GetComponent<Light>().intensity = (y / amplitudeY) * highestIntensity;

    }
}
