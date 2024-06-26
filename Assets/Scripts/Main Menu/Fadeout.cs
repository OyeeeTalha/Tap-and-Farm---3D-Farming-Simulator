using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    public float fadeSpeed = 1f;

    private Image image;
    private float currentAlpha = 0f;
    private bool fadingIn = true;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
    }

    private void Update()
    {
        if (fadingIn)
        {
            currentAlpha += fadeSpeed * Time.deltaTime;
            if (currentAlpha >= 1f)
            {
                currentAlpha = 1f;
                fadingIn = false;
            }
        }
        else
        {
            currentAlpha -= fadeSpeed * Time.deltaTime;
            if (currentAlpha <= 0f)
            {
                currentAlpha = 0f;
                fadingIn = true;
            }
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
    }
}
