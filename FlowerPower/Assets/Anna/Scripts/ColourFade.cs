using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourFade : MonoBehaviour
{
    Renderer[] rends;
    public List<Color> OriginalColors;

    private void Start()
    {
        rends = this.GetComponentsInChildren<MeshRenderer>(); //Accesses all the meshrenderers in the children
        int f = 0; //Acts as an index to remember the colour location
 
        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                OriginalColors.Add(rends[i].materials[j].color); //Adds the childrens materials.color

                /*var tempColor = rends[i].materials[j].color;
                tempColor.a = 0;
                rends[i].materials[j].color = tempColor;*/
                f++;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Testing Purposes
        {
            Debug.Log("<b>ColourFade Coroutine: </b><color=green>Active</color>");
            StartCoroutine(FadeColour());
        }
    }

    private IEnumerator FadeColour() //Use fade in mat
    {
        float percentage = 0;
        float fadeAlpha = 1;

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
    }
}