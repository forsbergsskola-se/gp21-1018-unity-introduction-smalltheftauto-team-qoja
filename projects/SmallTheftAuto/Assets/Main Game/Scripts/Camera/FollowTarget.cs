using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float tweenTime = 0.3f;
    private Player _player;

    protected void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    protected void FixedUpdate()
    {
        Vector3 targetPosition = _player.transform.position + offset;
        Vector3 movement = (targetPosition - transform.position) * Time.deltaTime / tweenTime;
        transform.Translate(movement);
    }
}