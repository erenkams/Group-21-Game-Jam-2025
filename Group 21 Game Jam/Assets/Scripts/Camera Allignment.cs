using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAllignment : MonoBehaviour
{
    public Transform target;         // Oyuncu objesi
    public float smoothTime = 0.2f;  // Takip yumuþaklýðý

    private Vector3 velocity = Vector3.zero;
    public float yMin = 0f;          // Y ekseni alt limiti
    public float yMax = 5f;          // Y ekseni üst limiti (opsiyonel)

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
