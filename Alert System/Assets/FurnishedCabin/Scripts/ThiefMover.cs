using UnityEngine;

[RequireComponent(typeof(Thief))]
public class ThiefMover : MonoBehaviour
{
    [SerializeField] private Transform[] _ways;

    private float _speed = 6f;

    private int _indexSpot;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _ways[_indexSpot].position, _speed * Time.deltaTime);

        if (transform.position == _ways[_indexSpot].position)
            GetNextVectorPoint();
    }

    private void GetNextVectorPoint()
    {
        _indexSpot++;

        if (_indexSpot == _ways.Length)
            _indexSpot = 0;

        Vector3 pointVector = _ways[_indexSpot].transform.position;
        transform.forward = pointVector - transform.position;
    }
}
