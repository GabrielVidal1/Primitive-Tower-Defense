using UnityEngine;
using System.Collections;

public class CameraSystem : MonoBehaviour
{
    public Transform player;

    private Vector3 camRelativePos;
    private Vector3 camRelativeRot;

    void Start()
    {
        camRelativePos = GameManager.singleton.camRelativePos;
        camRelativeRot = GameManager.singleton.camRelativeRot;
        transform.position = player.transform.position + camRelativePos;
        transform.Rotate(camRelativeRot);
    }
}