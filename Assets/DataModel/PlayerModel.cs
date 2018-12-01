using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerModel {

    private static PlayerModel _instance;

    private static PlayerModel Instance {
        get {
            if (_instance == null) {
                _instance = new PlayerModel();
            }
            return _instance;
        }
    }

    private PlayerModel() {

    }

}
