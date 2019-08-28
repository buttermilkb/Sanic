using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    void OnMouseDown()
    {
        Application.LoadLevel("SampleScene");
    }
}
