using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minCameraDistance = 1.0f;
    public float maxCameraDistance = 4.0f;
    public float cameraSmooth = 10.0f;
    Vector3 dollyDir;
    Vector3 dollyDirAdjusted;
    Vector3 cameraOffset;
    public Vector3 cameraOffsetChange;
    public float distance;
    float initialDistance;
    LineRenderer lineRenderer;
    public LayerMask mask;
    public RaycastHit raycastHit;
    public float maxDistance = 200.0f;

    private void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        initialDistance = transform.localPosition.magnitude;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
           
    }

    
    void Update()
    {
        cameraOffset = new Vector3(0, 0, 0);

        Vector3 desiredLocation = transform.parent.TransformPoint(dollyDir * initialDistance);
        RaycastHit hit;
        Debug.DrawLine(transform.parent.position, desiredLocation);

        if(Physics.Linecast(transform.parent.position,desiredLocation,out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.9f, minCameraDistance, maxCameraDistance);
            //Debug.Log(hit.collider.gameObject);
        }
        else
        {
            distance = maxCameraDistance;
        }

        if (Input.GetMouseButton(1))
        {
            distance = minCameraDistance;
            cameraOffset += cameraOffsetChange;

            List<Vector3> positions;
            
            TrajectorySetup.CurveCast(transform.position + transform.forward,transform.forward, new Vector3(0, -10, 0), 10, out raycastHit, maxDistance, out positions,mask);
            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
            for (int i = 0; i < positions.Count-1; i++)
            {
                Debug.DrawLine(positions[i], positions[i + 1]);
            }
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
        

        transform.localPosition = Vector3.Slerp(transform.localPosition, dollyDir * distance + cameraOffset, Time.deltaTime * cameraSmooth);
    }
}
