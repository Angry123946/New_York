using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//Dlaczego pandy s� czarno-bia�e?
	//Bo zesz�y z drzew ale wr�ci�y

	public string name;
    public int id;
    public int health;
	public float speed;

	public void Whyushootme(int damage)
	{
		health= health-damage;
	}
}
