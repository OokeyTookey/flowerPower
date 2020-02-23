using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstCutscene : MonoBehaviour
{
    float timer;
    int index;
    public float timerLimit;
    public GameObject[] comicPanels;
    public Image[] images;
    GameObject currentPanel;
    bool dothing;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerLimit && index <= comicPanels.Length)
        {
            currentPanel = comicPanels[index];
           
            comicPanels[index].SetActive(false);
             index++;
            timer = 0;
        }

        if (index == comicPanels.Length)
        {
            SceneManager.LoadScene("AnnaLevel12020");
        }

        
    }

    private IEnumerator FadeAlpha()
    {
        float percentage = 0;
        float fadeAlpha = 1;

        while (percentage < 1)
        {
            // fadeAlpha -= 0.05f;
            fadeAlpha -= 0.01f;
            percentage += 0.01f;

            images[index].color = new Color(images[index].color.r, images[index].color.g, images[index].color.b, fadeAlpha);
            yield return new WaitForSeconds(0.1f);
        }
    }

   /* private IEnumerator FadeColour() //Use fade in mat
    {

        while (percentage < 1)
        {
            fadeAlpha -= 0.01f;
            percentage += 0.01f;

            int t = 0;
            for (int i = 0; i < rends.Length; i++)
            {
                for (int j = 0; j < rends[i].materials.Length; j++)
                {
                    float greyscale = OriginalColors[t].grayscale;
                    rends[i].materials[j].color = Color.Lerp(OriginalColors[t], new Color(greyscale, greyscale, greyscale, fadeAlpha), percentage);
                    t++;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }*/
}
