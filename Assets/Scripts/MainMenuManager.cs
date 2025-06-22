// --- Start Metodu ---
// Uygulama başladığında ekran yönünü dikey modda sabitler.
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {// --- OnClickDoItYourself Metodu ---
// Minecraft sahnesine geçiş yapar.

        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void OnClickDoItYourself()
    {// --- OnClickRedGreen Metodu ---
// RedGreenBin sahnesine geçiş yapar.

        SceneManager.LoadScene("Minecraft");
    }

    public void OnClickRedGreen()
    {// --- OnClickWheresTheButton Metodu ---
// WheresP sahnesine geçiş yapar.

        SceneManager.LoadScene("RedGreenBin");
    }

    public void OnClickWheresTheButton()
    {// --- OnClickFunWithNumbers Metodu ---


        SceneManager.LoadScene("WheresP");
    }

    public void OnClickFunWithNumbers()
    {// --- OnClickQuit Metodu ---
// Uygulamayı kapatır.


    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
