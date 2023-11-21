using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFloat : MonoBehaviour
{
    [SerializeField] private float tilt = 35f;

    public float speed;
    private Vector3 target = new Vector3(0, 1.84f, 0);
    

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if(transform.position == target && target.y != 0.4f)
        {
            target.y = 0.4f;
        }
        else if(transform.position == target && target.y == 0.4f)
        {
            target.y = 1.84f;
        }

        transform.Rotate(Vector3.up * Time.deltaTime * tilt);
    }
}
