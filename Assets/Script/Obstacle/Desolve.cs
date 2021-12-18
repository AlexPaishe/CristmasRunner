using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desolve : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private MeshRenderer _mesh;
    public bool go = false;
    private float _fade = 1;

    void Update()
    {
        if(go == true)
        {
            _fade -= Time.deltaTime * _step;
            if(_fade <= 0)
            {
                Destroy(this.gameObject);
            }
            _mesh.material.SetFloat("_Fade", _fade);
        }
    }
}
