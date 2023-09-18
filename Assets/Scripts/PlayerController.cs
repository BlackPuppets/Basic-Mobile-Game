using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float touchSpeed = 1;
    
    private Vector2 pastPoisiton;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - pastPoisiton.x);
        }

        pastPoisiton = Input.mousePosition;    
    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * touchSpeed;
    }

}
