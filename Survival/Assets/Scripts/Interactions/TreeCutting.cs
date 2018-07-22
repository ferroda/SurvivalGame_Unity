using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is stand for reduce the resistance of a tree when it's hit.
/// </summary>
public class TreeCutting : MonoBehaviour
{
    float minCut = 1f; 
    float maxCut = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Mouse0 == Left button of the mouse.
        {
            Click();
        }
    }
    /// <summary>
    /// This method will compiled every click.
    /// After a click, the function find the middle of the screen (where I put a little point, for helping the user), then visible a ray, where the player
    /// looking and clicking (for debug it, I set a red ray), then I've created a random number, for get the value of the hit on the tree.
    /// </summary>
    void Click() 
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); // Finding the middle of the monitor.

        RaycastHit hitInfo; 

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 2, Color.red, 2f); // Visible the red ray.

        if (Physics.Raycast(ray, out hitInfo, 8f))  // 8f --> Max distance of the ray.
        {
            if (hitInfo.collider.tag == "tree") // I've set every bole the tree tag.
            {
                // Randoming a number, than subtract it from resistance of the tree.
                var demage = Random.Range(minCut, maxCut);
                
                TreeProperties treeProperties = hitInfo.collider.gameObject.GetComponent<TreeProperties>();
                treeProperties.Resistance -= demage;
            }
        }
    }
}
