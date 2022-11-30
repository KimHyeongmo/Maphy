using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot_change_information : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(slot_change());
    }

    IEnumerator slot_change()
    {
        while (true)
        {
            transform.position = transform.position == slot1.transform.position ? slot2.transform.position : slot1.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
