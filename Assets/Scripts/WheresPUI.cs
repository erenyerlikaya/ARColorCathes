// --- Start Metodu ---
// Uygulama başladığında UI panellerini başlatır ve metin okuma ayarlarını yapar.
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FantomLib;
using TMPro;

public class WheresPUI : MonoBehaviour
{
    public enum Mode
    {
        PLACEOBJECT,
        PICKUP
    }

    public static WheresPUI instance;

    public Mode mode = Mode.PLACEOBJECT;

    public GameObject initializePanel;
    public GameObject exitPanel;
    public GameObject successPanel;
    public GameObject failurePanel;
    public GameObject winPanel;
    public Image inventory;
    public Sprite inventoryDefaultSprite;
    public Text debugText;
    public TextMeshProUGUI infoText;

    public GameObject[] objects;
    
    [TextArea(3, 10)]
    public string[] riddles;

    public TextToSpeechController textToSpeechControl; // = new TextToSpeechController();

    void Start()
    {// --- Speak Metodu ---
// Girilen metni sesli okuma motoru aracılığıyla okutmaya başlar.

        instance = this;
        initializePanel.SetActive(true);
        //Screen.orientation = ScreenOrientation.LandscapeLeft;

        textToSpeechControl.Locale = ""; // empty string means AndroidLocale.Default;

        RedGreenBinUI.instance.inventory.color = Color.blue;
    }

    public void Speak(string text)
    {// --- OnSpeakStart Metodu ---
// Konuşma başladığında debug mesajı yazar.

        if (textToSpeechControl != null)
        {
            textToSpeechControl.StartSpeech(text);
            infoText.text = text;
            debugText.text += "Speaking now: " + text + "\n";
        }
    }

    public void OnSpeakStart()
    {// --- OnSpeakStop Metodu ---
// Konuşma durduğunda debug mesajı yazar.

        debugText.text += "Speech started\n";
    }

    public void OnSpeakStop(string message)
    {// --- OnSpeakDone Metodu ---
// Konuşma tamamlandığında debug mesajı yazar.

        debugText.text += "Speech stopped\n";
        debugText.text += "Stop Message: " + message + "\n";
    }

    public void OnSpeakDone()
    {// --- OnStatus Metodu ---
// TTS durumu hakkında bilgi mesajı verir.

        debugText.text += "Speech done\n";
    }

    public void OnStatus(string message)
    {// --- OnClickBack Metodu ---
// Geri butonuna basıldığında çıkış panelini gösterir.

        debugText.text += message + "\n";
    }

    public void OnClickBack()
    {// --- OnClickContinue Metodu --
// Devam et butonuna basıldığında gerekli panelleri kapatır ve envanteri sıfırlar.

        exitPanel.SetActive(true);
    }

    public void OnClickContinue()
    {// --- ReturnToMainMenu Metodu ---
// Ana menü sahnesine döner ve bu sınıfın örneğini sıfırlar.

        if (initializePanel.activeSelf)
            inventory.color = Color.blue;

        initializePanel.SetActive(false);
        exitPanel.SetActive(false);
        successPanel.SetActive(false);
        failurePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        instance = null;
        SceneManager.LoadScene("HomeScreen");
    }
}
