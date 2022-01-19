using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectionMaster : MonoBehaviour
{
    
    public  int remainingSpeed { get; set; }
    public LayerMask rayDetectedLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RayCastToMapObject();
        }
    }

    public void RayCastToMapObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, float.MaxValue, rayDetectedLayers))
        {
            MoveFigureToField(hit);
        }
    }
    
    public void MoveFigureToField(RaycastHit hit)
    {
        FindObjectOfType<MapFigure>().currentTarget = hit.point;
    }
}
