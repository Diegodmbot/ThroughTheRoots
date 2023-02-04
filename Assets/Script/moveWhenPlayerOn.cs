using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWhenPlayerOn : MonoBehaviour
{
    [Tooltip("Velocity of the object")]
    [SerializeField] public float speed;

    [Tooltip("GameObject to move to")]
    [SerializeField] public Transform[] points;

    private Transform playerTransform;
    bool isOnElevator = false;

    private int index = 1;
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
        if (isOnElevator)
        {
            if (Vector2.Distance(transform.position, points[index].position) < 0.02f)
            {
                index++;
                if (index == points.Length)
                {
                    index = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);
        }
    }
}
