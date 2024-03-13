using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandprintScript1 : MonoBehaviour
{

    public GameObject Door;
    public GameObject SpectralHandprint;
    public float moveDistance = 1.0f;


    void Update()
    {

        Vector3 currentPosition = Door.transform.position;

        Vector3 newPosition = new Vector3(currentPosition.x, currentPosition.y + moveDistance);

        Door.transform.position = newPosition;

        SpectralHandprint.SetActive(false);

        Destroy(gameObject);
    }
}
