using UnityEngine;
using UnityEngine.AI;
public class EnemyNawMesh : MonoBehaviour
{
   private NavMeshAgent _agent;
     private Transform _player;

    [SerializeField] private float _distance;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position,_player.position) <= _distance)
        { 
        _agent.SetDestination(_player.position );
        }
        else
        _agent.ResetPath();
    }
}
