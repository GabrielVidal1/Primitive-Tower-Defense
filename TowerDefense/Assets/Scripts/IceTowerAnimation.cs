using UnityEngine;
using System.Collections;

public class IceTowerAnimation : MonoBehaviour
{
    public GameObject core;

    void Update()
    {
        transform.Rotate(0, 60 * Time.deltaTime, 0);

        core.transform.Rotate(0, -60 * Time.deltaTime, 0);
    }
}