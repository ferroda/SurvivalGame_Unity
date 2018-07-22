using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson; // Its necessary to referring the FirstPerson.

/// <summary>
/// This class stand for setting, manipulating and write the values of the charater status to the textboxes/panels.
/// </summary>
public class CharacterProperties : MonoBehaviour
{
    FirstPersonController character;

    // ---  Setting the default values of the character.  ---
    public float Vitality = 100f;
    float vitalityDecrease = .2f;

    // I'm using public access modifier, so I can manipulate it in Unity, for debug.
    public float Stamina = 5f;
    float staminaDecrease = 1f;

    public float Hunger = 100f;
    float hungerDecrease = .2f;

    public float Thirst = 100f;
    float thirstDecrease = .2f;

    float normalStamina; // Using temp value for stamina.

    public Text VitalityText, StaminaText, HungerText, ThirstText;

    public Color colorOfThePanel;
    Image panel;


    void Start()
    {
        normalStamina = Stamina;

        // Finding and access the text of the gameobjects. I've named it in Unity.
        VitalityText = GameObject.Find("VitalityText").GetComponent<Text>();
        StaminaText = GameObject.Find("StaminaText").GetComponent<Text>();
        HungerText = GameObject.Find("HungerText").GetComponent<Text>();
        ThirstText = GameObject.Find("ThirstText").GetComponent<Text>();

        character = GetComponent<FirstPersonController>(); // Access the character.
    }

// I must use 4 methods for manipulating data, because all of the properties have different settings inside them.

    public void VitalityChanger()
    {
        if (Thirst <= 0 || Hunger <= 0)
        {
            Vitality -= Time.deltaTime * vitalityDecrease; // If there is hunger and thirst, the vitality decrease.
        }

        if (Vitality <= 0.99)  // Adding a red color for the textbox/panel.
        {
            panel = GameObject.Find("VitalityPanel").GetComponent<Image>();
            colorOfThePanel = new Color(1.0f, .0f, .0f, .75f);
            panel.color = colorOfThePanel;
            Vitality = 0; // Dont allow minus values.
        }
        else
        {
            // 0 feletti
            panel = GameObject.Find("VitalityPanel").GetComponent<Image>();
            colorOfThePanel = new Color(1.0f, .627f, .478f, .6f);
            panel.color = colorOfThePanel;
        }
    }

    public void StaminaChanger()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // Running.
        {
            Stamina -= Time.deltaTime * staminaDecrease; // // It will be less than 0.1.
            Hunger -= Time.deltaTime * hungerDecrease * 2;
            Thirst -= Time.deltaTime * thirstDecrease * 2;
        }
        else
        {
            if (Stamina <= normalStamina) // Allow regeneration.
            {
                Stamina += Time.deltaTime * (staminaDecrease / 2);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) // Jump.
        {
            Stamina -= staminaDecrease;
        }

        if (Stamina <= 0) // If stamina is 0, the character can't run.
        {
            character.IsRun = false; // I've write a bool variable and a getter-setter in FirstPersonController.cs
            Stamina = 0;
        }
        else
        {
            character.IsRun = true; 
        }
        
        if (Stamina <= 0.99)
        {
            panel = GameObject.Find("StaminaPanel").GetComponent<Image>();
            colorOfThePanel = new Color(1.0f, .0f, .0f, .75f);
            panel.color = colorOfThePanel;
        }
        else
        {
            colorOfThePanel = new Color(.133f, .545f, .133f, .6f);
            panel = GameObject.Find("StaminaPanel").GetComponent<Image>();
            panel.color = colorOfThePanel;
        }
    }

    public void HungerChanger()
    {
        if (Hunger > 0)
        {
            Hunger -= Time.deltaTime * hungerDecrease;
        }

        if (Hunger <= 0.99)
        {
            panel = GameObject.Find("HungerPanel").GetComponent<Image>();
            colorOfThePanel = new Color(1.0f, .0f, .0f, .75f); // Chaning the color of the textbox/panel.
            panel.color = colorOfThePanel;
            Hunger = 0;
        }
        else
        {
            panel = GameObject.Find("HungerPanel").GetComponent<Image>();
            colorOfThePanel = new Color(.722f, .525f, .043f, .6f);
            panel.color = colorOfThePanel;
        }
    }

    public void ThirstChanger()
    {
        if (Thirst > 0)
        {
            Thirst -= Time.deltaTime * thirstDecrease;
        }

        if (Thirst <= 0.99)
        {
            panel = GameObject.Find("ThirstPanel").GetComponent<Image>();
            colorOfThePanel = new Color(1.0f, .0f, .0f, .75f);
            panel.color = colorOfThePanel;
            Thirst = 0;
        }
        else
        {
            panel = GameObject.Find("ThirstPanel").GetComponent<Image>();
            colorOfThePanel = new Color(.255f, .412f, .882f, .48f);
            panel.color = colorOfThePanel;
        }
    }


    /// <summary>
    /// This method is stand for setting the values, and updating it to the correct value.
    /// </summary>
    void Update()
    {
        StaminaChanger();
        HungerChanger();
        ThirstChanger();
        VitalityChanger();
        
        // Write the manipulated values to the textboxs/panels in the game.
        VitalityText.text = Mathf.FloorToInt(Vitality).ToString();
        StaminaText.text = Mathf.FloorToInt(Stamina).ToString();
        HungerText.text = Mathf.FloorToInt(Hunger).ToString();
        ThirstText.text = Mathf.FloorToInt(Thirst).ToString();
    }
}
