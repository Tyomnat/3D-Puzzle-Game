using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public GameObject sphere;
    bool sss = true;
    /*Quaternion _start, _end;
    [SerializeField, Range(0.0f, 360f)]
    float _angle = 60f; //90f
    [SerializeField, Range(0.0f, 5.0f)]
    float _speed = 2.0f;
    [SerializeField, Range(0.0f, 10.0f)]
    float _startTime = 0.0f;*/

    // Start is called before the first frame update
    void Start()
    {
        /*_start = PendulumRotation(_angle);
        _end = PendulumRotation(-_angle);*/
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CoUpdate());
    }

    IEnumerator CoUpdate()
    {
        if (sss)
        {
            yield return new WaitForSeconds(3);
            sss = false;
            float temp = sphere.transform.rotation.z;
            if (temp < 0)
            {
                sphere.GetComponent<Rigidbody>().angularVelocity = new Vector3(100f, sphere.GetComponent<Rigidbody>().angularVelocity.y, sphere.GetComponent<Rigidbody>().angularVelocity.z);
                sphere.GetComponent<Rigidbody>().velocity = new Vector3(100f, sphere.GetComponent<Rigidbody>().velocity.y, sphere.GetComponent<Rigidbody>().velocity.z);
            }
            else if (temp >= 0) { 
                sphere.GetComponent<Rigidbody>().angularVelocity = new Vector3(-100f, sphere.GetComponent<Rigidbody>().angularVelocity.y, sphere.GetComponent<Rigidbody>().angularVelocity.z);
                sphere.GetComponent<Rigidbody>().velocity = new Vector3(-100f, sphere.GetComponent<Rigidbody>().velocity.y, sphere.GetComponent<Rigidbody>().velocity.z);
            }
            sss = true;
        }
    }

    private void FixedUpdate()
    {
        /*_startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);*/
    }

   /* Quaternion PendulumRotation(float angle)
    {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;
        if (angleZ > 180)
        {
            angleZ -= 360;
        }
        else if (angleZ < -180)
        {
            angleZ += 360;
        }

        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
        return pendulumRotation;
    }

    void ResetTimer()
    {
        _startTime = 0.0f;
    }*/
}
