﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private int xp = 0;
    [SerializeField] private int requiredXp = 100;
    [SerializeField] private int levelBase = 100;
    [SerializeField] private List<GameObject> droids = new List<GameObject>();
    [SerializeField] private Animation walk;
    private int lvl = 1;

    public int Xp
    {
        get { return xp; }
    }
    public int RequiredXp
    {
        get { return requiredXp; }
    }
    public int LevelBase
    {
        get { return levelBase; }
    }
    public List<GameObject> Droids
    {
        get { return droids; }
    }

    public int Lvl
    {
        get{ return lvl; }
    }
    private void Start () {
        InitLevelData();
	}
    public void AddXp(int xp)
    {
        this.xp += Mathf.Max(0,xp);
        if (this.xp >= 100){
            this.xp = 0;
            lvl++;
        }
    }
    public void Adddroid(GameObject droid)
    {
        droids.Add(droid);
    }
    private void InitLevelData()
    {
        lvl = (xp / levelBase) + 1;
        requiredXp = levelBase * lvl;
    }

    private void Update()
    {
        Walk();
    }
    void Walk()
    {
        if (transform.hasChanged)
        {
            walk.Play();
            StartCoroutine(Wait());
        }
        else if (!transform.hasChanged)
        {
            walk.Stop();
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);

        transform.hasChanged = false;
    }
}
