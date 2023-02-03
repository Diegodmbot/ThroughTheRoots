using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movePlatform : MonoBehaviour
{
    [Tooltip("Determines in wich axis the platform will move")]
    [SerializeField] private bool moveOnX = false;

    [Tooltip("The initial position the platformh")]
    [SerializeField] private Transform initialPositionTransform;

    [Tooltip("The max position the platform can reach")]
    [SerializeField] private Transform finalPositionTransform;

    public float speed = 6;
    private bool goForward = true;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    
    bool isInRangeX(float xPosition) {
        return (xPosition > initialPositionTransform.position.x) && (xPosition < finalPositionTransform.position.x);
    }

    bool isInRangeY(float yPosition)
    {
        return (yPosition > initialPositionTransform.position.y) && (yPosition < finalPositionTransform.position.y);
    }

    // Update is called once per frame
    void Update()
    {   
        if (moveOnX)
        {
            if (!isInRangeX(transform.position.x)) goForward = !goForward;
            float finalSpeed = speed * (goForward ? 1 : -1);

            transform.Translate(Vector3.right * Time.deltaTime * finalSpeed);
        }
        else
        {
            if (!isInRangeY(transform.position.y)) goForward = !goForward;
            float finalSpeed = speed * (goForward ? 1 : -1);

            transform.Translate(Vector3.up * Time.deltaTime * finalSpeed);
        }
    }
}
