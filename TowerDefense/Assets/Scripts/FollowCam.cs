using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject targetObject;

    public float followSpeed;
    public Vector3 offset;
    
    
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera_pos = targetObject.transform.position + offset;
        Vector3 lerp_pos = Vector3.Lerp(transform.position, camera_pos, followSpeed);
        transform.position = lerp_pos;
        transform.LookAt(targetObject.transform);
    }
}
