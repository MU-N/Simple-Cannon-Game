using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePath : MonoBehaviour
{

    [SerializeField] float intialVelocity;
    [SerializeField] float timeItertaion = .02f;
    [SerializeField] float maxTiem = 10.0f;
    [SerializeField] LayerMask layer;

    LineRenderer lineRenderer;
    Vector3 velocity;



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deleteLine()
    {
        lineRenderer.positionCount = 0;
    }
    public void drawLine()
    {
        velocity = transform.forward * intialVelocity;
        lineRenderer.positionCount = ((int)(maxTiem / timeItertaion));

        int iteration = 0;
        Vector3 currentPostion = transform.position;
        for (float i = 0.0f; i < maxTiem; i += timeItertaion)
        {

            RaycastHit hit;

            if (Physics.Raycast(currentPostion, velocity, out hit, velocity.magnitude * timeItertaion, layer))
            {
                lineRenderer.positionCount = iteration + 2;

                lineRenderer.SetPosition(iteration + 1, hit.point);
                break;
            }



            lineRenderer.SetPosition(iteration, currentPostion);
            currentPostion += velocity * timeItertaion;
            velocity += Physics.gravity * timeItertaion;
            iteration++;
        }
    }
}
