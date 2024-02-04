using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int textureWidth = 256;
    public int textureHeight = 256;
    private float scale = 100f;
    private Renderer rend;
    private Texture2D noiseTexture;
   
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        noiseTexture = new Texture2D(textureWidth, textureHeight);

        rend.material.mainTexture = noiseTexture;
        generateTexture();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateTexture(){ //Generating Perlin Noise Texture
        for(int x = 0; x < textureWidth; x++){ //Going through each x pixel
            for(int y = 0; y < textureHeight; y++){ //Going through each y pixel
                Color colourValue = generateColour(x, y);
                noiseTexture.SetPixel(x, y, colourValue);
            }
        }
        noiseTexture.Apply();
    }

    private Color generateColour(int x, int y){
        float xCoordinate = (float) x / textureWidth * scale;
        float yCoordinate = (float) y / textureHeight * scale;

        float sampleNoise = Mathf.PerlinNoise(xCoordinate, yCoordinate);
        return new Color(sampleNoise, sampleNoise, sampleNoise);
    }
}
