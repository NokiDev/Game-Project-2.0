using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Script de l'écran titre
/// </summary>
public class MenuScript : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 180;
        const int buttonHeight = 60;

        // Affiche un bouton pour démarrer la partie
         if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),(2 * Screen.height / 4) - (buttonHeight / 2),buttonWidth,buttonHeight),"Commencer la démo !"))
         {
             // Sur le clic, on démarre le premier niveau
             // "Stage1" est le nom de la première scène que nous avons créés.
             SceneManager.LoadScene("TEST/Eti/test");
         }
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "Quitter"))
        {
            Application.Quit();
        }
    }
}
