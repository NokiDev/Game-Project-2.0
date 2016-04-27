using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

    const int buttonWidth = 120;
    const int buttonHeight = 60;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (
          GUI.Button(
            // Centré en x, 1/3 en y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (1 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Quitter"
          )
        )
        {
            Application.Quit();
        }

    }
}
