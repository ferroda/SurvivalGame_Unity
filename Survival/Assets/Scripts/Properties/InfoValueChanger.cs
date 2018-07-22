using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is stand for changing default values of the character, when walking in a designate area (like fire or water).
/// </summary>
public class InfoValueChanger : MonoBehaviour
{
    CharacterProperties characterProperties;

    void Start()
    {
        characterProperties = GameObject.Find("FPSController").GetComponent<CharacterProperties>(); // Access the character.
    }

    private void OnTriggerEnter(Collider collider) // This 'event' is fired when a player walked one of designate area.
    { 
        if (collider.gameObject.tag == "Player")
        {
            characterProperties.Vitality -= 25;
        }
    }

    //  There is no necessary to use Update() method.
}
