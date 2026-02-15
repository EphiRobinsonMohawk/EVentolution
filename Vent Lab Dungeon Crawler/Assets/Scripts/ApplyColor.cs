
using UnityEngine;

public class ApplyPalette : MonoBehaviour
{
    public Colour myColour = Colour.primary;

    public enum Colour
    {
        primary,
        secondary,
        tertiary
    }

    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Color original = sr.color;

        float hOriginal, sOriginal, vOriginal;
        Color.RGBToHSV(original, out hOriginal, out sOriginal, out vOriginal);

        float hPalette = 0f, sPalette = 0f, vPalette = 0f;
        if (myColour == Colour.primary)
        {
            Color.RGBToHSV(PaletteMan.primaryColor, out hPalette, out sPalette, out vPalette);
        }
        else if (myColour == Colour.secondary)
        {
            Color.RGBToHSV(PaletteMan.secondaryColor, out hPalette, out sPalette, out vPalette);
        }
        else if (myColour == Colour.tertiary)
        {
            Color.RGBToHSV(PaletteMan.tertiaryColor, out hPalette, out sPalette, out vPalette);
        }
        else
        {
            Debug.Log("Palette option is null");
        }
        

        Color newColor = Color.HSVToRGB(hPalette, sPalette, vOriginal);

        sr.color = newColor;
    }
}