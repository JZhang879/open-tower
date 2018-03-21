﻿using Scripts.LevelEditor.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deserializer : MonoBehaviour {
    private static Deserializer _instance;

    [SerializeField]
    private JSONLevel uploadOverride;

    [SerializeField]
    private GameObject floorPrefab;

    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject upstairsPrefab;

    [SerializeField]
    private GameObject downstairsPrefab;

    [SerializeField]
    private GameObject goldKeyPrefab;

    [SerializeField]
    private GameObject blueKeyPrefab;

    [SerializeField]
    private GameObject redKeyPrefab;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject exitPrefab;

    [SerializeField]
    private GameObject goldDoorPrefab;

    [SerializeField]
    private GameObject blueDoorPrefab;

    [SerializeField]
    private GameObject redDoorPrefab;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject boosterPrefab;

    private Upload upload;

    public static Deserializer Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<Deserializer>();
            }
            return _instance;
        }
    }

    public void CreateLevelFromJson() {
        this.upload = uploadOverride.Upload;
        Init(upload.LevelJson, uploadOverride.SceneOnVictory, uploadOverride.SceneOnVictory);
    }

    private void Awake() {
        LevelInfo info = LevelInfo.Instance;
        if (uploadOverride == null) {
            this.upload = info.Upload;
            Init(upload.LevelJson, info.ExitScene, info.ExitScene);
        } else {
            CreateLevelFromJson();
        }
    }

    private void Init(string json, string sceneOnVictory, string sceneOnExit) {
        DontDestroyOnLoad(this.gameObject);
        DungeonManager dungeon = DungeonManager.Instance;
        DungeonInfo info = DungeonInfo.Instance;

        SerializationUtil.DeserializeDungeonToPlayable(
            json,
            sceneOnVictory,
            sceneOnExit,
            info,
            dungeon.gameObject,
            floorPrefab,
            wallPrefab,
            upstairsPrefab,
            downstairsPrefab,
            goldKeyPrefab,
            blueKeyPrefab,
            redKeyPrefab,
            playerPrefab,
            exitPrefab,
            goldDoorPrefab,
            blueDoorPrefab,
            redDoorPrefab,
            enemyPrefab,
            boosterPrefab);
    }
}