using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D SelectedObject;

    private Vector2 DeltaPosition;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Move
        if (SelectedObject)
        {
            SelectedObject.velocity = Vector2.zero;
            SelectedObject.position = mousePosition;      
        }

        //Grab
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {            
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                SelectedObject = targetObject.GetComponent<Rigidbody2D>();
            }
        }

        //Drop
        if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (SelectedObject)
            {
                Vector2 input = Input.mousePosition;
                SelectedObject.AddForce((input - DeltaPosition) / 5, ForceMode2D.Impulse);
                SelectedObject = null;
            }
        }

        DeltaPosition = Input.mousePosition;
    }
}