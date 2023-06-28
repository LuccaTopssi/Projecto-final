using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_soga : MonoBehaviour
{
    public Vector3 fuerzaPrueba;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.GetChild(transform.childCount -1).GetComponent<Rigidbody2D>(). AddForce(fuerzaPrueba, ForceMode2D.Impulse);
        }
    }
}
