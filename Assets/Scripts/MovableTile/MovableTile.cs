using UnityEngine;
using System.Collections;

public class MovableTile : MonoBehaviour{

	protected int price;

	public int Price {
		get {return price;}
		set {price = value;}
	}

	public virtual void ShowDetails () {}

}
