using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    private Vector3 cameraoffset = new Vector3();
    private float shaketime = 0.3f;
    private float shakeMagnitude = 0.0f;

    void Start()
    {
        cameraoffset = Vector3.zero;
    }

    void Update()
    {
        if (shaketime > 0.0f)
        {
            shaketime -= Time.deltaTime;

            cameraoffset.x = Random.Range(-shakeMagnitude, shakeMagnitude);
            cameraoffset.y = Random.Range(-shakeMagnitude, shakeMagnitude);

            transform.position = transform.parent.position - Vector3.forward * 2 + cameraoffset;
        }
        else
        {
            transform.position = transform.parent.position - Vector3.forward * 2;
        }

    }

    public void ShakeCamera(float time, float Magnitude)
    {
        shaketime = time;
        shakeMagnitude = Magnitude;
    }
}
