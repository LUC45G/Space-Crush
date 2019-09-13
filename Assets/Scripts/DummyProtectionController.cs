using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyProtectionController : MonoBehaviour {

    public static DummyProtectionController Instance; // Singleton Instance
    [SerializeField]
    private BoxCollider2D[] hitboxes; 
    [SerializeField]
    private Sprite[] spritesByHP;

    void OnEnable() {
        Instance = this;

    }

    public BoxCollider2D getHitboxByHP(int hp) {
        return hitboxes[hp-1];
    }
    
    public Sprite getSpriteByHP(int hp) {
        return spritesByHP[hp-1];
    }
}
