using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDRRotation : MonoBehaviour
{

    public Material HDR;
    public Color color1;
    public Color color2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomColor());
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 30* Time.time);


    }

    IEnumerator RandomColor()
    {
        if(RenderSettings.skybox.GetColor("_Tint") == color1)
        {
            float timer = 0;
            while (timer < 5)
            {              
                timer += Time.deltaTime;
                Color color = Color.Lerp(color1, color2, timer / 5);
                RenderSettings.skybox.SetColor("_Tint", color);
                yield return null;
            }
        }
        else
        {
            float timer = 0;
            while (timer < 5)
            {
                timer += Time.deltaTime;
                Color color = Color.Lerp(color2, color1, timer / 5);
                RenderSettings.skybox.SetColor("_Tint", color);
                yield return null;
            }
            RenderSettings.skybox.SetColor("_Tint", color1);
        }
        yield return RandomColor();
    }
}
