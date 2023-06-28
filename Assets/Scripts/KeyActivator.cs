using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivator : MonoBehaviour
{ 
    public KeyCheck keyC;
    public SpriteRenderer sR;

    private void Start()
    {
        keyC = GetComponent<KeyCheck>();
    }

    private void Update()
    {
        if (keyC.check_key)
        {
            sR.gameObject.SetActive(true);
        }
    }

}
