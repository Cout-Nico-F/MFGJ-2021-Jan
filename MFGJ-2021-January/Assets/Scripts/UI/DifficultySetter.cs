﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetter : MonoBehaviour
{
    private GameManager gm;
    private PlayerController player;
    private Enemy[] enemiesArray;
    private Healing[] consumiblesArray;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        enemiesArray = FindObjectsOfType<Enemy>();
        consumiblesArray = FindObjectsOfType<Healing>();

        //Debug.Log("ENEMY AMMOUNT: " + enemiesArray.Length);
        //Debug.Log("HEALING AMMOUNT: " + consumiblesArray.Length);

        switch (gm.Difficulty)
        {
            case 1:
                TweakPlayer(health: 200, lives: 5);    
                TweakEnemies(health_multiplicator: 0.65);
                TweakConsumibles(rockets: 3, healing_multiplicator: 1.5);
                break;
            case 2:
                break;
            case 3:
                TweakPlayer(health: 80, lives: 2);
                TweakEnemies(health_multiplicator: 2.10);
                TweakConsumibles(rockets: 1, healing_multiplicator: 0.5);
                break;
            default: 
                break;
        }
    }

    private void TweakEnemies(double health_multiplicator)
    {
        foreach (Enemy enemy in enemiesArray)
        {
            enemy.healthPoints = (int)(enemy.healthPoints * health_multiplicator);

            if (enemy.healthPoints > 800)
            {
                enemy.healthPoints = 800;
            }

        }
    }

    private void TweakPlayer(int health, int lives)
    {
        player.GetComponent<PlayerController>().maxHealthPoints = health;
        player.GetComponent<PlayerController>().healthPoints = health;
        player.GetComponent<PlayerController>().lives = lives;
    }

    private void TweakConsumibles(int rockets, double healing_multiplicator)
    {
        foreach (Healing heal in consumiblesArray)
        {
            if (CompareTag("RocketAmmo"))
            {
                heal.amount = rockets;
            }
            else
            {
                heal.amount = (int) (heal.amount * healing_multiplicator);
            }
        }
    }

}