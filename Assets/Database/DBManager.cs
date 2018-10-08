using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour {



	public InputField email, password;
	// Use this for initialization
	public Text log;

	public void LoginButtonPressed(){
		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(email.text,password.text).
		ContinueWith((response)=>{
			
			if(response.IsCanceled){
				Debug.LogError("LOGIN CANCELADO");
				return;
			}
			if(response.IsFaulted){
				Debug.LogError("Ocurrio un error");
				log.text = "USUARIO O CONTRASENA INCORRECTOS";
				return;
			}

			FirebaseUser user = response.Result;
			Debug.LogFormat("Usuario logueado: {0}  {1}", user.Email, user.UserId);
			log.text= "USUARIO LOGUEADO";
			
		});
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
