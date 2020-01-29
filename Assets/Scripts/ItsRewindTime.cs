using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItsRewindTime : MonoBehaviour
{
    // User can rewind time when using right-click
    
    private List<Vector3> _positions;      // stores past positions
    private List<Quaternion> _rotations;   // stores past rotations
    private Rigidbody _rb;
    
    private bool _isRewinding;
    
    void Start()
    {
        _positions = new List<Vector3>();
        _rotations = new List<Quaternion>();
        _isRewinding = false;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // _isRewinding is true while right-click is held
        if (Input.GetKeyDown(KeyCode.Mouse1)) _isRewinding = true;
        if (Input.GetKeyUp(KeyCode.Mouse1)) _isRewinding = false;

    }

    private void FixedUpdate()
    {
        // if user wants to rewind and rewind data lists aren't empty ...
        if (_isRewinding && _positions.Count>0) 
        {
            // .. we set objects to kinematic so Unity doesn't try to calculate physics for it
            _rb.isKinematic = true;
            // .. we set their last frame position and rotation
            transform.position = _positions[0];
            transform.rotation = _rotations[0];
            // .. and delete them before proceeding to next frame
            _positions.RemoveAt(0);
            _rotations.RemoveAt(0);
        }
        // else ...
        else
        {
            // .. we disable kinematic state
            _rb.isKinematic = false;
            
            // .. record the current data
            _positions.Insert(0,transform.position);
            _rotations.Insert(0,transform.rotation);
            
            // .. delete data older than 15 seconds
            if (_positions.Count > Mathf.Round(15f / Time.fixedDeltaTime))
            {
                _positions.RemoveAt(_positions.Count - 1);
                _rotations.RemoveAt(_rotations.Count - 1);
            }
        }
    }
}
