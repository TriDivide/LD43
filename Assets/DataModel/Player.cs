using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player  {

    public enum ClassType {
        Fighter,
        Defender
    }

    public ClassType playerClass;

    public float health = 100f;
    public List<System.Object> powerUps = new List<System.Object>();
    public float attackStat = 10f;
    public float defenceStat = 10f;
    public List<System.Object> invenvory = new List<System.Object>();
    public String name = "";
    public float baseDamage = 10f;

   
     
    public void ReceiveDamage(float damageReceived) {
        health -= (damageReceived / (defenceStat / 10));
    }




    
    
}
