using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private void OnParticleCollision(GameObject other) {
        Debug.Log("닿았음");
    }
}
