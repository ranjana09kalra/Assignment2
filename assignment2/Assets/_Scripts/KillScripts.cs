using UnityEngine;
using System.Collections;

public class KillScripts : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DeathPlan"))
        {
            Destroy(this.gameObject);
        }
    }
}
