using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [SerializeField] private PlayerScript playerData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = PlayerScript.isRight ? 0f : 180f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
