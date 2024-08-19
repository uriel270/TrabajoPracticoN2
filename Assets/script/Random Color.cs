using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            GetComponent<Renderer>().material.color = randomColor;

            Debug.Log("R");
        }
    }
}
