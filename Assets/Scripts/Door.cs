using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool coroutineAllowed, opened;

    public KeyCheck keyC;
    private void Start()
    {
        coroutineAllowed = true;
        opened = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown("e") && keyC.check_key)
        {
            if (coroutineAllowed)
            {
                StartCoroutine(OpenDoor());
            }
        }
    }
   private IEnumerator OpenDoor()
   {
        coroutineAllowed = false;
        if (!opened)
        {
            for (float i =0f; i >= -180f; i -=10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (opened)
        {
            for (float i = -180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0.01f);
            }
        }
        coroutineAllowed = true;
        opened = !opened;
    }


}
