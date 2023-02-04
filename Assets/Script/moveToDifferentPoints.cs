using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class moveToDifferentPoints : MonoBehaviour
{
    [Tooltip("Velocity of the object")]
    [SerializeField] public float speed;

    [Tooltip("GameObject to move to")]
    [SerializeField] public Transform[] points;

    [Tooltip("Starting point of the platform")]
    [SerializeField] public int currentPoint;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[currentPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, points[index].position) < 0.02f)
        {
            index++;
            if (index == points.Length) {
                index = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[index].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
