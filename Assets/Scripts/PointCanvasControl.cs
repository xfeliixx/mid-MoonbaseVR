using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCanvasControl : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        //control the rotation of the panel
        transform.LookAt(Camera.main.transform);

        //destry the canvas after time
        Destroy(gameObject, 3);
    }
}
