using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsLocked;
    public Vector2 InputVector;

    // Update is called once per frame
    void Update()
    {
        if(!IsLocked)
        {
            InputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
        
    }
}
