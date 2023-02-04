using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//Dlaczego pandy s¹ czarno-bia³e?
	//Bo zesz³y z drzew ale wróci³y

	public string name;
    public int id;
    public int health;
	public float speed;

	public void Whyushootme(int damage)
	{
		health= health-damage;
	}
}
