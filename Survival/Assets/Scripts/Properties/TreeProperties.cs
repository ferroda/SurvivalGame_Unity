using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is stand for setting the default properties of a tree (like resistance or mass).
/// This class modelling when a tree cut, how will it falling to the ground.
/// </summary>
public class TreeProperties : MonoBehaviour
{
    // I'm using public access modifier, so I can manipulate it in Unity, for debug.
    public float Resistance = 25f; // Setting a default resistance value.

    GameObject thisTree;  
    private Rigidbody rb; // Class Rigidbody is stand for modelling a realistic body in Unity.

    void Start ()
    {
        thisTree = transform.parent.gameObject;
        rb = thisTree.GetComponent<Rigidbody>(); 
        rb.mass = 60; // We can set a default mass value of a tree.

        rb.isKinematic = true;   
        rb.useGravity = false;
    }
	
	void Update ()
    {
        if (Resistance <= 0)
        {
            rb.useGravity = true;  
            rb.isKinematic = false;

            rb.AddForce(Vector3.forward, ForceMode.Impulse); // Give more force when a tree is falling.
            StartCoroutine(TreeDestroyer()); 
        }
    }

    // Deleting the tree from the terrain with this interface.
    IEnumerator TreeDestroyer()
    {
        yield return new WaitForSeconds(15);  // The tree will disappears within 15 seconds.
        Destroy(thisTree);
    }
}
