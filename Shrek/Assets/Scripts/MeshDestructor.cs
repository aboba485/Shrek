using UnityEngine;

public class MeshDestructor : MonoBehaviour
{
    [SerializeField] private float _radius = 2; // радиус сферы для поиска коллайдеров
    [SerializeField] private float _destroyDelay = 0.8f; // задержка перед разрушением, чтобы у нас было время на замах анимации

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // если нажата левая кнопка мыши
        {
            Invoke(nameof(Destroy), _destroyDelay); // вызываем метод Destroy через _destroyDelay секунды
        }
    }

    private void Destroy()
    {
        // получаем все коллайдеры в радиусе _radius от позиции transform.position + transform.forward(transform.forward это вперёд на 1)
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, _radius);

        foreach (Collider hitCollider in hitColliders) // для каждого коллайдера в массиве что мы нашли
        {
            // получаем компонент который будет уничтожать Mesh на объекте
            MeshDestroyRespawner meshDestroyComponent = hitCollider.GetComponent<MeshDestroyRespawner>();

            if (meshDestroyComponent != null) // если компонент найден
            {
                meshDestroyComponent.DestroyMesh(); // вызываем метод DestroyMesh на компоненте 
            }
        }
    }

    private void OnDrawGizmos()
    {
        // рисуем сферу в позиции transform.position + transform.forward с радиусом _radius
        Gizmos.DrawWireSphere(transform.position + transform.forward, _radius); 
    }
}
