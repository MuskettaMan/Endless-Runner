using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {

    [SerializeField] private Transform _target;

    [SerializeField] private Vector3 _offset;

    private void Update() {
        transform.position = new Vector3(_target.position.x, transform.position.y, _target.position.z) - _offset;
    }

    public void SetOffset(Vector3 offset) {
        _offset = offset;
    }

    public Vector3 GetOffset() {
        return _offset;
    }
}
