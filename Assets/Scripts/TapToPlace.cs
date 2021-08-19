using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public GameObject ObjectToPlace;
    
    public ARSessionOrigin ARSessionOrigin;
    public ARRaycastManager ARRaycastManager;

    private List<ARRaycastHit> _hits = new List<ARRaycastHit>(); 

    private void Start()
    {
        ObjectToPlace.SetActive(false);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (ARRaycastManager.Raycast(Input.GetTouch(0).position, _hits, TrackableType.Planes))
            {
                ObjectToPlace.SetActive(true);
                ARSessionOrigin.MakeContentAppearAt(ObjectToPlace.transform, _hits[0].pose.position);
            }
        }
    }
}
