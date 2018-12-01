using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy {


    public float health = 40f;

    public float attack = 10f;

    public Enemy(float health = 40f, float attack = 10f) {
        this.health = health;
        this.attack = attack;
    }

    public void takeDamage(float damageReceived) {
        health -= damageReceived; 
    }
}
