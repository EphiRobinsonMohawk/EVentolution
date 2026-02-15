using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static Color primaryColor;
    public static Color secondaryColor;
    public static Color tertiaryColor;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        primaryColor = Random.ColorHSV(
            0f, 1f,   // Hue range
            0.6f, 1f, // Saturation
            0.7f, 1f  // Value (brightness)
        );

        secondaryColor = Random.ColorHSV(
            0f, 1f,
            0.6f, 1f,
            0.7f, 1f
        );

        tertiaryColor = Random.ColorHSV(
            0f, 1f,
            0.6f, 1f,
            0.7f, 1f
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
