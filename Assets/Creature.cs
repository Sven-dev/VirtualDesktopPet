using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private string SqueakSfx;
    private bool OnCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        SqueakSfx = AudioManager.Instance.CreateSound("Squeak");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!OnCooldown && collision.gameObject.tag == "Wall")
        {
            AudioManager.Instance.PlayRandom(SqueakSfx);
            OnCooldown = true;
            Invoke("StopCooldown", 1f);
        }
    }

    private void StopCooldown()
    {
        OnCooldown = false;
    }
}