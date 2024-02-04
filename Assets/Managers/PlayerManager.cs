using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Player Manager Variables
    public static PlayerManager instance; //Can be called by other classes using PlayerManager.instance.function()
    private CharacterController controller;
    [SerializeField] private float speedMovement;
    [SerializeField] private float speedRotation;
    public int playerScore = 0;

    void Awake()
    {
        if(instance == null){
            instance = this;
        } else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); //Acquiring Player
        speedMovement = 10.0f;
        speedRotation = 3.0f;
    }

    // Update is called once per frame
    void Update() //Based on exmaple code provided by Unity: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * speedRotation, 0); //Enabling left/right rotation when left-right keys are pressed

        Vector3 forward = transform.TransformDirection(Vector3.forward); //Calculating variables for forward/back movement
        float currentSpeed = speedMovement * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * currentSpeed); //SimpleMove locks player to the ground

        if(Input.GetKeyDown("space")){ //Fire Fireball if SPACE is pressed
            AmmoManager.instance.Fire();
        }
    }
}
