using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject target = null;
    public float speed = 2.0f;
    public List<GameObject> targets;
    public float timeToUpdate = 0.5f;
    public float currTimeUpdate = 0.0f;
    public Vector2 camPosition;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        currTimeUpdate += Time.deltaTime;
        if (currTimeUpdate > timeToUpdate)
        {
            currTimeUpdate = 0;
            int currTargetIndex = -1;
            float maxX = -999999999999;
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i].transform.position.x > maxX)
                {
                    maxX = targets[i].transform.position.x;
                    currTargetIndex = i;
                }
            }
            if (currTargetIndex != -1)
            {
                target = targets[currTargetIndex];


            }

        }

        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void ChangedActiveSceneCam()
    {
        transform.position = camPosition;
    }

}