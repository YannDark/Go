//------------------------------------------------------------------------------
// Class Goban / Object 
//------------------------------------------------------------------------------
using System;

public enum natureCoup {Poser, Passer};

public class Goban
{
	// Fields
	private int idGoban;
	private int idPartie;
	private int numeroCoup;
	private natureCoup natureCoup;
	private int joueurEnCours;

	// Constructor with arguments.
	public Goban(int IdGoban, int IdPartie, int NumeroCoup, natureCoup NatureCoup, int JoueurEnCours)
	{
		this.idGoban = IdGoban;
		this.idPartie = IdPartie;
		this.numeroCoup = NumeroCoup;
		this.natureCoup = NatureCoup;
		this.joueurEnCours = JoueurEnCours;
	}
	
	// Method Setter
	public void setIdPartie(int IdPartie)
	{
		this.idPartie = IdPartie;
	}
	public void setNumeroCoup(int NumeroCoup)
	{
		this.numeroCoup = NumeroCoup;
	}
	public void setNatureCoup(natureCoup NatureCoup)
	{
		this.natureCoup = NatureCoup;
	}
	public void setJoueurEnCours(int JoueurEnCours)
	{
		this.joueurEnCOurs = JoueurEnCours;
	}

	// Method Getter
	public int getIdPartie()
	{
		return this.idPartie;
	}
	public int getNumeroCoup()
	{
		return this.numeroCoup;
	}
	public natureCoup getNatureCoup()
	{
		return this.natureCoup;
	}
	public int getJoueurEnCours()
	{
		return this.joueurEnCOurs;
	}
}
