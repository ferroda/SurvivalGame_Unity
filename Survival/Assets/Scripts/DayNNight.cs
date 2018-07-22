using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is stand for seperate day and night cycle in the game.
/// </summary>
public class DayNNight : MonoBehaviour
{
    // There is no necessary to use Start() method.

    /// <summary>
    /// This method stand for rotate the Sun and the Moon around the terrain in a given time. 
    /// </summary>
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.left, 12f * Time.deltaTime); // Value 12 is a test number. --> Fast rotation.
        transform.LookAt(Vector3.zero); // Rotate it from the middle of the terrain.
    }

}
