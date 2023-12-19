using UnityEngine;

public class RandomAnimator : MonoBehaviour
{
    // ссылка на компонент Animator который анимирует персонажа
    [SerializeField] private Animator _animator;

    // минимальное значение для случайного числа
    [SerializeField] private int _minRandom;

    // максимальное значение для случайного числа
    [SerializeField] private int _maxRandom;

    // ключ для параметра анимации
    private const string RandomKey = "Random";

    // вызывается при запуске игры
    private void Start()
    {
        // метод InvokeRepeating принимает название метода,
        // и значение через сколько начать первое повторение и через сколько начинать следующие то есть как часто повторять
        InvokeRepeating(nameof(SetRandom), 1f, 1f);
    }

    // устанавливает случайное значение в параметр анимации
    private void SetRandom()
    {
        //генерируем случаное число с помощью метода Range в классе Random
        //метод Range принимает два числа нижнюю границу включительно и
        //верхнюю границу НЕ включительно поэтому мы прибалвяем 1 чтобы она тоже могла выпасть
        int randomNumber = Random.Range(_minRandom, _maxRandom + 1);

        //устанавливаем наше значение в параметр по ключу RandomKey
        _animator.SetInteger(RandomKey, randomNumber);
    }
}
