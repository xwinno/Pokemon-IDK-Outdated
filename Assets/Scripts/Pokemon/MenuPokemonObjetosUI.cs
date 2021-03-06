﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPokemonObjetosUI : MonoBehaviour {

	public Transform SlotControl;
	public GameObject MenuPokemon;
	public GameObject PlayerScripts;
	Inventario inventario;
	EquipoPokemon equipo;
	PokemonSlot[] slots;

	// Use this for initialization
	void Start () 
	{
		
		inventario = Inventario.instance;
		inventario.AlCambiarObjetosLlamada += UpdateUI;
		equipo = EquipoPokemon.instance;
		equipo.AlCambiarPokemonLlamada += UpdateUI;

		slots = SlotControl.GetComponentsInChildren<PokemonSlot>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Tab) && PlayerScripts.GetComponent<PlayerManagement>().BattleMode == false)
		{
			MenuPokemon.SetActive(!MenuPokemon.activeSelf);
		}
	}

	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < equipo.equipoPokemon.Count)
			{
				slots[i].AñadirPokemon(equipo.equipoPokemon[i]);
			}
		}
	}
}
