using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftingObjects : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection; // The direction to move (set in Inspector)
    [SerializeField] private float speed = 4f;

    public void MoveObject()
    {
        // Move the object in the specified direction (based on moveDirection)
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }
}
