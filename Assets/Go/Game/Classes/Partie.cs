//------------------------------------------------------------------------------
// Class Partie / Object 
//------------------------------------------------------------------------------
using System;

public enum etatPartie {Encours, Termine};

public class Goban
{
	// Fields
	private int idPartie;
	private int idJoueurNoir;
	private int idJoueurBlanc;
	private etatPartie etatPartie;
	private DateTime heureDebut;
	private DateTime heureFin;
	
	// Constructor with arguments.
	public Goban(int IdPartie, int IdJoueurNoir, int IdJoueurBlanc, etatPartie EtatPartie, DateTime HeureDebut, DateTime HeureFin)
	{
		this.idPartie = IdPartie;
		this.idJoueurNoir = IdJoueurNoir;
		this.idJoueurBlanc = IdJoueurBlanc;
		this.etatPartie = EtatPartie;
		this.heureDebut = HeureDebut;
		this.heureFin = HeureFin;
	}
	
	// Method Setter
	public void setIdJoueurNoir(int IdJoueurNoir)
	{
		this.idJoueurNoir = IdJoueurNoir;
	}
	public void setIdJoueurBlanc(int IdJoueurBlanc)
	{
		this.idJoueurBlanc = IdJoueurBlanc;
	}
	public void setEtatPartie(etatPartie EtatPartie)
	{
		this.etatPartie = EtatPartie;
	}
	public void setHeureDebut(DateTime HeureDebut)
	{
		this.heureDebut = HeureDebut;
	}
	public void setHeureFin(DateTime HeureFin)
	{
		this.heureFin = HeureFin;
	}
	
	// Method Getter
	public int getIdJoueurNoir()
	{
		return this.idJoueurNoir;
	}
	public int getIdJoueurBlanc()
	{
		return this.idJoueurBlanc;
	}
	public etatPartie getEtatPartie()
	{
		return this.etatPartie;
	}
	public DateTime getHeureDebut()
	{
		return this.heureDebut;
	}
	public DateTime getHeureFin()
	{
		return this.heureFin;
	}
}
