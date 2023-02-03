using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveElevator : MonoBehaviour
{
    bool isOnElevator = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = this.transform;
            isOnElevator = true;
            // Quitar el parent
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnElevator)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(transform.position.x, transform.position.y + 5, transform.position.z),
                Time.deltaTime);
        }
    }
}
