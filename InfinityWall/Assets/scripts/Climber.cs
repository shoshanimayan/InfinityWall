using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{

    public float sensitivity = 45f;

    public Hand currentHand = null;
    public CharacterController controller = null;


    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();

    }

 

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

   

    private void CalculateMovement() {
        Vector3 movement = Vector3.zero;

        if (currentHand)
            movement += currentHand.Delta * sensitivity;

        if (movement == Vector3.zero)
            movement.y -= 5;

        controller.Move(movement * Time.deltaTime);
    }

    public void SetHand(Hand hand) {
        if (currentHand)
            currentHand.ReleasePoint();
        currentHand = hand;
    }


    public void ClearHand()
    {
        currentHand = null;
    }
}
