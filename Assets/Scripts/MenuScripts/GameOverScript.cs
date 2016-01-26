using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Relance ou quitte la partie en cours
/// </summary>
public class GameOver : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        if (
          GUI.Button(
            // Centré en x, 1/3 en y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (1 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Try again ?"
          )
        )
        {
            // Recharge le niveau
            SceneManager.LoadScene("test");
        }

        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            ),
            "Retour au menu"
          )
        )
        {
            // Retourne au menu
            SceneManager.LoadScene("menu");
        }
    }
}

