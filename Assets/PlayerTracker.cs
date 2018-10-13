using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {

    [SerializeField] private Transform _target;

    private Vector3 _offset;

    private void Start() {
        _offset = new Vector3(-20, 0, 17.45f);
    }

    private void Update() {
        transform.position = new Vector3(_target.position.x, 0, _target.position.z) - _offset;
    }
}
