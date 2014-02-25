//------------------------------------------------------------------------------
// Class Partie / Object 
//------------------------------------------------------------------------------
using System;

public enum etatPartie {Encours, Termine};

public class Partie
{
	// Fields
	private int idPartie;
	private int idJoueurNoir;
	private int idJoueurBlanc;
	private int scoreNoir;
	private int scoreBlanc;
	private etatPartie etatPartie;
	private DateTime heureDebut;
	private DateTime heureFin;
	
	// Constructor with arguments.
	public Partie(int IdPartie, int IdJoueurNoir, int IdJoueurBlanc, etatPartie EtatPartie, DateTime HeureDebut, DateTime HeureFin)
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
	public void setScoreBlanc(int ScoreBlanc)
	{
		this.scoreBlanc = ScoreBlanc;
	}
	public void setScoreNoir(int ScoreNoir)
	{
		this.scoreNoir = ScoreNoir;
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
	public int getScoreBlanc()
	{
		return this.scoreBlanc;
	}
	public int setScoreNoir()
	{
		return this.scoreNoir;
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
