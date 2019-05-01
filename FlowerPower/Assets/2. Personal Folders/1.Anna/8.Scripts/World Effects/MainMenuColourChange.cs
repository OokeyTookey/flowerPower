using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuColourChange : MonoBehaviour
{
    Renderer[] rends;
    public List<Color> OriginalColors;

    void Start()
    {
        OriginalColors = new List<Color>();
        rends = this.GetComponentsInChildren<Renderer>();

        int f = 0;
        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                OriginalColors.Add(rends[i].materials[j].color);
                float greyscale = OriginalColors[f].grayscale;
                rends[i].materials[j].color = new Color(greyscale, greyscale, greyscale);
                f++;
            }
        }
    }

    private IEnumerator ColourToGrey()
    {
        float percentage = 0;

        while (percentage < 1)
        {
            percentage += 0.01f;

            int t = 0;
            for (int i = 0; i < rends.Length; i++)
            {
                for (int j = 0; j < rends[i].materials.Length; j++)
                {
                    float greyscale = OriginalColors[t].grayscale;
                    rends[i].materials[j].color = Color.Lerp(OriginalColors[t], new Color(greyscale, greyscale, greyscale), percentage);
                    t++;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator GreyToColor()
    {
        float percentage = 0;
        while (percentage < 1)
        {
            percentage += 0.01f;
            int t = 0;
            for (int i = 0; i < rends.Length; i++)
            {
                for (int j = 0; j < rends[i].materials.Length; j++)
                {
                    float greyscale = OriginalColors[t].grayscale;
                    rends[i].materials[j].color = Color.Lerp(new Color(greyscale, greyscale, greyscale), OriginalColors[t], percentage);
                    t++;
                }
            }  

            yield return new WaitForSeconds(0.1f);
        }
    }
}
