using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float maxspeed = 12f;
    public float speed = 6f;
    public Slider speedSlider;
    
    Vector3 movement;
    Animator animation;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    float initSpeed = 6f;

    private void Awake() {
        floorMask = LayerMask.GetMask("Floor");
        animation = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        speedSlider.minValue = initSpeed;
    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h,v);
        Turning();
        Animating(h,v);
    }

    void Move(float h, float v) {
        movement.Set(h,0f,v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v) {
        bool walking = h != 0f || v != 0f;
        animation.SetBool("isWalking", walking);
    }

    public void speedUpdater() {
        speed *= 1.2f;
        speedSlider.value = speed;
    }
}
