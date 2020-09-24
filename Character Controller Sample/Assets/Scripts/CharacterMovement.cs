using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float MoveSpeed = 0.5f;
    public float RotateSpeed = 1f;
    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // rotate the character according to left/right key presses
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * RotateSpeed);
        // move forward/backward according to up/down key presses
        cc.Move(transform.forward * Input.GetAxis("Vertical") * MoveSpeed);
        // apply gravity
        cc.SimpleMove(Physics.gravity);
	}
}
