using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour
{
    private bool isNearCollider = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isNearCollider = true;
            Debug.Log("triggered");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isNearCollider = false;
            Debug.Log("not triggered");
        }
    }

    // Public method to access the isNearCollider status
    public bool GetIsNearCollider() {
        return isNearCollider;
    }
}
