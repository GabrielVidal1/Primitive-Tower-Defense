using UnityEngine;
using System.Collections;

public class CameraRot : MonoBehaviour
{
    public float rotSpeed;
    public bool isDemo;

    void Update()
    {
        if (isDemo)
        {
            transform.Rotate(0f, rotSpeed * Time.deltaTime, 0f);
            return;
        }


        float rot = Input.GetAxis("Horizontal");
        transform.Rotate(0f, rot * rotSpeed * Time.deltaTime, 0f);
    }
}