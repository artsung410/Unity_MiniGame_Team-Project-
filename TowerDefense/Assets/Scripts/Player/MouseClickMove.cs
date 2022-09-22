//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MouseClickMove : MonoBehaviour
//{
//    public GameObject targetObject;

//    private Vector3 targetObjectNextPosition;

//    // 파묻히는걸 어떻게 해결해야하는걸까?
//    private float targetObjectHeight;



//    RaycastHit hit;

//    private void Start()
//    {
//        targetObjectNextPosition = targetObject.transform.position;
//        targetObjectHeight = targetObject.GetComponent<MeshRenderer>().bounds.size.y;
//    }

//    private void Update()
//    {
//        if(Input.GetMouseButtonDown(1))
//        {
//            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));


//            Vector3 dir = worldMousePosition - Camera.main.transform.position;

//            if(Physics.Raycast(Camera.main.transform.position, dir, out hit, 100f))
//            {
//                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 0.5f);

//                targetObjectNextPosition = hit.point + new Vector3(0f, targetObjectHeight/2f, 0f);
//                targetObject.transform.position = targetObjectNextPosition;
//            }
//            else
//            {
//                Debug.DrawLine(Camera.main.transform.position, worldMousePosition, Color.blue, 0.5f);

//            }
//        }
//    }
//}
