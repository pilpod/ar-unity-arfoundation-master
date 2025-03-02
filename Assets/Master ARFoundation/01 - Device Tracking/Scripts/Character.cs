using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _distance;
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = Camera.main.transform;
        ChangePosition();
    }

    public void ChangePosition()
    {
        transform.position = new Vector3(
            Random.insideUnitSphere.x * _distance,
            transform.position.y,
            Random.insideUnitSphere.x * _distance);

        transform.LookAt(_player);
    }
}
