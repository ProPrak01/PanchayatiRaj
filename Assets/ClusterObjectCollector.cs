using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterObjectCollector : MonoBehaviour
{
    Rules rules; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = castray();
            rules.buildingPos = hit.collider.gameObject.transform.position;
        }

        
    }


    RaycastHit castray()
    {
        Vector3 mouseScreenPosfar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mouseScreenPosNear= new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mouseWorldPosNear = Camera.main.ScreenToWorldPoint(mouseScreenPosNear);
        Vector3 mouseWorldPosfar = Camera.main.ScreenToWorldPoint(mouseScreenPosfar);

        RaycastHit hit;
        Physics.Raycast(mouseWorldPosNear, mouseWorldPosfar - mouseWorldPosNear, out hit);
        return hit;

    }
}
