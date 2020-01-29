using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class myGun : MonoBehaviour
{
    [SerializeField] private int bulletForce = 10000;
    [SerializeField] private float fireRate = 0.5f;

    private Transform _barrelTransform;  // to get direction the ak points to
    private Recoil _recoil;              // to apply recoil at each bullet fired
    private ParticleSystem _partTracers; // to fire a tracer for each bullet fired
    private ParticleSystem _partFlare;   // to fire a flare for each bullet fired
    
    private float _timeSinceLastFire;    // used to cap fire rate
    
    private LayerMask _enemyLayer;       // layer containing enemies
    private RaycastHit _enemyHit;        // contains the object hit by raycast

    private void Start()
    {
        _barrelTransform = GameObject.Find("Tracers").transform;
        _recoil = GameObject.Find("Weapon").GetComponent<Recoil>();
        _enemyLayer = LayerMask.GetMask("Enemies");
        _partTracers = _barrelTransform.GetComponent<ParticleSystem>();
        _partFlare = GameObject.Find("Flare").GetComponent<ParticleSystem>();

    }
    
    private void Update()
    {
        // Update time since last bullet passes...
        _timeSinceLastFire += Time.fixedDeltaTime;
        
        // If user wants to fire bullet and enough time has passed since last bullet, then proceed ... 
        if (Input.GetMouseButton(0) && _timeSinceLastFire >= fireRate)
        {
            // ... to reset time counter
            _timeSinceLastFire = 0f;
            
            // ... to apply recoil and fire particles
            _recoil.Fire();
            _partTracers.Emit(1);
            _partFlare.Emit(1);

            // ... to apply bullet force if the bullet hit
            if (Physics.Raycast(_barrelTransform.position, _barrelTransform.forward, out _enemyHit,
                Mathf.Infinity, _enemyLayer))
            {
                StartCoroutine(nameof(ApplyBulletForce), _enemyHit);
            }
        }

    }
    
    private IEnumerator ApplyBulletForce(RaycastHit myHitObj)
    {
        var incomingVec = myHitObj.point - _barrelTransform.position;
        
        // We apply two forces, one in surface hit normal direction, and one in bullet direction
        myHitObj.rigidbody.AddForceAtPosition(incomingVec * bulletForce, myHitObj.point);
        myHitObj.rigidbody.AddForceAtPosition(- myHitObj.normal * bulletForce, myHitObj.point);
        yield return null;
    }

}
