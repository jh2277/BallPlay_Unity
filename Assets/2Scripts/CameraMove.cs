using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerTransform;
    Vector3 Offset;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    void Start()
    {
        
    }

    // �ڿ� ����ٴ� update�� lateupdate�� ����.
    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset;
    }
}
