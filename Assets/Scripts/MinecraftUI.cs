// --- Start Metodu ---
// Uygulama başladığında ekranı yatay moda alır ve bu sınıfı singleton olarak ayarlar.
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class MinecraftUI : MonoBehaviour
{
    public enum Mode
    {
        PLACE,
        PICKUP
    }

    public enum Object
    {
        CUBE,
        CONE,
        CYLINDER
    }

    public Mode mode = Mode.PLACE;
    public Object objectType = Object.CUBE;

    public Text buttonText;
    public Text debugText;
    public Image HammerImage;
    public Image BombImage;

    public GameObject shapeMenu;
    public GameObject colorMainButton;
    public GameObject colorMenu;

    public Color objectColor = Color.yellow;

    private Color colorInactive = new Color(0.34f, 0.34f, 0.34f);
    private Color colorActive = new Color(1, 1, 1);

    public static MinecraftUI instance;

    void Start()
    {// --- SwitchMode Metodu ---
// Kullanıcı modunu PLACE ↔ PICKUP arasında değiştirir ve buton metnini günceller.

        MinecraftUI.instance = this;

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void SwitchMode()
    {// --- BuildMode Metodu ---
// Yapı (inşa) modunu aktif eder; simgelerin renklerini günceller.

        mode = (Mode)((int)(mode + 1) % Enum.GetNames(typeof(Mode)).Length);
        debugText.text += "Mode set to " + mode.ToString() + "\n";

        if (mode == Mode.PLACE)
        {
            buttonText.text = "Switch to Pickup Mode";
        }
        else if (mode == Mode.PICKUP)
        {
            buttonText.text = "Switch to Place Mode";
        }
    }

    public void BuildMode()
    {// --- DestroyMode Metodu ---
// Yıkım (pickup) modunu aktif eder; simgelerin renklerini günceller.

        mode = Mode.PLACE;
        debugText.text += "Mode set to " + mode.ToString() + "\n";

        BombImage.color = colorInactive;
        HammerImage.color = colorActive;
    }

    public void DestroyMode()
    {// --- OnClickReset Metodu ---
// AR oturumunu sıfırlar (yeniden başlatır).

        mode = Mode.PICKUP;
        debugText.text += "Mode set to " + mode.ToString() + "\n";

        BombImage.color = colorActive;
        HammerImage.color = colorInactive;
    }

    public void OnClickReset()
    {// --- OnClickBack Metodu ---
// Ana menüye geri döner ve sahneyi değiştirir.

        ARSession arSession = GetComponent<ARSession>();
        arSession.Reset();
    }

    public void OnClickBack()
    {// --- OnClickShapes Metodu ---
// Şekil seçim menüsünü aç/kapat.

        instance = null;
        SceneManager.LoadScene("HomeScreen");
        //SceneManager.UnloadScene("Minecraft");
    }

    public void OnClickShapes()
    {// --- OnClickCubeShape Metodu ---
// Küp şekli seçilir ve menü kapanır.

        shapeMenu.SetActive(!shapeMenu.activeSelf);
    }

    public void OnClickCubeShape()
    {// --- OnClickCylinderShape Metodu 
// Silindir şekli seçilir ve menü kapanır.

        objectType = Object.CUBE;
        shapeMenu.SetActive(false);
    }

    public void OnClickCylinderShape()
    {// --- OnClickConeShape Metodu -
// Koni şekli seçilir ve menü kapanır.

        objectType = Object.CYLINDER;
        shapeMenu.SetActive(false);
    }

    public void OnClickConeShape()
    {// -- OnClickColorMainButton Metodu ---
// Renk menüsünü aç/kapat ve ana renk butonunu günceller.

        objectType = Object.CONE;
        shapeMenu.SetActive(false);
    }

    public void OnClickColorMainButton()
    {// --- OnClickRed Metodu ---
// Objeye kırmızı renk uygular.

        bool isColorMenuOpen = colorMenu.activeSelf;
        colorMenu.SetActive(!isColorMenuOpen);
        colorMainButton.SetActive(isColorMenuOpen);
    }

    public void OnClickRed()
    {// --- OnClickGreen Metodu ---
// Objeye yeşil renk uygular.

        objectColor = Color.red;
        OnClickColorMainButton();
    }

    public void OnClickGreen()
    {// --- OnClickBlue Metodu ---
// Objeye mavi renk uygular.

        objectColor = Color.green;
        OnClickColorMainButton();
    }

    public void OnClickBlue()
    {// --- OnClickYellow Metodu ---
// Objeye sarı renk uygular.

        objectColor = Color.blue;
        OnClickColorMainButton();
    }

    public void OnClickYellow()
    {
        objectColor = Color.yellow;
        OnClickColorMainButton();
    }
}
