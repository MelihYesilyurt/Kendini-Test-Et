using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class Yarisma : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel2;
    public Text rekor;
    public bool acik;
    public bool zafer;
    public AudioClip[] sesDosyalari;
    public Text soruismi, cevapa, cevapb, cevapc, cevapd, skorYazi, zamanYazi, skorpanel;
    Sorular sr;

    public List<bool> sorulanlar;

    public int cevap,skor,skor2;
    public float zaman;

    void Start()
    {
        sr = GetComponent<Sorular>();
        for (int i = 0; i < sr.sorular.Count; i++)
        {
            sorulanlar.Add(false);
        }
        SoruEkle();
    }

    void Update()
    {
        if (acik)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
        if (!acik)
        {
            Panel.SetActive(false);
        }
        if (zaman > 0)
        {
            zaman -= Time.deltaTime;
            zamanYazi.text = zaman.ToString("00");

        }
        else
        {
            //Debug.Log(" süreli Yanlış");
            acik = !acik;
            {
                Oyunsonu();
            }
            zaman = 24;
            GetComponent<AudioSource>().PlayOneShot(sesDosyalari[0], 1);
        }
        if (zafer)
        {
            Panel2.SetActive(true);
            Time.timeScale = 0;
        }
        if (!zafer)
        {
            Panel2.SetActive(false);
        }
    }
    public void SoruEkle()
    {
        for (int i = 0; i < sorulanlar.Count; i++)
            {
            if (sorulanlar [i] == false)
                {
                int sorusayi = Random.Range(0, sorulanlar.Count);
                if (sorulanlar[sorusayi] == false)
                {
                    sorulanlar[sorusayi] = true;
                    GetComponent<AudioSource>().PlayOneShot(sesDosyalari[1], 1);
                    skor++;
                    skor2 = skor * 10;
                    zaman = 24;
                    skorYazi.text = ""+skor;
                    skorpanel.text = "" + skor2;
                    soruismi.text = sr.sorular[sorusayi].soruismi;
                    cevapa.text = sr.sorular[sorusayi].cevapa;
                    cevapb.text = sr.sorular[sorusayi].cevapb;
                    cevapc.text = sr.sorular[sorusayi].cevapc;
                    cevapd.text = sr.sorular[sorusayi].cevapd;
                    cevap = sr.sorular[sorusayi].cevap;
                }
                else
                {
                    SoruEkle();
                }
                break;
            }
            if(i == sorulanlar.Count - 1)
            {
                //Debug.Log("oyunu kazandin!");
                zafer = !zafer;
            }
        }
    
    }

    public void CevapVer(int deger)
    {
        if (deger == cevap)
        {
            SoruEkle();
        } else {
            //Debug.Log("Yanlış");
            GetComponent<AudioSource>().PlayOneShot(sesDosyalari[0], 1);
            acik = !acik;
            {
                Oyunsonu();
            }

        }
    }
         public void butonlar(string isim)
    {
        if (isim == "cik")
        {
            Application.LoadLevel(0);
        }
        if (isim == "tekrar")
        {
            Application.LoadLevel(1);
        }
    }
    void Oyunsonu()
    {
        Time.timeScale = 0;
        if ( skor2 > PlayerPrefs.GetInt("Rekor"))
        {
            PlayerPrefs.SetInt("Rekor", skor2);
        }

        rekor.text = PlayerPrefs.GetInt("Rekor").ToString();
    }
}
