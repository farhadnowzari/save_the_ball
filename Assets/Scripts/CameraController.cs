using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool MaintainWidth = true;
    float defaultWidth;
    float defaultHeight;

    Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = Camera.main.transform.position;

        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if(MaintainWidth) {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
            Camera.main.transform.position = new Vector3(cameraPosition.x, -1 * (defaultHeight - Camera.main.orthographicSize),cameraPosition.z);
        } else {
            
        }
    }
}
