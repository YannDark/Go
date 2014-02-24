//------------------------------------------------------------------------------
// Class Joueurs / Object 
//------------------------------------------------------------------------------
using System;

public class Joueur
{
	// Fields
	private int idJoueur;
	private string nom;
	
	// Constructor with arguments.
	public Joueur(int IdJoueur, string Nom)
	{
		this.idJoueur = IdJoueur;
		this.nom = Nom;
	}
	
	// Method Setter
	public void setNom(string Nom)
	{
		this.nom = Nom;
	}
	
	// Method Getter
	public string getNom()
	{
		return this.nom;
	}
}
