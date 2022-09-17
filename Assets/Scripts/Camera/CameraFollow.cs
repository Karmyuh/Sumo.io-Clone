using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float chaseSpeed = 5;

    private void Start()
    {
        if (!target)
        {
            target = GameObject.FindObjectOfType<PlayerMovementScript>().transform;
        }
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, chaseSpeed * Time.deltaTime);
    }
}
