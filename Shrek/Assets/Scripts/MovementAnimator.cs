using KinematicCharacterController.Examples;
using UnityEngine;

//класс который обрабатывает сигналы нашего движения и анимирует исходя из значений сигналов
public class MovementAnimator : MonoBehaviour
{
    // ссылка на компонент ExampleCharacterController который и отвечает за управление персонажем
    [SerializeField] private ExampleCharacterController _controller;

    // ссылка на компонент Animator который аанаимирует персонажа
    [SerializeField] private Animator _animator;

    // ключи для параметров аниматора которые мы будем изменять
    private const string MoveSpeedKey = "Speed";
    private const string JumpKey = "Jump";
    private const string LandedKey = "Landed";

    //метод вызываеться в начале игры и при включении объекта
    private void OnEnable()
    {
        // подписываемся на события контроллера чтобы они вызывали наши методы
        _controller.Jumping += OnJumping;
        _controller.Running += OnRunning;
        _controller.Landed += OnLanded;
    }

    //метод вызываеться в конце игры или при выключении объекта
    private void OnDisable()
    {
        // отписываемся от событий контроллера
        _controller.Jumping -= OnJumping;
        _controller.Running -= OnRunning;
        _controller.Landed -= OnLanded;
    }

    private void OnLanded()
    {
        // устанавливаем триггер Landed в аниматоре
        _animator.SetTrigger(LandedKey);
    }

    private void OnRunning(float speed)
    {
        // устанавливаем значение параметра MoveSpeed в аниматоре чтобы Blend Tree смешивал анимации исходя из нашеё скорости
        _animator.SetFloat(MoveSpeedKey, speed);
    }

    private void OnJumping()
    {
        // устанавливаем триггер Jump чтобы включить анимацию прыжка
        _animator.SetTrigger(JumpKey);

        // сбрасываем триггер Landed в аниматоре чтобы когда мы приземлились мы смогли с его мощью это отследить
        _animator.ResetTrigger(LandedKey);
    }
}
