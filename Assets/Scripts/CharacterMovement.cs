using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashDistance = 5f;
    public int maxDashes = 3;

    private Rigidbody2D rb;
    private Vector2 movement;
    private int remainingDashes;

    public TextMeshProUGUI dashText; // Reference to your UI TextMeshPro element

    private bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingDashes = maxDashes;
        UpdateDashText();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Check for dash input
        if (Input.GetKeyDown(KeyCode.Space) && remainingDashes > 0 && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            // Move the player normally if not dashing
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;

        Vector2 dashDirection = movement.normalized;
        float dashTime = 0.2f; // Adjust as needed

        for (float t = 0; t < dashTime; t += Time.deltaTime)
        {
            rb.MovePosition(rb.position + dashDirection * dashDistance * Time.fixedDeltaTime / dashTime);
            yield return null;
        }

        isDashing = false;
        remainingDashes--;
        UpdateDashText();
        yield return new WaitForSeconds(1f); // Cooldown between dashes
        isDashing = false;
    }

    void UpdateDashText()
    {
        if (dashText != null)
        {
            dashText.text = remainingDashes.ToString();
        }
    }
}