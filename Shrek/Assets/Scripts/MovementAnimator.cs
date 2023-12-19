using KinematicCharacterController.Examples;
using UnityEngine;

//����� ������� ������������ ������� ������ �������� � ��������� ������ �� �������� ��������
public class MovementAnimator : MonoBehaviour
{
    // ������ �� ��������� ExampleCharacterController ������� � �������� �� ���������� ����������
    [SerializeField] private ExampleCharacterController _controller;

    // ������ �� ��������� Animator ������� ����������� ���������
    [SerializeField] private Animator _animator;

    // ����� ��� ���������� ��������� ������� �� ����� ��������
    private const string MoveSpeedKey = "Speed";
    private const string JumpKey = "Jump";
    private const string LandedKey = "Landed";

    //����� ����������� � ������ ���� � ��� ��������� �������
    private void OnEnable()
    {
        // ������������� �� ������� ����������� ����� ��� �������� ���� ������
        _controller.Jumping += OnJumping;
        _controller.Running += OnRunning;
        _controller.Landed += OnLanded;
    }

    //����� ����������� � ����� ���� ��� ��� ���������� �������
    private void OnDisable()
    {
        // ������������ �� ������� �����������
        _controller.Jumping -= OnJumping;
        _controller.Running -= OnRunning;
        _controller.Landed -= OnLanded;
    }

    private void OnLanded()
    {
        // ������������� ������� Landed � ���������
        _animator.SetTrigger(LandedKey);
    }

    private void OnRunning(float speed)
    {
        // ������������� �������� ��������� MoveSpeed � ��������� ����� Blend Tree �������� �������� ������ �� ���� ��������
        _animator.SetFloat(MoveSpeedKey, speed);
    }

    private void OnJumping()
    {
        // ������������� ������� Jump ����� �������� �������� ������
        _animator.SetTrigger(JumpKey);

        // ���������� ������� Landed � ��������� ����� ����� �� ������������ �� ������ � ��� ����� ��� ���������
        _animator.ResetTrigger(LandedKey);
    }
}
