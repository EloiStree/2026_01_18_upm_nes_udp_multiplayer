using UnityEngine;

public class NesMultiMono_MovingCubeExample : MonoBehaviour
{

    public float m_rotationSpeedPerSeconds = 180f;
    public float m_moveSpeedPerSeconds = 5f;

    public Transform m_whatToMove;
    public Rigidbody m_rigidbodyToAffect;
    public ForceMode m_forceModeDash = ForceMode.Impulse;
    public float m_forceDashAmount = 10f;
    public ForceMode m_forceModeJump = ForceMode.Impulse;
    public float m_forceJumpAmount = 5f;
    public float m_jumpCoolDown= 1.5f;
    public float m_dashCoolDown = 1.5f;

    private float m_jumpCooldownTimer = 0f;
    private float m_dashCooldownTimer = 0f;

    [Range(-1f, 1f)]
    public float m_rotateLeftToRight11;

    [Range(-1f, 1f)]
    public float m_moveBackToFront11;

   

    public void Reset()
    {
        m_whatToMove = this.transform;
        m_rigidbodyToAffect = this.GetComponent<Rigidbody>();
    }

    public void SetMovementWithJoystick(Vector2 value) {

        m_rotateLeftToRight11 = value.x;
        m_moveBackToFront11 = value.y;
    }
    public void SetRotationLeftRightPercent(float rotatePecent) {
        m_rotateLeftToRight11 = rotatePecent;   
    }
    public void SetMoveBackFrontPercent(float movePercent)
    {
        m_moveBackToFront11 = movePercent;
    }
    public void Jump(bool pressingKey)
    {
        if (pressingKey)
            Jump();
    }
    public void Dash(bool pressingKey)
    {
        if (pressingKey)
            Dash();
    }
    public void Jump()
    {
        if (m_rigidbodyToAffect == null)
            return;
        if (m_jumpCooldownTimer > 0f)
            return;
        m_jumpCooldownTimer = m_jumpCoolDown;
        m_rigidbodyToAffect.AddForce(Vector3.up * m_forceJumpAmount, m_forceModeJump);
    }
    public void Dash()
    {
        if (m_rigidbodyToAffect == null)
            return;
        if (m_dashCooldownTimer > 0f)
            return;
        m_dashCooldownTimer = m_dashCoolDown;
        m_rigidbodyToAffect.AddForce(transform.forward * m_forceDashAmount, m_forceModeDash);
    }
    public void Update()
    {
        if(m_jumpCooldownTimer > 0f)
            m_jumpCooldownTimer -= Time.deltaTime;
        if (m_dashCooldownTimer > 0f)
            m_dashCooldownTimer -= Time.deltaTime;
        m_whatToMove.Rotate(Vector3.up, m_rotateLeftToRight11 * m_rotationSpeedPerSeconds * Time.deltaTime);
        m_whatToMove.Translate(Vector3.forward * m_moveBackToFront11 * m_moveSpeedPerSeconds * Time.deltaTime);
    }
}
