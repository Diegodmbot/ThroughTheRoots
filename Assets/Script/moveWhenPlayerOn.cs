using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWhenPlayerOn : MonoBehaviour
{
    [Tooltip("Determines in wich axis the platform will move")]
    [SerializeField] private bool moveOnX = false;

    [Tooltip("The max position the platform can reach")]
    [SerializeField] private Transform finalPositionTransform;

    private Transform playerTransform;
    bool isOnElevator = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTransform = other.transform;
            other.gameObject.transform.parent = this.transform;
            isOnElevator = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTransform = null;
            other.gameObject.transform.parent = null;
            isOnElevator = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (isOnElevator)
        //{
        //    float playerPosition, finalPosition;
        //    if(moveOnX)
        //    {
        //        playerPosition = transform.position.x;
        //        finalPosition = finalPositionTransform.position.x;
        //    }
        //    else
        //    {
        //        playerPosition = transform.position.y;
        //        finalPosition = finalPositionTransform.position.y;
        //    }
        //    //cambiar a plataforma movil ciclica
        //    if (playerPosition > finalPosition)
        //    {
        //        playerTransform.parent = null;
        //        isOnElevator = false;
        //        return;
        //    }
        //}
        if (isOnElevator)
        {
            if (moveOnX)
            {
                if (transform.position.x > finalPositionTransform.position.x)
                {
                    playerTransform.parent = null;
                    isOnElevator = false;
                    return;
                }
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(transform.position.x + 5, transform.position.y, transform.position.z),
                    Time.deltaTime);
            }
            else
            {
                if (transform.position.y > finalPositionTransform.position.y)
                {
                    playerTransform.parent = null;
                    isOnElevator = false;
                    return;
                }
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(transform.position.x, transform.position.y + 5, transform.position.z),
                    Time.deltaTime);
            }
        }
    }
}
