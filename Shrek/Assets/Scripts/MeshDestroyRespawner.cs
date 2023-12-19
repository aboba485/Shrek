using UnityEngine;

//класс который запускает разрушение и восстановление Mesh
public class MeshDestroyRespawner : MonoBehaviour
{
    [SerializeField] private MeshDestroy _meshDestroyPrefab; //префаб Mesh который будет создаваться и разрушаться
    [SerializeField] private float _respawnTime = 10f;//время через которое Mesh будет восстановлен 
   
    private MeshDestroy _mesh; //mesh что разрушается и респавнится в игре, хранится здесь 

    //при запуске уровня создаём Mesh и помещаем её в поле _mesh (т.к. изначально его нет)
    private void Start()
    {
        //вызов метода
        Respawn();
    }

    //если Mesh для разрушения существет то разрушем его
    public void DestroyMesh()
    {
        //если Mesh для разрушения существует
        if (_mesh != null)
        {
            //уничтожаем mesh
            _mesh.DestroyMesh();
            //запускаем метод Respawn через время указанное в _respawnTime
            Invoke(nameof(Respawn), _respawnTime);
        }
    }

    //создаём Mesh который будет разрушать
    private void Respawn()
    {
        //метод Instantiate принимает Объект который будет спавнить и место с вращением (чтобы знать где его спавнить) и
        //компонент tyransform объекта вложенным в который он будет
        _mesh = Instantiate(_meshDestroyPrefab, transform.position, transform.rotation);        
    }

    //рисуем куб на месте объекта на сцене (нарисованное видно только в окне Scene)
    private void OnDrawGizmos()
    {
        //Метод DrawCube принимает место где будет рисосваться куб и его размеры (Vector3.one означает что все XYZ будут равны 1)
        Gizmos.DrawCube(transform.position, Vector3.one);
    }

}
