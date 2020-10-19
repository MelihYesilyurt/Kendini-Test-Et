using UnityEngine;
using System.Collections;

public class AraMenu : MonoBehaviour
{

    public bool acik;
    public bool ayarlarbool;
    public GameObject Panel;
    public GameObject AyarlarPanel;
    
    void Start()
    {
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            acik = !acik;
        }
        if (acik)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
        if (!acik)
        {
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
        if (ayarlarbool)
        {
            AyarlarPanel.SetActive(true);
        }
        if (!ayarlarbool)
        {
            AyarlarPanel.SetActive(false);
        }
    }
    public void butonlar(string isim)
    {
        if (isim == "araacbutton")
        {
            acik = !acik;
        }

        if (isim == "devam et")
        {
            acik = false;
        }
        if (isim == "anamenu")
        {
            Application.LoadLevel(0);
        }
        if (isim == "ayarlar")
        {
            ayarlarbool = true;
        }
    }
}
