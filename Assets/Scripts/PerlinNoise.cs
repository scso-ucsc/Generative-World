using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    //Code based on https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html and https://youtu.be/bG0uEXV6aHQ?si=F5XnHxdj0tLPq0c_
    public int textureWidth = 256;
    public int textureHeight = 256;
    private float scale = 100f;
    private Renderer rend;
    private Texture2D noiseTexture;
   
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); //Acquiring material renderer of object
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
                noiseTexture.SetPixel(x, y, colourValue); //Assigning new colour to pixel
            }
        }
        noiseTexture.Apply(); //Applying texture
    }

    private Color generateColour(int x, int y){ //Generating and returning colour for each pixel
        float xCoordinate = (float) x / textureWidth * scale; //Determining x-coordinate based on overall scale
        float yCoordinate = (float) y / textureHeight * scale; //Determining y-coordinate based on overall scale

        float sampleNoise = Mathf.PerlinNoise(xCoordinate, yCoordinate);
        return new Color(sampleNoise, sampleNoise, sampleNoise);
    }
}
