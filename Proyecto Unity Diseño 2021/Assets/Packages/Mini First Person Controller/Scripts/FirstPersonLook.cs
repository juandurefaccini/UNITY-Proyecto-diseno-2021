using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    Vector2 velocity;
    Vector2 frameVelocity;

    private bool active_lock = true;

    // Agregado para detener el movimiento del cursor cuando se interactua con algo
    public void changelockState (bool applyLock) {
        if (applyLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            active_lock = applyLock;
        }
        else
        {
            gameObject.GetComponentInParent<Rigidbody>().freezeRotation = true; // Para que no rote mientras estamos chateando.
            active_lock = applyLock;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        // Get smooth velocity.

        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);
        if (active_lock)
        {
            // Rotate camera up-down and controller left-right from velocity.
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }
    }
}
