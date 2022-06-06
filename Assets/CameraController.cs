using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] Camera cameraObject;
    public float horizontalFoV = 0.5625f;
    // Start is called before the first frame update
    void Start()
    {
        //cameraObject.aspect = 0.5625f;
        //Debug.Log(cameraObject.fieldOfView);

        cameraObject = GetComponent<Camera>();
        cameraObject.orthographicSize = (horizontalFoV / Screen.width * Screen.height / 2.0f);
    }

#if UNITY_EDITOR
    void Update()
    {
        cameraObject.orthographicSize = (horizontalFoV / Screen.width * Screen.height / 2.0f);
    }
#endif
}


