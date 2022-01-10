using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacle : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshs;
    [SerializeField] private float _step;
    private float _fade = 1;
    public bool go = false;

    public float Fade
    {
        get
        {
            return _fade;
        }
        set
        {
            _fade = value;
            if(_fade <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Update()
    {
        if(go == true)
        {
            Fade -= _step *Time.deltaTime * Base.PlayerSpeed;
            for(int i = 0; i < _meshs.Length; i ++)
            {
                _meshs[i].material.SetFloat("_Fade", Fade);
            }
        }
    }
}
