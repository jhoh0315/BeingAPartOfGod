using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementamout = 3f;
    public float moveSpeed = 5f;
    public float yoffset = 20;
    public float xoffset = 0.3f;

    private void FixedUpdate()
    {
        // Apply buoyancy force
        float waveHeight = -WaveManager.instance.GetWaveHeight(transform.position.x + xoffset);
        waveHeight += yoffset;
        if (transform.position.y < waveHeight)
        {
            float displacementamoutMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementamout;
            rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementamoutMultiplier, 0f), ForceMode.Acceleration);
        }

        // Apply movement force based on input
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        if (movement != Vector3.zero)
        {
            rigidBody.AddForce(movement * moveSpeed, ForceMode.Acceleration);
        }
        else
        {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f); // Stop horizontal and depth movement, keep vertical velocity
        }
    }
}
