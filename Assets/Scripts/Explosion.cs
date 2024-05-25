using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radiusExplosian;
    [SerializeField] private float _forceExplosian;

    private float _additionalForceExplosian = 100;

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusExplosian);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody = colliders[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_forceExplosian, transform.position, _radiusExplosian);
            }
        }
    }

    public void IncreaseForceExplosian()
    {
        _forceExplosian += _additionalForceExplosian;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radiusExplosian);
    }
}
