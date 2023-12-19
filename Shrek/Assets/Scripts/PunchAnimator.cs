using UnityEngine;

public class PunchAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string PunchKey = "Punch";


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(PunchKey);
        }
    }

}
