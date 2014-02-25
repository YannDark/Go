//------------------------------------------------------------------------------
// Class Pion / Object 
//------------------------------------------------------------------------------
using System;

public enum couleurPion {Noir, Blanc};
public enum etatPion {Vivant, Mort};

public class Pion
{
	// Fields
	private int idPion;
	private int idGoban;
	private int positionX;
	private int positionY;
	private couleurPion couleurPion;
	private etatPion etatPion;
	
	// Constructor with arguments.
	public Pion(int IdPion, int IdGoban, int IdPartie, int PositionX, int PositionY, couleurPion CouleurPion, etatPion EtatPion)
	{
		this.idPion = IdPion;
		this.idGoban = IdGoban;
		this.positionX = PositionX;
		this.positionY = PositionY;
		this.couleurPion = CouleurPion;
		this.etatPion = EtatPion;
	}

	public int evaluer()
	{
	}

	// Method Setter
	public void setIdGoban(int IdGoban)
	{
		this.idGoban = IdGoban;
	}
	public void setPositionX(int PositionX)
	{
		this.positionX = PositionX;
	}
	public void setPositionY(int PositionY)
	{
		this.positionY = PositionY;
	}
	public void setCouleurPion(couleurPion CouleurPion)
	{
		this.couleurPion = CouleurPion;
	}
	public void setEtatPion(etatPion EtatPion)
	{
		this.etatPion = EtatPion;
	}

	// Method Getter
	public int getIdGoban()
	{
		return this.idGoban;
	}
	public int getPositionX()
	{
		return this.positionX;
	}
	public int getPositionY()
	{
		return this.positionY;
	}
	public couleurPion getCouleurPion()
	{
		return this.couleurPion;
	}
	public etatPion getEtatPion()
	{
		return this.etatPion;
	}
}
