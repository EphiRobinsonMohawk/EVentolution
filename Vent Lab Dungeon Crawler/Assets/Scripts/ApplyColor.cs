
using UnityEngine;

public class ApplyPalette : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Color original = sr.color;

        float hOriginal, sOriginal, vOriginal;
        Color.RGBToHSV(original, out hOriginal, out sOriginal, out vOriginal);

        float hPalette, sPalette, vPalette;
        Color.RGBToHSV(GameMan.primaryColor, out hPalette, out sPalette, out vPalette);

        Color newColor = Color.HSVToRGB(hPalette, sPalette, vOriginal);

        sr.color = newColor;
    }
}