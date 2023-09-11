using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private float speed;
    private Animator anim;
    private Rigidbody rb;
    public float maxSlopeAngle = 90f; // Максимальный угол наклона, считающийся горой

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float velocityMagnitude = rb.velocity.magnitude;

        // Проверяем, находится ли объект на наклонной поверхности
        if (IsOnSlope())
        {
            // Если да, замедляем анимацию в зависимости от наклона
            float slopeAngle = GetSlopeAngle();
            float normalizedSlopeAngle = Mathf.Clamp01(slopeAngle / maxSlopeAngle);
            velocityMagnitude *= (1f - normalizedSlopeAngle);
        }

        anim.SetFloat("Velocity", velocityMagnitude);
    }

    // Проверка, находится ли объект на наклонной поверхности
    private bool IsOnSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            return slopeAngle > maxSlopeAngle;
        }
        return false;
    }

    // Получение угла наклона поверхности
    private float GetSlopeAngle()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f))
        {
            return Vector3.Angle(hit.normal, Vector3.up);
        }
        return 0f;
    }
}